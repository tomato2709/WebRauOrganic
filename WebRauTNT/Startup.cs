﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRauTNT.Startup))]
namespace WebRauTNT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
