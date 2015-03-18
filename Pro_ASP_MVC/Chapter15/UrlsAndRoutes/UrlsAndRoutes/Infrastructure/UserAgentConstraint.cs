﻿using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Infrastructure {
    public class UserAgentConstraint : IRouteConstraint {

        private string requiredUserAgent;

        public UserAgentConstraint(string requiredUserAgent) {
            this.requiredUserAgent = requiredUserAgent;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection) {
            return httpContext.Request.UserAgent != null &&
                   httpContext.Request.UserAgent.Contains(requiredUserAgent);
        }
    }
}