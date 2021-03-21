using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Target19_Relationship.Services
{
    public class Pluralize//単数形と複数形の変換
    {
        public static string Plural(string str)//単数形を複数形にする
        {
            if (Regex.IsMatch(str, "[^aiueo]y$"))
            {
                return Regex.Replace(str, "y$", "ies");
            }
            return str + "s";
        }
    }
}