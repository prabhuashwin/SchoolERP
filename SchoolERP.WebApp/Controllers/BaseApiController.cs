//-----------------------------------------------------------------------
// <copyright file="BaseApiController.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.WebApp.Controllers
{    
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using SchoolERP.DTO;
    using SchoolERP.WebApp.Utility;

    /// <summary>
    /// 
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// On Exception ,Create a JSON Response {Success:false,Message:Exception.Message}
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <returns>
        /// HttpResponseMessage-CreateResponse that will return the exception message HttpStatusCode.BadRequest
        /// </returns>
        public HttpResponseMessage GetExceptionAsJsonResponse(Exception exception)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Success = false;
            operationResult.Message = exception.Message;
            return this.Request.CreateResponse(HttpStatusCode.BadRequest, operationResult, "text/json");
        }

        /// <summary>
        /// Check if the user is valid,using Http Header value "Token" .
        /// </summary>
        /// <returns>
        /// Class object OperationResult,if Success OperationResult contains the token value
        /// </returns>
        public OperationResult IsUserAuthorized()
        {
            OperationResult operationResult;
            var token = this.Request.GetHeader("Token");
            if (token != null && HttpContext.Current.Session[token] != null)
            {
                operationResult = new OperationResult();
                operationResult.Success = true;
                operationResult.Message = "Authorized User";
                operationResult.MCode = MessageCode.OperationSuccessful;
                operationResult.Data = HttpContext.Current.Session[token];
            }
            else
            {
                operationResult = new OperationResult();
                operationResult.Success = false;
                operationResult.Message = "UnAuthorized User";
                operationResult.MCode = MessageCode.InvalidSession;
            }

            return operationResult;
        }
    }
}
