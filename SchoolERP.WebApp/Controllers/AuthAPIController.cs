//-----------------------------------------------------------------------
// <copyright file="AuthAPIController.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.WebApp.Controllers
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;
    using SchoolERP.Business.DTO;
    using SchoolERP.DTO;
    using SchoolERP.Framework.Exception;
    using SchoolERP.Framework.Logging;

    /// <summary>
    /// 
    /// </summary>
    public class AuthAPIController : BaseApiController
    {
        /// <summary>
        /// Login API to verify the login credentials
        /// </summary>
        /// <param name="user">The User</param>
        /// <returns>
        /// HttpResponseMessage as the return type for our method  will now “CreateResponse”
        /// that will return the User data  and Token with  “HttpStatusCode.OK”
        /// </returns>
        [HttpPost]
        [Route("api/authorization/login/")]
        public HttpResponseMessage Login([FromBody]UserDTO user)
        {
            try
            {
                OperationResult operationResult = new OperationResult();
            

                return this.Request.CreateResponse(HttpStatusCode.OK, operationResult, "text/json");
            }

            catch (SchoolERPException exception)
            {
                LogUtilities.LogException(exception, LogPriorityID.High, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
                return this.Request.CreateResponse(HttpStatusCode.OK, exception.Result, "text/json");
            }
            catch (Exception exception)
            {
                LogUtilities.LogException(exception, LogPriorityID.High, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
                return this.GetExceptionAsJsonResponse(exception);
            }
        }
    }
}
