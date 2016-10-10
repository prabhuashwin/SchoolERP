//-----------------------------------------------------------------------
// <copyright file="NoCacheAttribute.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.WebApp.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Add [NoCache] Controller 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Prevent Browser from Caching
        /// </summary>
        /// <param name="filterContext">The filterContext</param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Buffer = true;
            filterContext.HttpContext.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            filterContext.HttpContext.Response.Expires = -1500;
            filterContext.HttpContext.Response.CacheControl = "no-cache";
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnResultExecuting(filterContext);
        }
    }
}