using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;

namespace SimpleTesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture
           
            //input
            Console.WriteLine("Take test files from current directory..? (Y/n)");
            var choise = Console.ReadLine();

            var filePath = String.Empty;
            if (choise == "N" || choise == "n")
            {
                EnterNewPath(filePath);
            }




            var reader = new StringReader(filePath + "FINENAME");


            //run tests
            //for (int i = 0; i < length; i++)
            //{

            //}
			
            //Environment.NewLine
        }

        private static void EnterNewPath(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
