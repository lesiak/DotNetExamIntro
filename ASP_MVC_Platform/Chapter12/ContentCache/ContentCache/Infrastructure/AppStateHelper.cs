using System;
using System.Web;

namespace ContentCache.Infrastructure {

    public enum AppStateKeys {
        INDEX_COUNTER
    }
    
    public class AppStateHelper {
        public static int IncrementAndGet(AppStateKeys key) {
            string keyString = Enum.GetName(typeof (AppStateKeys), key);
            HttpApplicationState appState = HttpContext.Current.Application;
            int val = (int) (appState[keyString] ?? 0) + 1;            
            return (int) (appState[keyString] = val);

        }
    }
}