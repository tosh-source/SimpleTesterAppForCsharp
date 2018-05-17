using System;
using System.Text.RegularExpressions;

namespace SimpleTesterApp
{
	public class Input
	{
		const string NO = "N";
		const string no = "n";
		const string YES = "Y";
		const string yes = "y";

		public static void UserData()
		{
			//1.Define path directory
			Console.Write("Take test files from current directory ");
			string choice = yesOrNoQuestion();
			string directory = String.Empty;

			if (choice == NO || choice == no)
			{
				Console.Write("Where test files are placed? : ");
				directory = ReadLineFromConsole();
			}

			//2.Define filename
			Console.WriteLine("\nThe program will looking for files with this pattern:");
			Console.WriteLine("\"test.001.in.txt\"  <- input test with data");
			Console.WriteLine("\"test.001.out.txt\" <- output test for comparing\n");
			Console.Write("Is that OK ");
			choice = no;
			choice = yesOrNoQuestion();

			string fileName = "test.001.in";
			string fileExtension = ".txt";

			if (choice == NO || choice == no)
			{
				string name = string.Empty;
				int nameEndIndex = 0;

				string numb = string.Empty;
				int numbStartIndex = 0;

				string inTest = "in";
				int inIndex = 0;
				string outTest = "out";

				//a. Get new filename pattern, if needed.
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

						IsCorrectNewFilenamePattern(ref choice, ref fileName, fileExtension, out name, nameEndIndex, out numb, numbStartIndex, inTest);
					}
					else
					{
						IsCorrectNewFilenamePattern(ref choice, ref fileName, fileExtension, out name, nameEndIndex, out numb, numbStartIndex, inTest);
					}
				} while (!(choice == YES || choice == yes));

				ReturnInfoMessageToConsole("\nThe program will try to find next test files..");
			}
		}

		private static void IsCorrectNewFilenamePattern(ref string choice, ref string fileName, string fileExtension, out string name, int nameEndIndex, out string numb, int numbStartIndex, string inTest)
		{
			name = fileName.Substring(0, nameEndIndex);
			numb = fileName.Substring(numbStartIndex, Regex.Match(fileName, @"\d+").Length);

			CheckFilenameExtension(ref choice, ref fileName, fileExtension);

			Console.Write("\nThe new filename pattern is: ");
			fileName = name + "." + numb + "." + inTest + fileExtension;
			ReturnInfoMessageToConsole(fileName);
			Console.Write("Is that correct ");
			choice = yesOrNoQuestion();
		}

		private static void CheckFilenameExtension(ref string choice, ref string fileName, string fileExtension)
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

		private static string yesOrNoQuestion()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("(Y/n)");
			Console.ResetColor();
			Console.Write(" ? : ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			string choice = Console.ReadLine();
			Console.ResetColor();

			if (choice == string.Empty || choice == YES || choice == yes || choice == NO || choice == no)
			{ //choise == string.Empty -> when user press <Enter>

			}
			else
			{
				throw new ArgumentException("Invalid input data!");
			}

			return choice;
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
	}
}
