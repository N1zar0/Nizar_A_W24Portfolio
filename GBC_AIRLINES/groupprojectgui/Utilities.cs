using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    public class Utilities
    {
        public void changeLine(string newString, string fileName, int lineNum)
        {
            string[] readFile = File.ReadAllLines(fileName);
            readFile[lineNum] = newString;
            File.WriteAllLines(fileName, readFile);
        }
    }
}
