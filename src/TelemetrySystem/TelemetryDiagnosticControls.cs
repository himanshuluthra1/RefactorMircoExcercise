
using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;
        

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        public TelemetryDiagnosticControls()
        {
            _telemetryClient = new TelemetryClient();
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;
            ConnectToTelemetryServer();
            _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
            _diagnosticInfo = _telemetryClient.Receive();
        }

        private void ConnectToTelemetryServer()
        {
            _telemetryClient.Disconnect();

            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(TelemetryClient.DiagnosticChannelConnectionString);
                retryLeft--;
            }

            if (!_telemetryClient.OnlineStatus)
            {
                throw new Exception("Unable to connect.");
            }
        }
    }
}
