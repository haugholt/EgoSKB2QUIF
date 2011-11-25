using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SKB2QIF.Core
{
    public class FileReader
    {
        public FileReader(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }

        public List<string> ReadAllLines(){
            return this.ReadAllLines(FileName);
        }

        private List<string> ReadAllLines(string fileName)
        {
            System.IO.FileInfo fifo = new FileInfo(fileName);

            List<string> lines = new List<string>();
            if (!fifo.Exists) return lines;

            using (StreamReader rea = new StreamReader(fileName, true))
            {
                while (!rea.EndOfStream)
                {
                    lines.Add(
                        rea.ReadLine());
                }
            }
            return lines;
        }
    }

}
