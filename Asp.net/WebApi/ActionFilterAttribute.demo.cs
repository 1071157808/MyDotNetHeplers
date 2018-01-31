using System.Collections.Generic;
using System.Linq;
usingSystem.Net;
usingSystem.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
namespace MyApi.Filters {
    public class ValidateModelAttribute : ActionFilterAttribute {
        public override void OnActionExecuting (HttpActionContext actionContext) {
            if (actionContext.ModelState.IsValid == false) {
                actionContext.Response = actionContext.Request.CreateErrorResponse (
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}

public static class WebApiConfig {
    public static void Register (HttpConfiguration config) {
        config.Filters.Add (new ValidateModelAttribute ());
        // ...
    }
}

public class ProductsController : ApiController {
    [ValidateModel]
    public HttpResponseMessage Post (Product product) {
        // ...
    }
}


