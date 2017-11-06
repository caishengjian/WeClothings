using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;//
using Autofac.Integration.Mvc;//
using System.Reflection;//反射
using System.Web.Mvc;//
using WeClothings.App_Start;//

namespace WeClothings.App_Start
{
    public class AutofacConfig:System.Web.HttpApplication
    {
        public static void autoDepence()
        {
            //先实例化一个构造器
            //反射 using System.Reflection;
            var builder = new ContainerBuilder();
            //使用方高层次的以属性的方式来实现
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //如果注册使用方是不加.PropertiesAutowired()表示依赖注入的方式默认是构造函数，如果加上表示使用属性实现   Properties（属性）
            var iRepository = Assembly.Load("Clothing.IRepository");//IDAL
            var iService = Assembly.Load("Clothing.IService");//IBLL
            var repository = Assembly.Load("Clothing.Repository");//DAL
            var service = Assembly.Load("Clothing.Service");//BLL
            //注册程序集类型，就是实现方，低层次的，以接口的形式注册（IDAL IBLL）具体实现由BLL DAL
            //程序集的名称必须是以Repository结尾
            builder.RegisterAssemblyTypes(iRepository, repository).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            //Service结尾
            builder.RegisterAssemblyTypes(iService, service).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //实例化一个容器
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //以autofac的注入替换原有的实现方式
        }
    }
}