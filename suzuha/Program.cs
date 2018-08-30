using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using suzuha.moth;
using suzuha.moth.FileTesting;

namespace suzuha
{
    class Program
    {
        public static void PrintSomething(object state)
        {
            Console.WriteLine("We're gonna farm forever..");
        }

        static void Main(string[] args)
        {
            //Moth.PrintTitle();
            //Moth.PrintMessage();
            //var moth = new Moth();
            //moth.StartNewGame();

            //var p = new Program();
            //TimerCallback callback = new TimerCallback(PrintSomething);
            //var timer_kun = new Timer(callback, null, 0, 1000);

            //Thread.Sleep(1000 * 10);
            //timer_kun.Dispose();
            //Thread.Sleep(1000 * 5);
            //Console.WriteLine("Press enter to end..");
            //Console.ReadKey();

            FileTesting.Testing();
            Console.ReadKey();
        }
    }
}
