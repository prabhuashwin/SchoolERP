//-----------------------------------------------------------------------
// <copyright file="ExceptionHandler.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.WebApp.Utility
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// ExceptionHandler is used to respond to the occurrence, of exceptions.
    /// </summary>
    public class ExceptionHandler : HandleErrorAttribute
    {
        /// <summary>
        /// Retrieves the error information
        /// </summary>
        /// <param name="filterContext">The filterContext</param>
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}