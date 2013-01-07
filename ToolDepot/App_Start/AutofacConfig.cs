using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ToolDepot.Core;
using ToolDepot.Core.Fakes;
using ToolDepot.Data;
using ToolDepot.Infrastructure;
using ToolDepot.Services.Email;
using ToolDepot.Services.Logging;

namespace ToolDepot.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {

            var builder = new ContainerBuilder();

            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
            HttpContext.Current != null ?
            (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
            (new FakeHttpContext("~/") as HttpContextBase))
            .As<HttpContextBase>()
            .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();
            //http models
            //builder.RegisterModule(new AutofacWebTypesModule());

            //controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //model binders
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();


            //filter
            //builder.RegisterFilterProvider();

            //Init other services
            InitService(builder);


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));




        }

        private static void InitService(ContainerBuilder builder)
        {
            //data
            builder.Register<IDbContext>(c => new AppContext()).InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();
            builder.RegisterType<WorkContext>().As<IWorkContext>().InstancePerHttpRequest();
            
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerHttpRequest();
            builder.RegisterType<Tokenizer>().As<ITokenizer>().InstancePerHttpRequest();
            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerHttpRequest();
            //builder.RegisterType<Task>().As<ITask>().InstancePerHttpRequest();
            //builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerHttpRequest();
            //services
            var assembly = Assembly.Load("ToolDepot");

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerHttpRequest();

            //tasks
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Task"))
                .AsImplementedInterfaces()
                .InstancePerHttpRequest();
        }
    }
}