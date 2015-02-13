using System;
using System.Web;

namespace StateData.Infrastructure {

    public enum SessionStateKeys {
        NAME
    }

    public class SessionStateHelper {

        public static object Get(SessionStateKeys key) {
            string keyString = Enum.GetName(typeof (SessionStateKeys), key);
            return HttpContext.Current.Session[keyString];
        }

        public static object Set(SessionStateKeys key, object value) {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString] = value;
        }

    }
}