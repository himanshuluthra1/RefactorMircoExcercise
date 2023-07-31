using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TDDMicroExercises.TelemetrySystem;

namespace UnitTests
{
    [TestClass]
    public class TelemetryDiagnosticControlsTests
    {
        [TestMethod]
        public void CheckTransmission_SuccessfulConnection_SetsDiagnosticInfo()
        {

            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(client => client.OnlineStatus).Returns(true);
            mockTelemetryClient.Setup(obj => obj.Send(TelemetryClient.DiagnosticMessage)).CallBase();
            mockTelemetryClient.Setup(obj => obj.Receive()).CallBase();

            var telemetryControls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            
            telemetryControls.CheckTransmission();

            
            Assert.IsNotNull(telemetryControls.DiagnosticInfo);
            mockTelemetryClient.Verify(client => client.Connect(TelemetryClient.DiagnosticChannelConnectionString), Times.Once);
            mockTelemetryClient.Verify(client => client.Send(TelemetryClient.DiagnosticMessage), Times.Once);
            mockTelemetryClient.Verify(client => client.Receive(), Times.Once);
        }

        [TestMethod]
        public void CheckTransmission_UnsuccessfulConnection_ThrowsException()
        {
            
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.SetupSequence(client => client.OnlineStatus)
                .Returns(false)
                .Returns(false)
                .Returns(false);

            var telemetryControls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            Assert.ThrowsException<Exception>(() => telemetryControls.CheckTransmission());

            mockTelemetryClient.Verify(client => client.Connect(TelemetryClient.DiagnosticChannelConnectionString), Times.Exactly(3));
            mockTelemetryClient.Verify(client => client.Send(It.IsAny<string>()), Times.Never);
            mockTelemetryClient.Verify(client => client.Receive(), Times.Never);
        }
    }
}
