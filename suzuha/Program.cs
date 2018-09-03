using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Globalization;
using System.Resources;

using suzuha.moth;
using suzuha.moth.FileTesting;
using suzuha.moth.Threading;

namespace suzuha
{
    class Program
    {
        static string programmName = "suzuha";
        static string programmVersion = "v 0.1";

        static void Main(string[] args)
        {
            PrintStartupMessage();
            // ThradingCodeMod();
            // StreamingCodeMode();

            var rm = new ResourceManager("suzuha.resources", typeof(resources.Resource).Assembly);
            Console.WriteLine(rm.GetString("introMessage"));

            Console.WriteLine("Nothing to do at the moment.");

            ProgammTerminatedPrompt();
        }


        /* Commandline IO */

        static void PrintUsage()
        {
            throw new NotImplementedException();
        }

        static void PrintHelp()
        {
            throw new NotImplementedException();
        }

        static void PrintStartupMessage()
        {
            Console.WriteLine(programmName + " " + programmVersion + "\n");
        }

        static void ProgammTerminatedPrompt()
        {
            Console.WriteLine("\nPress enter to end..");
            Console.ReadKey();
        }


        /* Code Modules */

        static void FileTestingCodeMod()     // unused ..
        {
            FileTesting.Testing();
        }

        static void ThradingCodeMod()
        {
            AkaThread.Execute();
        }

        static void StreamingCodeMode()
        {
            Streaming.Execute();
        }
    }
}
