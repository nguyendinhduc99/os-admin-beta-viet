using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BetaViet.Utility;

namespace System
{
    public static class Extensions
    {
        public static string ToSlug(this string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return string.Empty;
            string str = StringHelper.UnicodeUnSign(phrase).RemoveDiacritics().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 500 ? str.Length : 500).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveDiacritics(this string text)
        {
            var s = new string(text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            return s.Normalize(NormalizationForm.FormC);
        }

        public static string FormatDateTime(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy HH:mm");
        }

    }
}
