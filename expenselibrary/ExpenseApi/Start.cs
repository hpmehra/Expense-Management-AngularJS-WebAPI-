using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(ExpenseApi.Startup))]

namespace ExpenseApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            @app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}