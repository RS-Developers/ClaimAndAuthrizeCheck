using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace TeamTreeHouses.Tools
{
    public class HTMLLog : ActionFilterAttribute
    {
        /*** Private Part ***/
        private HttpWriter _HttpWriter;
        private StringWriter _StringWriter;
        private StringBuilder _StringBuilder;
        private HtmlTextWriter _HtmlTextWriter;

        /*** Public Part ***/
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string lResponse = _StringBuilder.ToString();
            //response processing
            _HttpWriter.Write(lResponse);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _StringBuilder = new StringBuilder();
            _StringWriter = new StringWriter(_StringBuilder);
            _HtmlTextWriter = new HtmlTextWriter(_StringWriter);
            _HttpWriter = (HttpWriter)filterContext.RequestContext.HttpContext.Response.Output;
            filterContext.RequestContext.HttpContext.Response.Output = _HtmlTextWriter;
        }
    }
}