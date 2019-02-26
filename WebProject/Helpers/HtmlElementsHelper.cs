using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Helpers
{
    public static class HtmlElementsHelper
    {
        public static MvcHtmlString PicURLHelper(this HtmlHelper helper, string URL, int width, int height)
        {
            return new MvcHtmlString($"<img src=\"{URL}\" width=\"{width}\" height=\"{height}\">");
        }

        public static MvcHtmlString PicBase64(this HtmlHelper helper, byte[] image, int width, int height)
        {
            var dataUrl = $"data:image;base64,{Convert.ToBase64String(image)}";
            return new MvcHtmlString($"<img src=\"{dataUrl}\" width=\"{width}\" height=\"{height}\">");
        }

        public static MvcHtmlString TimeOfDay(this HtmlHelper helper)
        {
            var currentHour = DateTime.Now.Hour;

            if (currentHour < 6 || currentHour > 22)
                return new MvcHtmlString("Night");

            if (currentHour < 12)
                return new MvcHtmlString("Morning");

            if (currentHour < 18)
                return new MvcHtmlString("Day");

            return new MvcHtmlString("Evening");
            
        }

        //public static MvcHtmlString GetAndGreetUser(this HtmlHelper helper, User user)
        //{
        //    var time = DateTime.Now.Hour;

        //    time = DateTime.Now.Hour;

        //    if (time < 12)
        //    {
        //        return MvcHtmlString("Good Morning ");
        //    }

        //    else if (time > 12 && time < 17)
        //    {
        //        return "Good Afternoon ";
        //    }

        //    else
        //    {
        //        return "Good Evening ";
        //    }
        //}
    }
}