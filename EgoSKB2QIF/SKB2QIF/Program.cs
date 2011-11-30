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

            FileReader fr = new FileReader(args[0]);
            var lines = fr.ReadAllLines();


            //int i = 0;
            //lines.ForEach(a => Console.Out.WriteLine("Line {0}: {1}", i++,a));

            //Console.Out.WriteLine("\nSimpleSplit:\n");
            //lines.ForEach(l => Parse(l));

            
            ToQIF(lines, output);
        }

        private static void ToQIF(List<string> lines, IOutput output)
        {
            output.GenerateQifHeader();
            for (int i = 3; i < lines.Count-2; i++) //TODO: SKB specific!
            {
                QifLine qifLine = LineToQif(lines[i]);
                if (qifLine.Category.Equals("Transfer")) continue; //TODO: Skipping Transfers for now!
                output.GenerateEntry(qifLine);
            }
        }

        private static QifLine LineToQif(string line)
        {
            var item = line.Split(new char[] { '\t' });
            /*
                0: "BOKF?RINGSDATO"
                1: "RENTEDATO"
                2: "ARKIVREFERANSE"
                3: "TYPE"
                4: "TEKST"
                5: "UT FRA KONTO"
                6: "INN P? KONTO"
                7:
             */
            string date = item[0];
            string amount = item[5] == "" ? item[6] : string.Format("-{0}", item[5]);
            string payee = item[4].ToLower().Contains("meny") ? "Meny" : "Unknown";
            string number = item[2];
            string category = item[4].ToLower().Contains("meny") ? "Mat" : "Unknown";
            
            //if (item[3].ToLower().Contains("overf")) { 
            //    category = "Transfer";
            //    payee = "SKB Unspecified";
            //    Console.Out.WriteLine("TRANSFER: {0}", line);
            //}
            string message = item[4];

            date = date.Replace("\"", "");
            amount = amount.Replace("\"", "");
            payee = payee.Replace("\"", "");
            number = number.Replace("\"", ""); number = number.Replace("*", "0");
            category = category.Replace("\"", "");
            message = message.Replace("\"", "");

            QifLine qifLine = new QifLine(date, amount, payee, number, category, message);

            return qifLine;
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
