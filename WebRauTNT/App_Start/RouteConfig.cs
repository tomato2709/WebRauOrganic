﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebRauTNT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "contact",
                url: "LienHe",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "giohang",
                url: "GioHang",
                defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "login",
                url: "DangNhap",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "register",
                url: "Register",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }
            );
        }
    }
}
