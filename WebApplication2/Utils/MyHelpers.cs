using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Utils
{
    public static class MyHelpers
    {
        public static IHtmlString MyTestHelper(string str)
        {
            string inputTest = $"<input style=\"background-color:{str};\"></input>";
            return new HtmlString(inputTest);
        }
        public static IHtmlString MyTestHelper(this HtmlHelper helper,string str)
        {
            string inputTest = $"<input style=\"background-color:{str};\"></input>";
            return new HtmlString(inputTest);
        }
    }
}