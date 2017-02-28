using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    //Helper class that helps get the current directory to identify location of the input file
    public class GetCurrDirectoryClass
    {
        string currDirectory = "";
        public GetCurrDirectoryClass()
        {

        }

        public string getCurrDirectory(){
            this.currDirectory = System.IO.Directory.GetCurrentDirectory();
            return this.currDirectory;
        }
    }
}
