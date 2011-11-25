using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKB2QIF.Core;

namespace SKB2QIF
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fr = new FileReader(args[0]);
            var lines = fr.ReadAllLines();

            int i = 0;
            lines.ForEach(a => Console.Out.WriteLine("{0}: {1}", i++,a));

            Console.Out.WriteLine("\nSimpleSplit:\n");

            lines.ForEach(l => Parse(l));
        }

        private static void Parse(string l)
        {
            var sl= l.Split(new char[]{'\t'});

            for (int i = 0; i < sl.Length; i++)
            {
                Console.Out.WriteLine("{0}: {1}", i, sl[i]);
            }

            Console.Out.WriteLine();
        }
    }
}
