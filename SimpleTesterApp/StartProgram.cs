using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using SimpleTesterApp.InputData;

namespace SimpleTesterApp
{
	class StartProgram
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture

			string directory = InputDataProcessing.GetPathDirectory();
            string filename = InputDataProcessing.GetFilename();
            
			Console.WriteLine($"{directory} \n{filename}");
		}
	}
}
//Environment.NewLine