using System;
using System.Globalization;
using System.Threading;
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
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture

			//1.Define path directory
			Console.Write("Take test files from current directory ");
			string choice = yesOrNoQuestion();
			string directory = String.Empty;

			if (choice == string.Empty || choice == YES || choice == yes)  //choise == string.Empty -> when user press <Enter>
			{
				//do not delete this statement, it will prevent exeption when user press <Enter>
			}
			else if (choice == NO || choice == no)
			{
				Console.Write("Where test files are placed? : ");
				directory = ReadLineFromConsole();
			}
			else //да вкарам проверката в "yesOrNoQuestion()"
			{
				throw new ArgumentException("Invalid input data!");
			}

			//2.Define file name
			Console.Write("The program will looking for files with this pattern: \"test.001.in.txt\" ");
			choice = no;
			choice = yesOrNoQuestion();

			string fileName = "test.001.in";
			string fileExtension = ".txt";

			if (choice == string.Empty || choice == YES || choice == yes)  //choise == string.Empty -> when user press <Enter>
			{
				//do not delete this statement, it will prevent exeption when user press <Enter>
			}
			else if (choice == NO || choice == no)
			{
				string name = string.Empty;
				int nameEndIndex = 0;

				string numb = string.Empty;
				int numbStartIndex = 0;

				string inTest = "in";
				int inIndex = 0;

				choice = no;
				do
				{
					Console.Write("Type file name pattern (e.g.: myTestFiles.001.in.txt): ");
					fileName = ReadLineFromConsole();

					nameEndIndex = fileName.IndexOf('.');
					numbStartIndex = Regex.Match(fileName, @"\d").Index;
					inIndex = fileName.IndexOf("." + inTest + ".", StringComparison.CurrentCultureIgnoreCase);

					if (nameEndIndex >= numbStartIndex)
					{
						ReturnInfoMessageToConsole("* The program can not recognize correct sub-name and sub-number of full file name. Are you missing the delimiter (\'.\'–dot) between them?");
					}

					if (numbStartIndex >= inIndex)
					{
						ReturnInfoMessageToConsole("* The program can not recognize correct sub-number and \"in\" (wich mean input test file) word of full file name!");
					}
					else
					{
						name = fileName.Substring(0, nameEndIndex);
						numb = fileName.Substring(numbStartIndex, Regex.Match(fileName, @"\d+").Length);

						Console.Write("Is that correct ");
						choice = yesOrNoQuestion();
					}
				} while (!(choice == YES) || !(choice == yes));

				choice = yes;
				if (!(Regex.IsMatch(fileName, string.Format(@"\b{0}\b", fileExtension))))
				{
					ReturnInfoMessageToConsole("The default files should be in TXT format, but you type something different..");
					Console.Write("Do you want to use default TXT extension ");
					choice = yesOrNoQuestion();

					if (choice[0] == 'N' || choice[0] == 'n')
					{
						throw new ArgumentException("Invalid file extension!");
					}

					fileName = fileName.Remove(fileName.LastIndexOf('.'));
					fileName = fileName.TrimEnd('.');
					fileName = fileName + fileExtension;
				}

				Console.WriteLine("The program will try to find next test files..");
			}
			else
			{
				throw new ArgumentException("Invalid input data!");
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
