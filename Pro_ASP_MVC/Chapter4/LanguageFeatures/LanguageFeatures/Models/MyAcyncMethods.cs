using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models {
    public class MyAcyncMethods {
        public async static Task<long?> GetPageLength() {

            HttpClient client = new HttpClient();

            var httpTask = client.GetAsync("http://apress.com");
            var httpMessage = await httpTask;

            // we could do other things here while we are waiting 
            // for the HTTP request to complete
            return httpMessage.Content.Headers.ContentLength;
        } 
    }
}