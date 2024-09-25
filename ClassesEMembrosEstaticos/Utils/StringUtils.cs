using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesEMembrosEstaticos.Utils
{
    internal static class StringUtils
    {
        public static bool ValidateIgnoreCase(string str1, string str2)
        {
            return str1.ToLower().Equals(str2.ToLower());
        }

        public static string BuildFancyTitle(string nome)
        {
            var sep = new string('#', 50);
            return $"{sep}\n{nome.ToUpper()}\n{sep}";
        }
    }
}
