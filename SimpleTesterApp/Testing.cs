using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace SimpleTesterApp
{
	public static class Testing
	{
		public static void Start(string directory, StringBuilder testFilename, string testSubName, string testSubNumber, string testInputWord, string testOutputWord)
		{
            try
            {
				TextReader reader = null;
				string currentTestData = null;
                int numbLength = testSubNumber.Length;
                int currentSubNumber = int.Parse(testSubNumber);

				while (true)
				{
					//a.Looking for specific test file
					using (reader = new StreamReader(directory + testFilename))
					{
						 currentTestData = reader.ReadToEnd();
					}

					//b.Testing programs
					TestingMethod(currentTestData);

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

		private static void TestingMethod(string currentTestData)
		{
			
		}

		private static void ReturnInfoMessageToConsole(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
