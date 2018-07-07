using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Secure1API.Models
{
    public static class DTHelp
    {
        public static string ParseTime(DateTime time)
        {
            var dateString = time.ToString();

            var dateTimeT = dateString.IndexOf(" ");

            var p = dateString.Substring(dateTimeT + 1);

            return p;
        }

        public static string ParseDate(DateTime date)
        {
            var dateString = date.ToString();

            var dateTimeT = dateString.IndexOf(" ");

            return dateString.Substring(0, dateTimeT);
        }
    }
}