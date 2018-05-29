using System;

namespace SimpleTesterApp.InputData
{
	public class InputDataGetter
	{
		private string getPathDirectory;
		private string getFullFilename;
		private string getSubFilename;
		private string getFileNumber;
		private string getTestInputWord;
		private string getTestOutputWord;

		public string GetPathDirectory
		{
			get
			{
				return this.getPathDirectory;
			}
			private set
			{
				this.getPathDirectory = value;
			}
		}

		public string GetFullFilename
		{
			get
			{
				return this.getFullFilename;
			}
			private set
			{
				this.getFullFilename = value;
			}
		}

		public string GetSubFilename
		{
			get
			{
				return this.getSubFilename;
			}
			private set
			{
				this.getSubFilename = value;
			}
		}

		public string GetFileNumber
		{
			get
			{
				return this.getFileNumber;
			}
			private set
			{
				this.getFileNumber = value;
			}
		}

		public string GetTestInputWord
		{
			get
			{
				return this.getTestInputWord;
			}
			private set
			{
				this.getTestInputWord = value;
			}
		}

		public string GetTestOutputWord
		{
			get
			{
				return this.getTestOutputWord;
			}
			private set
			{
				this.getTestOutputWord = value;
			}
		}

		public InputDataGetter()
		{
			dynamic tempValues;

			tempValues = InputDataProcessing.GetPathDirectory();
			GetPathDirectory = tempValues;

			tempValues = null;
			tempValues = InputDataProcessing.GetFilename();
			GetFullFilename = tempValues["fileName"];
			GetSubFilename = tempValues["name"];
			GetFileNumber = tempValues["numb"];
			GetTestInputWord = tempValues["inTest"];
			GetTestOutputWord = tempValues["outTest"];
		}
	}
}
