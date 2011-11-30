using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKB2QIF.Core
{
    internal class QifLine
    {
        public QifLine(string date, string amount, string payee, string number, string category, string message)
        {
            Date = date;
            Amount = amount;
            Payee = payee;
            Number = number;
            Category = category;
            Message = message;
        }

        /// <summary>
        /// Format: "2011-02-28"
        /// </summary>
        public string Date { get; private set; }
        /// <summary>
        /// Format: "-590,00"
        /// </summary>
        public string Amount { get; private set; }
        /// <summary>
        /// Default: "Unknown"
        /// Must probably scrape and generate this.
        /// </summary>
        public string Payee { get; private set; } /*Gen*/
        public string Number { get; private set; }
        /// <summary>
        /// Format for sub-category: "Travel:Food"
        /// </summary>
        public string Category { get; private set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string Message { get; private set; }

        /*
            D2011-02-28
            T-590,00
            PVarekjop
            N17017734769
            LUnknown
            M26.02 NARVESEN HOLMLIA SENT OSLO
        */
    }
}
