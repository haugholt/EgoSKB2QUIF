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
}
