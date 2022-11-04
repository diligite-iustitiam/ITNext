using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace XUnitTests
{
    public class ViewTest
    {
        [Fact]
        public void TestIndexView()
        {
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();

        }
    }
}
