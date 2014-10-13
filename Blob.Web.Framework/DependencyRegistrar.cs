using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using Autofac.Core; 
using Blob.Core.Infrastructure.DependencyManagement;
using Blob.Core.Infrastructure;
using Blob.Services.Users;



namespace Blob.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
