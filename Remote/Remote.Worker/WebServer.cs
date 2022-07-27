using Microsoft.Owin.Hosting;
using System;

namespace Remote.Worker
{
    public class WebServer : IDisposable
    {
        private IDisposable _actionServer;

        public WebServer(string baseUrl)
        {
            _actionServer = WebApp.Start<Startup>(baseUrl);
        }

        public void Dispose()
        {
            if (_actionServer != null)
            {
                _actionServer.Dispose();
            }
        }
    }
}