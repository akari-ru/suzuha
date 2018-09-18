using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Resources;

using suzuha.arc;
using suzuha.moth.FileTesting;
using suzuha.moth.Threading;
using suzuha.Arcane;

namespace suzuha
{
    class Program
    {
        static string programmName = "suzuha";
        static string programmVersion = "v 0.1";

        static class ProgramControlContext
        {
            static bool threading = false;
            static bool game = false;
            static bool fileTesting = false;
            static bool kara = false;
            static bool arcane = false;

            static string filePath = null;

            public static bool FileTesting { get => fileTesting; set => fileTesting = value; }
            public static bool Threading { get => threading; set => threading = value; }
            public static bool Game { get => game; set => game = value; }
            public static bool Kara { get => kara; set => kara = value; }
            public static bool Arcane { get => arcane; set => arcane = value; }

            public static string FilePath { get => filePath; set => filePath = value; }
            
        }

        static void Main(string[] args)
        {
            PrintStartupMessage();
            SetUpProgramControlContext(args);
            if (ProgramControlContext.Threading)
                ThradingCodeMod();
            if (ProgramControlContext.FileTesting)
                FileTestingCodeMod();
            if (ProgramControlContext.Game)
                GameCodeMod();
            if (ProgramControlContext.Kara)
                KaraCodeMod();
            if (ProgramControlContext.Arcane)
                ArcaneCodeMod();
            ProgammTerminatedPrompt();
        }


        /* Commandline IO */

        static void PrintUsage()
        {
            var res = new ResourceManager("suzuha.strings.Resources", typeof(Program).Assembly);
            var usageString = res.GetString("usage");
            Console.WriteLine(usageString);
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

        static void PrintCultureInfo()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            Console.WriteLine(ci.EnglishName);
            Console.WriteLine(ci.DisplayName);
            Console.WriteLine(ci.IsNeutralCulture);
            Console.WriteLine(ci.Name);
        }


        /* Ground Tasks */

        static void SetUpProgramControlContext(string[] args)
        {
            Console.WriteLine("Arc parsing..");
            foreach (var arg in args)
            {
                Console.Write(arg + " ");
            }
            Console.WriteLine();
            var arc = new Arc(args, "f:tgka", "[file]:[threading][game][kara][file][arcane]");
            List<Tuple<string, string>> parsed;
            try
            {
                parsed = arc.Parse();
            }
            catch (ArcParsingException e)
            {
                Console.WriteLine(e.Message);
                PrintUsage();
                ProgammTerminatedPrompt();
                return;
            }

            // todo: Remove Console Output
            //-----------------------------
            foreach (var tupel in parsed)
            {
                Console.WriteLine(tupel);
            }
            //-----------------------------

            foreach (var tupel in parsed)
            {
                switch (tupel.Item1)
                {
                    case "f":
                    case "file":
                        if (!ProgramControlContext.FileTesting)
                        {
                            ProgramControlContext.FileTesting = true;
                            ProgramControlContext.FilePath = tupel.Item2;
                        }
                        else
                        {
                            throw new Exception("File flag override prohibited.");
                        }
                        break;
                    case "g":
                    case "game":
                        ProgramControlContext.Game = true;
                        break;
                    case "t":
                    case "threading":
                        ProgramControlContext.Threading = true;
                        break;
                    case "k":
                    case "kara":
                        ProgramControlContext.Kara = true;
                        break;
                    case "a":
                    case "arcane":
                        ProgramControlContext.Arcane = true;
                        break;
                    default:
                        throw new Exception("Invalid Flag Init.");
                }
            }
        }
        
        
        /* Code Modules */

        static void FileTestingCodeMod()     // unused ..
        {
            FileTesting.Testing();
        }

        static void GameCodeMod()
        {
            
        }

        static void KaraCodeMod()
        {

        }

        static void ThradingCodeMod()
        {
            AkaThread.Execute();
        }

        static void StreamingCodeMod()
        {
            Streaming.Execute();
        }

        static void ArcaneCodeMod()
        {
            Arcane.Arcane.Execute();
        }
    }
}
