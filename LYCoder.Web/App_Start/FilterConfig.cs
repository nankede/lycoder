
using LYCoder.Web.Controllers;
using System.Web;
using System.Web.Mvc;

namespace LYCoder.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorCheckedAttribute());  
        }
    }
}