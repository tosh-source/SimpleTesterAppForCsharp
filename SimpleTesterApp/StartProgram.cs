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
            
			Input.UserData();
            

			//var reader = new StringReader(directory + "FINENAME");
		}
	}
}
//Environment.NewLine