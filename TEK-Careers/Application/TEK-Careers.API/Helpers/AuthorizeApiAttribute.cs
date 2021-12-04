using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TEK_Careers.API.Helpers
{
    public class AuthorizeApiAttribute : AuthorizeAttribute
    {

        #region Overriden Methods
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (AuthorizeRequest(actionContext))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        #endregion

        #region Private Methods
        private bool AuthorizeRequest(HttpActionContext actionContext)
        {
            try
            {
                var token = ConfigurationManager.AppSettings["token"];
                IEnumerable<string> headers;
                var checkApiKeyExists = actionContext.Request.Headers.TryGetValues("Auth-Token", out headers);

                if (checkApiKeyExists)
                {
                    if (headers.FirstOrDefault().Equals(token))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}