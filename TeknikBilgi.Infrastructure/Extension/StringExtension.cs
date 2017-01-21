using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TeknikBilgi.Infrastructure.Constraints.Enums;

namespace TeknikBilgi.Infrastructure.Extension
{
    public static class StringExtension
    {
        public static string ReplaceTrChars(this string value)
        {
            value = value.Replace("ş", "s");
            value = value.Replace("ı", "i");
            value = value.Replace("ö", "o");
            value = value.Replace("ü", "u");
            value = value.Replace("ç", "c");
            value = value.Replace("ğ", "g");
            value = value.Replace("Ş", "S");
            value = value.Replace("İ", "I");
            value = value.Replace("Ö", "O");
            value = value.Replace("Ü", "U");
            value = value.Replace("Ç", "C");
            value = value.Replace("Ğ", "G");

            return value;
        }

        public static bool IsNullOrWhiteSpace(this string theString)
        {
            return string.IsNullOrWhiteSpace(theString);
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input) || input.Trim() == string.Empty;
        }

        public static string RemoveSpecialChars(this string val)
        {
            val = ReplaceTrChars(val);
            var reg = new Regex(@"([^a-zA-Z0-9\--])", RegexOptions.Compiled | RegexOptions.Multiline);
            val = reg.Replace(val, string.Empty);
            return val;
        }
        public static string ReplaceSpecialChars(this string val, string replaceText)
        {
            val = ReplaceTrChars(val);
            var reg = new Regex(@"([^a-zA-Z0-9\--])", RegexOptions.Compiled | RegexOptions.Multiline);
            val = reg.Replace(val, replaceText);
            return val;
        }

        public static string Left(this string str, int size)
        {
            return !string.IsNullOrEmpty(str)
                       ? (str.Length > size ? str.Substring(0, size) : str)
                       : string.Empty;
        }

        public static string Right(this string str, int size)
        {
            return !string.IsNullOrEmpty(str)
                       ? (str.Length > size ? str.Substring((str.Length - size), size) : str)
                       : string.Empty;
        }

        public static bool IsNumeric(this string val)
        {
            long retNum;
            return long.TryParse(val, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out retNum);
        }

        public static bool IsDate(this string val)
        {
            if (string.IsNullOrEmpty(val)) return false;
            DateTime dt;
            return (DateTime.TryParse(val, out dt));
        }

        //refactored from UtilityTestFixture.
        public static string ReplaceSequenceChars(this string str, char chReplace)
        {
            var strNew = new StringBuilder();
            var strLength = str.Length;
            if (strLength <= 1)
                return str;

            strNew.Append(str[0]);
            for (var i = 1; i < strLength; i++)
            {
                if (str[i] == chReplace && strNew.ToString().Last() == chReplace)
                    continue;
                strNew.Append(str[i]);
            }
            return strNew.ToString();
        }
        public static string ReplaceSequenceChars(this string str)
        {
            var strNew = string.Empty;
            var strLength = str.Length;
            if (strLength <= 1)
                return str;

            strNew += str[0];
            for (int i = 1; i < strLength; i++)
            {
                if (str[i] == strNew.Last())
                    continue;
                strNew += str[i];
            }
            return strNew;
        }

        public static string EscapeName(this string strTitle)
        {
            if (string.IsNullOrEmpty(strTitle))
                return string.Empty;
            var result = strTitle.ToLower().ReplaceSpecialChars("-").Replace(" ", "-").ReplaceSequenceChars('-').Trim().Trim('-');
            return result;
        }

        public static string ToXmlCData(this string input)
        {
            return string.Format("<![CDATA[{0}]]>", input);
        }

        public static int? ToNullableInt32(this string s)
        {
            int i;
            return int.TryParse(s, out i) ? (int?)i : null;
        }

        public static long? ToNullableLong(this string s)
        {
            long i;
            return long.TryParse(s, out i) ? (long?)i : null;
        }

        public static string RemoveHtmlTags(this string input)
        {
            return Regex.Replace(input, "<.+?>", string.Empty);
        }
        public static string ReplaceHexadecimalSymbols(this string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return "";
            //string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            string r = "[\x00-\x08]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled);
        }

        public static string UpperCase(this string value, Languages languages)
        {
            switch (languages)
            {
                case Languages.Turkish:
                    value = value.ToUpper(new CultureInfo("tr-TR"));
                    break;
                case Languages.English:
                    value = value.ToUpper(new CultureInfo("en-US"));
                    break;
                case Languages.Deutsch:
                    value = value.ToUpper(new CultureInfo("de-DE"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(typeof(Languages).Name, languages, null);
            }
            return value;
        }
    }
}