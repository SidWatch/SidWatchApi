using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Nancy;
using Sidwatch.Library.Objects;
using SidWatchApi.Extensions;
using SidWatchApi.Helpers;
using SidWatchApi.ResponseObjects;

namespace SidWatchApi.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get["/api/authorize"] = _parameters => Response.AsError(HttpStatusCode.MethodNotAllowed, null);

            Post["/api/authorize"] = _parameters =>
            {
                BaseResponse br = Authorize(_parameters);
                return Response.AsSuccess(br);
            };

            Get["/api/stations"] = _parameters =>
            {
                return null;
            };

            Get["/api/sites"] = _parameters =>
            {
                return null;
            };

            Get["/api/sites/{siteid}/spectrum/latest"] = _parameters =>
            {
                return null;
            };

            Get["/api/sites/{siteid}/spectrum/{start}/{end}"] = _parameters =>
            {
                return null;
            };
        }

        private BaseResponse Authorize(
            DynamicDictionary _parameters)
        {
            User user;
            BaseResponse response = AuthHelper.Authorize(Request, out user);
            return response;
        }
    }
}