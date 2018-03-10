using Autofac;
using Autofac.Core;
using StudentManagement.DAL;
using StudentManagement.Domain.Entities;
using StudentManagement.Web.Service;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using StudentManagement.Web.IService;
using System.Reflection;
using System.Configuration;
using StudentManagement.DAL.EFManager;
using StudentManagement.DAL.IEFManager;
using StudentManagement.DAL.EFManger;

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
            EfStartUpTask.Execute();
        }

        private void RegisterDependency()
        {
            var builder = new ContainerBuilder();

            var _connectionString =
           ConfigurationManager.ConnectionStrings["STU_context"].ConnectionString;

            builder.Register<IDbContext>(c =>
                (IDbContext)Activator.CreateInstance(typeof(StudentManagemenetObjectContext),
                new object[] { _connectionString }))
                      .Named<IDbContext>("STU_context")
                      .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Address>>()
              .As<IRepository<Address>>()
              .WithParameter(ResolvedParameter.
                    ForNamed<IDbContext>("STU_context"))
              .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Student>>()
             .As<IRepository<Student>>()
             .WithParameter(ResolvedParameter.
                   ForNamed<IDbContext>("STU_context"))
             .InstancePerLifetimeScope();

            builder.RegisterType<SudentService>()
                .As<IStudentService>().InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
