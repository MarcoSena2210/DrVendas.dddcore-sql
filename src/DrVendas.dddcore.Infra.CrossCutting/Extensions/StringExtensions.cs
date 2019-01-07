using System;
using System.Linq;

namespace DrVendas.dddcore.Infra.CrossCutting.Extensions
{
    public static class StringExtensions
    {

        public static string SomenteNumeros(this string strIn)
        {
            if (strIn != null)
            {
                var somentenumeros = new String(strIn.Where(c => Char.IsDigit(c)).ToArray());
                return somentenumeros;
            }
            return "";
        }

        public static string SomenteLetras(this string strIn)
        {
            if (strIn != null)
            {
                var somenteletras = new String(strIn.Where(c => Char.IsLetter(c)).ToArray());
                return somenteletras;
            }
            return "";
        }


    }
}
