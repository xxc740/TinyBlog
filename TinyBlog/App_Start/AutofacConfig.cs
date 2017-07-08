using Autofac;
using Autofac.Integration.Mvc;
using Repository.UserInfo;
using Service.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TinyBlog
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            //注入所有Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            var respAss = Assembly.Load("Repository");
            builder.RegisterAssemblyTypes(respAss).Where(e => e.Name.EndsWith("Repository")).AsImplementedInterfaces();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            Assembly serAss = Assembly.Load("Service");
            builder.RegisterAssemblyTypes(serAss).Where(e => e.Name.EndsWith("Service")).AsImplementedInterfaces();

            //硬代码实现依赖注入
            // builder.RegisterType<SysUserInfoService>().As<ISysUserInfoService>();
            // builder.RegisterType<SysUserInfoRepository>().As<ISysUserInfoRepository>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}