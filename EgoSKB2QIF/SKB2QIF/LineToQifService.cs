using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKB2QIF.Core;

namespace SKB2QIF
{
    static class LineToQifService
    {
        public static QifLine LineToQif(string line, Rules rules)
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
            
            string number = item[2];

            string payee = "";
            string category = "" ;
            if (item[3].ToLower().Contains("overføring"))
            {
                category = "Transfer";
                payee = "SKB Unspecified";
                //Console.Out.WriteLine("TRANSFER: {0}", line);
                //throw new NotImplementedException(line);
            }
            else{
                category = rules.FindCategory(item[4]);
                payee = rules.FindPayee(item[4]);
            }
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

    }
}
