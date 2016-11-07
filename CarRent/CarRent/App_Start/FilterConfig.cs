using System.Web;
using System.Web.Mvc;

namespace CarRent
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PrintFilter());
        }
    }

    public class PrintFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.RouteData.Values.ContainsValue("print"))
            {
                var oldView = filterContext.Result as ViewResult;
                if (oldView != null)
                {
                    var viewName = oldView.ViewName.Length == 0 ?
                        filterContext.ActionDescriptor.ActionName : oldView.ViewName;

                    filterContext.Result = new ViewResult()
                    {
                        ViewData = oldView.ViewData,
                        MasterName = oldView.MasterName,
                        ViewName = string.Format("Print/{0}", viewName)
                    };
                }
            }
        }
       
    }
}
