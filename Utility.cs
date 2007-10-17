using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineStringFormatter
{
    /// <summary>
    /// Authored by Michael McKechney (www.mckechney.com)
    /// This code and program are fully and freely distrubutable.
    /// If you re-use code in your own applications, please reference this original work.
    /// Thanks and your feedback is welcomed and encouraged.
    /// </summary>
    class Utility
    {
        public static char[] GetDelimiter(string delimiterString)
        {
            char[] delimiter = null;
            switch (delimiterString.ToLower())
            {
                case "tab":
                    delimiter = new char[] { '\t' };
                    break;
                case "space":
                    delimiter = new char[] { ' ' };
                    break;
                case "comma":
                    delimiter = new char[] { ',' };
                    break;
                case "tilde":
                    delimiter = new char[] { '~' };
                    break;
                case "pipe":
                    delimiter = new char[] { '|' };
                    break;
                default:
                    delimiter = delimiterString.ToCharArray();
                    break;

            }
            return delimiter;
        }
    }
   

}
