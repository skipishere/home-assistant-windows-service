using System;
using System.ServiceProcess;
using Remote.Worker;

namespace Remote.Service
{
    public partial class HomeAssistantRemote : ServiceBase
    {
        private string _baseUrl = "http://*:5001/";
        private IDisposable _actionServer;

        public HomeAssistantRemote()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _actionServer = new WebServer(_baseUrl);
        }

        protected override void OnStop()
        {
            if (_actionServer != null)
            {
                _actionServer.Dispose();
            }
        }
    }
}
