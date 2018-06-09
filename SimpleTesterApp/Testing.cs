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
            StringBuilder tempValue = new StringBuilder();

            int numbLength = testSubNumber.Length;

            try
            {
                reader = new StreamReader(directory + testFilename);

                while (true)
                {
                    int currentSubNumber = int.Parse(testSubNumber.ToString());

					//testing programs
                                        
					tempValue.Clear();
                    tempValue.Append(testSubNumber.Replace(currentSubNumber.ToString(),
                                         (currentSubNumber++).ToString())
                                         .ToString().PadLeft(numbLength, '0')); //Replace old number with new and fill with zeros.

					testSubNumber.Clear();
					testSubNumber.Append(tempValue);
                }

            }
            catch (FileNotFoundException fnEx)
            {
				ReturnInfoMessageToConsole(fnEx.Message);
            }
            catch (Exception ex)
            {
				ReturnInfoMessageToConsole(ex.Message);
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
