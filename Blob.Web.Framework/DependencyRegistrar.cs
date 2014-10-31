using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Blob.Core.Infrastructure.DependencyManagement;
using Blob.Core.Infrastructure;
using Blob.Core.Data;
using Blob.Services.Users;
using Blob.Data;
using System.Data.Entity;
using System.Web;
using System.Data;
using Blob.Web.Framework.UI;


namespace Blob.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

            //HTTP context and other related stuff
            //builder.Register(c =>
            //    //register FakeHttpContext when HttpContext is not available
            //    HttpContext.Current != null ?
            //    (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
            //    (new FakeHttpContext("~/") as HttpContextBase))
            //    .As<HttpContextBase>()
            //    .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            //services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();           

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            //data layer           

            var dataSettingsManager = new DataSettingsManager();
            var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
            var dataProvider = efDataProviderManager.LoadDataProvider();
            dataProvider.InitConnectionFactory();

            builder.Register<IDbContext>(c => new BlobObjectContext("server=FORD\\sqlExpress;database=CodeFirstData.BlobContext;Trusted_Connection=True;")).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //other objects
            builder.RegisterType<PageHeadBuilder>().As<IPageHeadBuilder>().InstancePerLifetimeScope();
           
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
