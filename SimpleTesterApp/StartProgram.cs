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

            var directory = getUserInputParameters.GetPathDirectory;
			var testFilename = new StringBuilder(
				                     getUserInputParameters.GetFullFilename);
            //var testSubName = getUserInputParameters.GetSubFilename;
            var testSubNumber = getUserInputParameters.GetFileNumber;
            var testInputWord = getUserInputParameters.GetTestInputWord;
            var testOutputWord = getUserInputParameters.GetTestOutputWord;

            //Testing
            Testing.Start(directory, testFilename, testSubNumber, testInputWord, testOutputWord);
        }
    }
}
//Environment.NewLine