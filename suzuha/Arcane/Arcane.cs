using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace suzuha.Arcane
{
    class Arcane
    {
        private static string Text { get; set; } = "Far away the dark towers calling upon their victims, fallen ones from the crimson realm.";

        internal static void Execute()
        {
            var pattern = "(ll)[ie]";
            var regex = new Regex(pattern);

            Console.WriteLine("Arcane - Testing Regular Expressions (Regex)");
            Console.WriteLine("Input:\n" + Text + "\nPattern:\n" + pattern);

            MatchCollection matches = regex.Matches(Text);
            Console.WriteLine("" + matches.Count + " matches found.");
            foreach (Match match in matches)
            {
                Console.WriteLine("(" + match.Success + ")" + match.Value);
            }
        }
    }
}
