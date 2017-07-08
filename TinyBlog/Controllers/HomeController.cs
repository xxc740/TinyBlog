using Domain.Models;
using Service.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyBlog.Controllers
{
    public class HomeController : BaseController
    {
        ISysUserInfoService userinfoService;

        public HomeController(ISysUserInfoService userinfo)
        {
            this.userinfoService = userinfo;
        }

        public ActionResult Index()
        {
            int i = 1;
            int b = 0;
            int c;
            c = i / b;

            return View();
            //try
            //{

            //var userinfo = userinfoService.QuerySingle(u => u.CreateTime < DateTime.Now).FirstOrDefault();
            //for(int i = 0; i < 10; i++)
            //{
            //    userinfoService.Add(new SysUserInfo()
            //    {
            //        Id = Guid.NewGuid(),
            //        LoginName = "Admin" + i,
            //        LoginPassword = "12345",
            //        RealName = "超级管理员" + i,
            //        CreateTime = DateTime.Now,
            //        UpdateTime = DateTime.Now,
            //        Remark = "Test Add feature"
            //    });
            //}
            //var result = userinfoService.SaveChanges();
            // return Content(userinfo.LoginName);
            //}
            //catch (Exception e)
            //{
            //    return Content(e.Message);
            //}
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}