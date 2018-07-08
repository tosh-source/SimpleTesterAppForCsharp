using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace SimpleTesterApp
{
	public static class Testing
	{
		public static void Start(string directory, StringBuilder testFilename, string testSubNumber, string testInputWord, string testOutputWord)
		{
            try
            {
				TextReader reader = null;
				string currentTestDoc = null;
                int numbLength = testSubNumber.Length;
                int currentSubNumber = int.Parse(testSubNumber);

				while (true)
				{
					//a.Looking for specific test file
					using (reader = new StreamReader(directory + testFilename))
					{
						 currentTestDoc = reader.ReadToEnd();
					}

					//b.Testing programs
					TestingMethod(currentTestDoc, directory, testFilename);

					//c.Replace old number with (increased) new one and fill with zeros. 
					testFilename.Replace(currentSubNumber.ToString().PadLeft(numbLength, '0'),
										  (++currentSubNumber).ToString().PadLeft(numbLength, '0'));
				}

			}
			catch (FileNotFoundException fnEx)
			{
				ReturnInfoMessageToConsole("\n" + fnEx.Message);
			}
			catch (Exception ex)
			{
				ReturnInfoMessageToConsole("\n" + ex.Message);
			}
		}

		private static void TestingMethod(string currentTestData, string directory, StringBuilder testFilename)
		{
			//TO DO: add on Input method functionality to grab name/directory to .exe program that need to b tested
			Process programToTest = new Process();

            try
			{
				programToTest.StartInfo.WorkingDirectory = directory;
				programToTest.StartInfo.FileName = testFilename.ToString();

			}
			catch (Exception ex)
			{

			}
		}

		private static void ReturnInfoMessageToConsole(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
