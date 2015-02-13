using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mobile.Infrastructure {
    public class KindleCapabilities : HttpCapabilitiesProvider {

        public override HttpBrowserCapabilities GetBrowserCapabilities(HttpRequest request) {
            HttpCapabilitiesDefaultProvider defaultProvider = new HttpCapabilitiesDefaultProvider();

            HttpBrowserCapabilities caps = defaultProvider.GetBrowserCapabilities(request);

            if (request.UserAgent.Contains("Silk")) {
                caps.Capabilities["Browser"] = "Silk";
                caps.Capabilities["IsMobileDevice"] = "true";
                caps.Capabilities["MobileDeviceManufacturer"] = "AmazonA";
                caps.Capabilities["MobileDeviceModel"] = "Kindle FireA";
                if (request.UserAgent.Contains("Kindle Fire HD")) {
                    caps.Capabilities["MobileDeviceModel"] = "Kindle Fire HD";
                }
            }
            return caps;
        }
    }
}