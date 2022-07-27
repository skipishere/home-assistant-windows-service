using Owin;
using System.Configuration;

namespace Remote.Worker
{
    internal class Startup
    {
        private string headerKey = ConfigurationManager.AppSettings["headerKey"];

        public void Configuration(IAppBuilder app)
        {
            var action = new Actions();

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                var requestHeaderKey = context.Request.Headers["x-functions-key"];
                if (context.Request.Method.ToLower() != "post" || requestHeaderKey != headerKey)
                {
                    context.Response.StatusCode = 404;
                    return context.Response.WriteAsync(string.Empty);
                }


                switch (context.Request.Path.Value)
                {
                    case @"/remote/screen":
                        context.Response.StatusCode = 200;
                        action.ScreensOff();
                        break;

                    case @"/remote/hibernate":
                        context.Response.StatusCode = 200;
                        action.Hibernate();
                        break;

                    case @"/remote/sleep":
                        context.Response.StatusCode = 200;
                        action.Sleep();
                        break;

                    default:
                        context.Response.StatusCode = 404;
                        break;
                }

                return context.Response.WriteAsync(string.Empty);
            });
        }
    }
}