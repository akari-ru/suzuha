using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace suzuha.moth.Threading
{
    static class VariousProcedures
    {
        internal static void WriteHelloWorldTenTimes(object pause)
        {
            var sleepPause = (int) pause;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hello Wolrd");
                Thread.Sleep(sleepPause);
            }
        }
    }
}
