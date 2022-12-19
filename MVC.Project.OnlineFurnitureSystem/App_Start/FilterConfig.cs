using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
