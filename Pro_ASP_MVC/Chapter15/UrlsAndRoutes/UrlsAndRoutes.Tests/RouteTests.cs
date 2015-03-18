using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UrlsAndRoutes.Tests {
    [TestClass]
    public class RouteTests {

        [TestMethod]
        public void TestIncomingRoutes() {

//            TestRouteMatch("~/", "Home", "Index");
         //   TestRouteMatch("~/Home", "Home", "Index");
         //   TestRouteMatch("~/Home/Index", "Home", "Index");

         //   TestRouteMatch("~/Home/About", "Home", "About");
         //   TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
         //   TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About", new { id = "MyId", catchall = "More/Segments" });

         //   TestRouteFail("~/Home/OtherAction");
        //    TestRouteFail("~/Account/Index");
        //    TestRouteFail("~/Account/About");
            
            /*TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Customer", "Customer", "Index");
            TestRouteMatch("~/Customer/List", "Customer", "List");
            TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            TestRouteMatch("~/Customer/List/All/Delete", "Customer", "List", new { id = "All", catchall="Delete" });
            TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List", new { id = "All", catchall = "Delete/Perm" });
            */
            //TestRouteFail("~/Customer/List/All/Delete");


            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");


            TestRouteMatch("~/Home/About", "Home", "About");
            TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
            TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About",
                new {
                    id = "MyId",
                    catchall = "More/Segments"
                });

            TestRouteFail("~/Home/OtherAction");
            TestRouteFail("~/Account/Index");
            TestRouteFail("~/Account/About");
        }

        private HttpContextBase CreateHttpContext(string targetUrl = null,
                                                  string httpMethod = "GET") {
            // create the mock request 
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(
                It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // return the mocked context
            return mockContext.Object;
        }
        
        private void TestRouteMatch(string url, string expectedController, string expectedAction,
            object expectedRouteProperties = null, string httpMethod = "GET") {

            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            // Act - process the route
            RouteData result
                = routes.GetRouteData(CreateHttpContext(url, httpMethod));
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, expectedController,
                expectedAction, expectedRouteProperties), "Error in url:" + url);
        }

        private bool TestIncomingRouteResult(RouteData routeResult,
            string controller, string action, object propertySet = null) {            

            bool result = isCompareEqualIgnoreCase(routeResult.Values["controller"], controller)
                && isCompareEqualIgnoreCase(routeResult.Values["action"], action);

            if (propertySet != null) {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo) {
                    if (!(RouteHasPropertyWithSameValue(routeResult, propertySet, pi))) {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private static bool isCompareEqualIgnoreCase(object v1, object v2) {
            return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
        }

        private static bool RouteHasPropertyWithSameValue(RouteData routeResult, object propertySet, PropertyInfo pi) {
            return routeResult.Values.ContainsKey(pi.Name)
                   && isCompareEqualIgnoreCase(routeResult.Values[pi.Name], pi.GetValue(propertySet, null));
        }

        private void TestRouteFail(string url) {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));
            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

       
        
    }
}
