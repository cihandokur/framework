using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TeknikBilgi.Infrastructure.Extension;

namespace TeknikBilgi.Infrastructure.Util
{
    public static class Utility
    {
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static string GetDisplayFromEnumValue(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() as DisplayAttribute;
            return attribute == null ? value.ToString() : attribute.Name;

        }

        public static List<KeyValuePair<string, int>> GetEnumList<T>()
        {
            return (from object e in Enum.GetValues(typeof(T)) select new KeyValuePair<string, int>(GetDisplayFromEnumValue((Enum)e), (int)e)).ToList();
        }

        public static string EscapeNameMobile(string strTitle)
        {
            //Trim Start and End Spaces. 
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen 
            strTitle = strTitle.Trim('-');

            strTitle = strTitle.ToLower();
            var chars = @"$%#@!*?;:~`+=()[]{}|\'’“<>,/^&"".".ToCharArray();

            //Replace . with - hyphen 
            strTitle = strTitle.Replace(".", "-")
                .Replace("“", "")
                .Replace("”", "")
                .Replace("‘", "")
                .Replace("’", "");


            //Replace Special-Characters 
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, String.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen 
            strTitle = strTitle.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen. 
            strTitle = strTitle.ReplaceSequenceChars('-');

            //Run the code again... 
            //Trim Start and End Spaces. 
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen 
            strTitle = strTitle.Trim('-');

            //Replace Turkish characters
            strTitle = strTitle.ReplaceTrChars();

            return strTitle;
        }

        public static string EscapeName(string strTitle)
        {
            if (string.IsNullOrWhiteSpace(strTitle))
                return string.Empty;

            if (string.IsNullOrWhiteSpace(strTitle))
                return string.Empty;

            strTitle = strTitle.Trim();
            strTitle = Regex.Replace(strTitle, @"[^\w\@-]", "-").ToLower();
            var replacements = new Dictionary<string, string>
            {
                {"ğ", "g"},
                {"ü", "u"},
                {"ş", "s"},
                {"ı", "i"},
                {"ö", "o"},
                {"ç", "c"},
                {"â", "a"},
                {" ", "-"},
                {"--", "-"}
            };

            strTitle = replacements.Keys.Aggregate(strTitle, (current, key) => Regex.Replace(current, key, replacements[key]));
            while (strTitle.IndexOf("--", StringComparison.Ordinal) > -1)
                strTitle = strTitle.Replace("--", "-");


            if (strTitle.EndsWith("-"))
            {
                strTitle = strTitle.Substring(0, strTitle.Length - 1);

            }
            if (strTitle.StartsWith("-"))
            {
                strTitle = strTitle.Substring(1, strTitle.Length - 1);
            }
            return strTitle;
        }

        public static string ReplaceHexadecimalSymbols(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return "";
            //string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            string r = "[\x00-\x08]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled).ToString();
        }

        public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
            }
            var result = builder.ToString();
            result = result.RemoveSpecialChars();
            return lowerCase ? result.ToLower(new CultureInfo("en-US")) : result;
        }

        public static string GetCurrentIp()
        {
            if (HttpContext.Current == null) return "";
            string requestIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(requestIp))
            {
                requestIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return requestIp;
        }
    }
}