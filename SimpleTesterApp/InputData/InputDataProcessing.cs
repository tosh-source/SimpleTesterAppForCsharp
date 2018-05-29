using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleTesterApp.InputData
{
	public static class InputDataProcessing
	{
		const string NO = "N";
		const string no = "n";
		const string YES = "Y";
		const string yes = "y";
		static string choice = string.Empty;

		public static string GetPathDirectory()
		{
			//1.Define path directory
			Console.Write("Take test files from current directory ");
			choice = yesOrNoQuestion();
			string directory = String.Empty;

			if (choice == NO || choice == no)
			{
				Console.Write("Where test files are placed? : ");
				directory = ReadLineFromConsole();
			}

			return directory;
		}

		public static Dictionary<string, string> GetFilename()
		{
			//2.Define filename (and check for input data to be correct)
			Console.WriteLine("\nThe program will looking for files with this pattern:");
			Console.WriteLine("\"test.001.in.txt\"  <- input test with data");
			Console.WriteLine("\"test.001.out.txt\" <- output test for comparing\n");
			Console.Write("Is that OK ");
			choice = no;
			choice = yesOrNoQuestion();

			var fileNameAllData = new Dictionary<string, string>();

			string fileName = "test.001.in";
			string fileExtension = ".txt";

			string name = string.Empty;  //"name" is a sub-name from entire filename
			int nameEndIndex = 0;
			
			string numb = string.Empty;  //"numb" is a sub-numb from entire filename
			int numbStartIndex = 0;
			
			string inTest = "in";
			int inIndex = 0;
			string outTest = "out";

			if (choice == NO || choice == no) //Get new filename pattern, if needed.
            {
				//Get new filename pattern.
				choice = no;
				do
				{
					Console.Write("Type filename pattern (e.g.: myTestFiles.001.in.txt): ");
					fileName = ReadLineFromConsole();

					nameEndIndex = fileName.IndexOf('.');
					numbStartIndex = Regex.Match(fileName, @"\d").Index;
					inIndex = fileName.IndexOf("." + inTest + ".", StringComparison.CurrentCultureIgnoreCase);

					if (nameEndIndex >= numbStartIndex)
					{
						ReturnInfoMessageToConsole("\nWARNING: The program can not correct recognize sub-name and sub-number of full file name. Are you missing the delimiter (\'.\'–dot) between them?\n");
					}
					else if (numbStartIndex >= inIndex)
					{
						ReturnInfoMessageToConsole("\nWARNING: The program can not correct recognize \"in\" sub-word (wich mean input test file) of full file name! It should be immediately before file extension!\n");

						Console.WriteLine("Set new parameters for \"in\" (input) and \"out\" (output) tests.. ");
						Console.Write("input tests:  ");
						inTest = ReadLineFromConsole();
						Console.Write("output tests: ");
						outTest = ReadLineFromConsole();

						IsCorrectNewFilenamePattern(ref fileName, fileExtension, out name, nameEndIndex, out numb, numbStartIndex, inTest);
					}
					else
					{
						IsCorrectNewFilenamePattern(ref fileName, fileExtension, out name, nameEndIndex, out numb, numbStartIndex, inTest);
					}
				} while (!(choice == YES || choice == yes));

				ReturnInfoMessageToConsole("\nThe program will try to find next test files..");
			}

			//results
			fileNameAllData.Add("fileName", fileName);
			fileNameAllData.Add("name", name);
			fileNameAllData.Add("numb", numb);
			fileNameAllData.Add("inTest", inTest);
			fileNameAllData.Add("outTest", outTest);

			return fileNameAllData;
		}

		private static string yesOrNoQuestion()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("(Y/n)");
			Console.ResetColor();
			Console.Write(" ? : ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			string tmpChoice = Console.ReadLine();
			Console.ResetColor();

			if (tmpChoice == string.Empty || tmpChoice == YES || tmpChoice == yes || tmpChoice == NO || tmpChoice == no)
			{ //tmpChoice == string.Empty -> (when user press <Enter> == yes)

			}
			else
			{
				throw new ArgumentException("Invalid input data!");
			}

			return tmpChoice;
		}

		private static string ReadLineFromConsole()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			string str = Console.ReadLine();
			Console.ResetColor();

			return str;
		}

		private static void ReturnInfoMessageToConsole(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		private static void IsCorrectNewFilenamePattern(ref string fileName, string fileExtension, out string name, int nameEndIndex, out string numb, int numbStartIndex, string inTest)
		{
			name = fileName.Substring(0, nameEndIndex);
			numb = fileName.Substring(numbStartIndex, Regex.Match(fileName, @"\d+").Length);

			CheckFilenameExtension(ref fileName, fileExtension);

			Console.Write("\nThe new filename pattern is: ");
			fileName = name + "." + numb + "." + inTest + fileExtension;
			ReturnInfoMessageToConsole(fileName);
			Console.Write("Is that correct ");
			choice = yesOrNoQuestion();
		}

		private static void CheckFilenameExtension(ref string fileName, string fileExtension)
		{
			choice = yes;
			if (!(Regex.IsMatch(fileName, string.Format(@"\b{0}\b", fileExtension))))
			{
				ReturnInfoMessageToConsole("\nWARNING: The test files should be in TXT format, but you type something different!\n");
				Console.Write("Do you want to use default TXT extension ");
				choice = yesOrNoQuestion();

				if (choice == NO || choice == no)
				{
					throw new ArgumentException("Invalid file extension!");
				}

				fileName = fileName.Remove(fileName.LastIndexOf('.'));
				fileName = fileName.TrimEnd('.');
				fileName = fileName + fileExtension;
			}
		}
	}
}
