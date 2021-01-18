using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using CKSource.CKFinder.Connector.Host.Owin;
using CKSource.CKFinder.Connector.Config;
using CKSource.FileSystem.Local;
using CKSource.CKFinder.Connector.Core.Builders;

[assembly: OwinStartup(typeof(Blog.UI.App_Classes.Startup))]
namespace Blog.UI.App_Classes
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            FileSystemFactory.RegisterFileSystem<LocalStorage>();
            app.Map("/ckfinder/connector", SetupConnector);
        }
        private static void SetupConnector(IAppBuilder appBuilder)
        {
            var connectorFactory = new OwinConnectorFactory();
            var connectorBuilder = new ConnectorBuilder();
            var customAuthenticator = new CKFinderAuthenticator();
            connectorBuilder.LoadConfig().SetAuthenticator(customAuthenticator).SetRequestConfiguration((request, config) 
                => { config.LoadConfig(); });

            var connector = connectorBuilder.Build(connectorFactory);

            appBuilder.UseConnector(connector);
        }
    }
}