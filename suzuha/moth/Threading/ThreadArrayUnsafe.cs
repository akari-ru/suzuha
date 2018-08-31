using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suzuha.moth.Threading
{
    class ThreadArrayUnsafe
    {
        private static int[] array = new int[20];

        static ThreadArrayUnsafe()
        {
            for(int i = 0; i < 20; i++)
            {
                array[i] = 0;
            }

        }

        internal static void incrementAllFields()
        {
            for (int f = 0; f < 100; f++)
            { 
                for (int i = 0; i < 20; i++)
                {
                    array[i] += 1;
                    System.Threading.Thread.Sleep(2);
                }
            }
        }

        internal static void printAllFields()
        {
            for (int f = 0; f < 100; f++)
            {
                foreach (var i in array)
                {
                    Console.Write("" + i + " ");
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
