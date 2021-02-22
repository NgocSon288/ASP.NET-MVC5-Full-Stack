using Autofac;
using Autofac.Integration.Mvc;
using FShop.Data;
using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Service.Services;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(FShop.Web.App_Start.Startup))]

namespace FShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // AutoFac
            ConfigurationAutofac(app); 
        }

        private void ConfigurationAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());   // Register Web Controllers MVC
            // Register your Web API controllers.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<FShopDbContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(AdvertisementRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(BrandRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryMemberRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryNotificationRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(CommentRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(ImportBillRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(ImportBillDetailRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(MemberRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(MemberNotificationRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(MemberStatusRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(NotificationRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(OrderRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(OrderDetailRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(OrderStatusRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PaymentMethodRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PermissionRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PermissionCategoryMemberRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(ProductCategoryRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(SlideRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 
            builder.RegisterAssemblyTypes(typeof(SupplierRepository).Assembly) .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest(); 

            // Services
            builder.RegisterAssemblyTypes(typeof(AdvertisementService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(BrandService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryMemberService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryNotificationService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CommentService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ImportBillService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ImportBillDetailService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MemberService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MemberNotificationService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MemberStatusService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NotificationService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OrderService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OrderDetailService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OrderStatusService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PaymentMethodService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PermissionCategoryMemberService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PermissionService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductCategoryService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(SlideService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(SupplierService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}
