using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace suzuha.moth.Threading
{
    class AkaThread
    {
        internal static void Execute()
        {
            var akaThread = new AkaThread();
            akaThread.AkaExecute();
        }

        private void AkaExecute()
        {
            Console.WriteLine("Begin threading ..");
            var t1 = new Thread(new ParameterizedThreadStart(VariousProcedures.WriteHelloWorldTenTimes));
            t1.Start(500);
            t1.Join();
            Console.WriteLine("Ended threading ..");
        }
    }
}
