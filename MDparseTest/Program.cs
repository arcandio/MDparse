using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MDparse;

namespace MDparseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            // get file contents
            using (StreamReader sr = new StreamReader("test.md"))
            {
                file = sr.ReadToEnd();
                //MDparser mdp = new MDparser();
                string xaml = MDparser.GetXamlFromMD(file);
                Console.Write(xaml);

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
