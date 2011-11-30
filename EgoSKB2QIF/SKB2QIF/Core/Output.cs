using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKB2QIF.Core
{
    

    class Output : IOutput
    {
        System.IO.TextWriter ut;
        string accountName = "Skb Visa";
        string accountType = "Checking";

        public Output()
        {
            ut = Console.Out;
        }

        public void GenerateQifHeader()
        {
            ut.WriteLine("!Account");
            ut.WriteLine("N{0}", accountName);
            ut.WriteLine("T{0}", accountType);
            Section();
            ut.WriteLine("!Type:{0}", "Cash");
        }

        private void Section()
        {
            ut.WriteLine("^");
        }

        public void GenerateEntry(QifLine qifLine)
        {
            /*
            D2011-02-28
            T-590,00
            PVarekjop
            N17017734769
            LUnknown
            M26.02 NARVESEN HOLMLIA SENT OSLO
            ^
            */
            ut.WriteLine("D{0}", qifLine.Date);
            ut.WriteLine("T{0}", qifLine.Amount);
            ut.WriteLine("P{0}", qifLine.Payee);
            ut.WriteLine("N{0}", qifLine.Number);
            ut.WriteLine("L{0}", qifLine.Category);
            ut.WriteLine("M{0}", qifLine.Message);
            Section();

        }
    }
}
