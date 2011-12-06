using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKB2QIF.Core
{
    class Reporter : IReport
    {
        

        public void WriteLine(string line)
        {
            Console.Out.WriteLine(line);
        }

        public void WriteLine(string format, params object[] arg)
        {
            Console.Out.WriteLine(format, arg);
        }
        
    }

    class DelayReporter : IReport
    {
        private List<string> lines;

        public DelayReporter()
        {
            lines = new List<string>();
        }

        public void WriteLine(string line)
        {
            lines.Add(line);
            //Console.Out.WriteLine(line);
        }

        public void WriteLine(string format, params object[] arg)
        {
            lines.Add(string.Format(format, arg));
            //Console.Out.WriteLine(format, arg);
        }

        public void ReportAll()
        {
            foreach (var line in lines)
            {
                Console.Out.WriteLine(line);
            }
        }

    }
}
