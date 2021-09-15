using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Encyption
{
    public class AlphabetList
    {

        public static List<string> SCPNumber = new List<string>()
        {
            ".", "-", "~", "--", ">", ".>", "->", "~>", "-->", ">>", ".>>", ".>.>", "~>>", "->->", ">>>", ".>>>", "->>>", "~>>>",
            ".~>>>", "*", "*.", "*-", "*~", "*--", "*>", "*.>"
        };

    }

    public static class Extensions
    {
        public static K FindFirstKeyByValue<K, V>(this Dictionary<K, V> dict, V val)
        {
            return dict.FirstOrDefault(entry =>
                EqualityComparer<V>.Default.Equals(entry.Value, val)).Key;
        }
    }
}
