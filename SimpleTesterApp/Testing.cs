using System;
using System.IO;
using System.Text;
using System.Linq;

namespace SimpleTesterApp
{
	public static class Testing
	{
		public static void Start(string directory, string testFilename, string testSubName, StringBuilder testSubNumber, string testInputWord, string testOutputWord)
		{
			TextReader reader = null;
			int numbLength = testSubNumber.Length;

			try
			{
				reader = new StreamReader(directory + testFilename);
				int currentSubNumber = int.Parse(testSubNumber.ToString());

				while (true)
				{
					//testing programs

					//Replace old number with (increased) new one and fill with zeros. 
					testSubNumber.Replace(currentSubNumber.ToString().PadLeft(numbLength, '0'),
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
			finally
			{
				reader.Close();
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
