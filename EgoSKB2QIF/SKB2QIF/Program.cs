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
            Encoding enc = Encoding.GetEncoding(28591);

            IOutput output = new Output();
            IReport report = new Reporter();
            if (args.Length > 1)
            {
                output = new FileOutput(args[1]);

                //for (int i = 0; i < args.Length; i++)
                //{
                //    Console.Out.WriteLine("{0}: {1}", i, args[i]);
                //}
                //return;
            }

            FileReader ruleFile = new FileReader("rules.txt");
            var rules = ruleFile.ReadAllLines();

            var ruleInvoker = new Core.Rules(rules);

            FileReader fr = new FileReader(args[0]);
            var lines = fr.ReadAllLines();


            //int i = 0;
            //lines.ForEach(a => Console.Out.WriteLine("Line {0}: {1}", i++,a));

            //Console.Out.WriteLine("\nSimpleSplit:\n");
            //lines.ForEach(l => Parse(l));


            ToQIF(lines, output, ruleInvoker);
        }

        private static void ToQIF(List<string> lines, IOutput output, Rules rules)
        {
            output.GenerateQifHeader();
            for (int i = 3; i < lines.Count-2; i++) //TODO: SKB specific!
            {
                QifLine qifLine = LineToQifService.LineToQif(lines[i], rules);
                if (qifLine.Category.Equals("Transfer")) continue; //TODO: Skipping Transfers for now!
                output.GenerateEntry(qifLine);
            }
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
