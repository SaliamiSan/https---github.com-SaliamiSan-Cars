﻿using System.Web.Mvc;

namespace CarRent.Areas.Car
{
    public class CarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Car";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Car_print",
                "Print/{controller}/Index/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Car_default",
                "Car/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}