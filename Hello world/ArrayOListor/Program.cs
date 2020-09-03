using System;
using System.Collections.Generic;

namespace ArrayOListor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[5];

            var temp = names;

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Console.ReadLine();
            }
            
            Array.Reverse(temp);
            foreach (var name in temp)
            {
                Console.Write(name + " ");
            }
            Console.ReadKey();
        }
    }
}
