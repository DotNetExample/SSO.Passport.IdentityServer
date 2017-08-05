﻿using System.Web.Mvc;
using SSO.Core;
using SSO.Core.Client;

namespace WebAppClient.Controllers
{
    public class HomeController : Controller
    {
        [Authority(Code = AuthCodeEnum.Login)]
        public ActionResult Index()
        {
            return View();
        }
    }
}