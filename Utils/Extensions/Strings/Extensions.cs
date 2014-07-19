using System.Text;
using System.Text.RegularExpressions;

namespace Utils.Extensions.Strings
{
    public static class Extensions
    {
        public static string Repeat(this string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
                sb.Append(source);

            return sb.ToString();
        }

        #region AddSlashes
        private static Regex AddSlashesRegex = new Regex(@"[\000\010\011\012\015\032\042\047\134\140]", RegexOptions.Compiled);

        /// <summary>
        /// Returns a string with backslashes before characters that need to be quoted
        /// </summary>
        /// <param name="InputTxt">Text string need to be escape with slashes</param>
        public static string AddSlashes(this string InputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent
            return AddSlashesRegex.Replace(InputTxt, "\\$0");
        }
        #endregion
    }
}
