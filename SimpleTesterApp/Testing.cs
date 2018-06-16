using System;
using System.IO;
using System.Text;
using System.Linq;

namespace SimpleTesterApp
{
	public static class Testing
	{
		public static void Start(string directory, StringBuilder testFilename, string testSubName, string testSubNumber, string testInputWord, string testOutputWord)
		{
			TextReader reader = null;
			int numbLength = testSubNumber.Length;

			try
			{
				int currentSubNumber = int.Parse(testSubNumber);

				while (true)
				{
					//testing programs
					using (reader = new StreamReader(directory + testFilename))
					{
						string currentTestData = reader.ReadToEnd();
					}

					//Replace old number with (increased) new one and fill with zeros. 
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

		private static void ReturnInfoMessageToConsole(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
