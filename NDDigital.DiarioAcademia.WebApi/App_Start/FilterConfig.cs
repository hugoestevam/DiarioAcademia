﻿using NDDigital.DiarioAcademia.WebApi.Filters;
using System.Web.Mvc;

namespace NDDigital.DiarioAcademia.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new GrouperAuthorizeAttribute());
        }
    }
}