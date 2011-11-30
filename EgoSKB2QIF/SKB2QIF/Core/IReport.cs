using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKB2QIF.Core
{
    interface IReport
    {
        void WriteLine(string line);
    }

    interface IOutput
    {
        void GenerateQifHeader();
        void GenerateEntry(QifLine qifLine);
    }
}
