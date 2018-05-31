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
			//Input parameters and settings.
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture
			InputDataGetter getUserInputParameters = new InputDataGetter();

			string directory = getUserInputParameters.GetPathDirectory;
			string testFilename = getUserInputParameters.GetFullFilename;
			string testSubName = getUserInputParameters.GetSubFilename;
			string testSubNumber = getUserInputParameters.GetFileNumber;
			string testInputWord = getUserInputParameters.GetTestInputWord;
			string testOutputWord = getUserInputParameters.GetTestOutputWord;

		}
	}
}
//Environment.NewLine