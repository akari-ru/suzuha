using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace suzuha.moth.FileTesting
{
    class Streaming
    {
        internal static void Execute()
        {
            int[] array;
            int arrayLength = 20;
            array = new int[arrayLength];


            Console.WriteLine("Initializing array with fibonacci numbers, up to " + arrayLength + " numbers.");
            array[0] = 0;
            array[1] = 1;
            for (int f = 2; f < arrayLength; f++)
            {
                var n = array[f - 1] + array[f - 2];
                Console.WriteLine(n);
                array[f] = n;
            }
            Console.WriteLine("Creating file and writing the array with StreamWriter ..");
            string filepath = @"C:\\Users\akari\Desktop\fibo.txt";
            if (!File.Exists(filepath))
                File.CreateText(filepath);
            using (var stream = new StreamWriter(filepath))
            {
                for (int f = 0; f < arrayLength; f++)
                {
                    stream.Write(array[f]);
                    stream.Write(" ");
                }
            }
            Console.WriteLine("Finished writing ...");
        }
    }
}
