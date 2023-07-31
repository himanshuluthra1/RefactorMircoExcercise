using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class TirePressureMonitoringSystem
    {
        [TestMethod]
        public void Check_WithLowPressure_ShouldSetAlarmOn()
        {
            
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(15); // Below LowPressureThreshold
            var alarm = new Alarm(mockSensor.Object);

            
            alarm.Check();

            
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Check_WithinPressure_ShouldSetAlarmOn()
        {
            
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(19); // Within Range
            var alarm = new Alarm(mockSensor.Object);

            
            alarm.Check();

            
            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
