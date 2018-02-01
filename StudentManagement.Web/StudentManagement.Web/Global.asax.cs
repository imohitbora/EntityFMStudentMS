using Autofac;
using Autofac.Core;
using StudentManagement.DAL;
using StudentManagement.Domain.Entities;
using StudentManagement.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using StudentManagement.Web.IService;
using System.Reflection;

namespace StudentManagement.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDependency();
        }

        private void RegisterDependency()
        {
            var builder = new ContainerBuilder();

            builder.Register<IDbContext>(c =>
            (IDbContext)Activator.CreateInstance(typeof(StudentManagemenetObjectContext),
            new object[] {  }))
                  //.Named<IDbContext>("STU_context")
                  .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Address>>()
              .As<IRepository<Address>>()
            //  .WithParameter(ResolvedParameter.
                //    ForNamed<IDbContext>("STU_context"))
              .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Student>>()
             .As<IRepository<Student>>()
           //  .WithParameter(ResolvedParameter.
             //      ForNamed<IDbContext>("STU_context"))
             .InstancePerLifetimeScope();

            builder.RegisterType<SudentService>()
                .As<IStudentService>().InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
