using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace DapperT1
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            var builder = new ContainerBuilder();

            //獲取 HttpConfiguration
            var config = GlobalConfiguration.Configuration;

            //註冊api controller(使用Reflection)
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //註冊Service相依關係
            //builder.Register<TestService>().AsSelf().InstancePerApiRequest();

            //(optional)註冊AutofacFilterProvider
            builder.RegisterWebApiFilterProvider(config);

            //builder.RegisterType<Configuration>()
            //    .As<IConfiguration>()
            //    .InstancePerLifetimeScope();

            var container = builder.Build();

            //建立相依解析器
            var resolver = new AutofacWebApiDependencyResolver(container);

            //組態Web API相依解析器
            config.DependencyResolver = resolver;
        }
    }
}