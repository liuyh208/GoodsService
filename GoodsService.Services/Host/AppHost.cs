using System.Web.Security;
using Funq;
using GoodsService.Core;
using GoodsService.Core.Data;
using GoodsService.Domain;
using GoodsService.Services.Responses;
using ServiceStack;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace GoodsService.Services.Host
{
    public class ServiceInit
    {
        private ServiceInit()
        {
        }

        private static AppHost appHost;

        public static  void Init()
        {
           // AppEx.Start();

           
            appHost = new AppHost();
            appHost.Init();

        }

     
    }

    public class AppHost : AppHostBase
    {
        //Tell Service Stack the name of your application and where to find your web services
        public AppHost()
            : base("GasMap Web Services", typeof (AccountService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            SetConfig(new EndpointHostConfig
            {
                DefaultContentType = ContentType.Json,
                GlobalResponseHeaders =
                {
                    {"Access-Control-Allow-Origin", "*"},
                    {"Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS"},
                },
            });

            // register storage for user sessions 
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<ISessionFactory>(c => new SessionFactory(c.Resolve<ICacheClient>()));

            // Register AuthFeature with custom user session and custom auth provider
            Plugins.Add(new AuthFeature(
                () => new CustomUserSession(),
                new[] {new CustomAuthProvider()}
                ));

            //ApplicationEx.Start(DbCnnFactoryManager.CreateCnnFactory("sqlserver", DbProvider.MsSqlProvider));
        }
    }
}