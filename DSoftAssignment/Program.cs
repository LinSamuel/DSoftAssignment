using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\sam\Documents\Visual Studio 2013\Projects\DSoftAssignment\input.txt");

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            Console.ReadKey();
        }
    }
}
