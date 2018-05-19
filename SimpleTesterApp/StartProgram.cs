using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace SimpleTesterApp
{
	class StartProgram
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture

			string directory = Input.GetPathDirectory();
            string filename = Input.GetFilename();
            
			Console.WriteLine($"{directory} \n{filename}");
		}
	}
}
//Environment.NewLine