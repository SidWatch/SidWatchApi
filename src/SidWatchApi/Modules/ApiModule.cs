using System;
using System.Collections.Generic;
using System.Linq;
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