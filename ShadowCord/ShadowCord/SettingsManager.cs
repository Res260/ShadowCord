using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;

namespace ShadowCord
{
	/// <summary>
	/// This class holds the basic settings of the application. 
	/// It deals with the file to read so the user doen't have to.
	/// </summary>
	class SettingsManager
	{
		private string FileName;
		private string PathToFileName;
		private XElement Settings;

		public string GetSetting()
		{
			return null;
		}

		/// <summary>
		/// Constructor for SettingsManager. Reads the settings file (in XML)
		/// or creates one with default values if none exist.
		/// </summary>
		public SettingsManager()
		{
			FileName = "SCSettings.xml";
			PathToFileName = Directory.GetCurrentDirectory() + FileName;
			Debug.WriteLine(PathToFileName);
			if (!File.Exists(PathToFileName))
			{
				CreateSettingsFile();
			}
			ReadSettingsFile();
			if (Settings == null)
			{
				Console.WriteLine("There was a problem instantiating SettingsManager. Application closing.");
				System.Environment.Exit(1);
			}
		}

		/// <summary>
		/// Reads the settings file and sets the class' attributes with
		/// the file's content.
		/// </summary>
		private void ReadSettingsFile()
		{
			try
			{
				XDocument document = XDocument.Load(PathToFileName);
				Settings = document.Root;
			}
			catch (Exception e)
			{
				Console.WriteLine("Cannot open " + PathToFileName + " as a valid XML document.");
			}
		}

		/// <summary>
		/// Creates a setting file named after the FileName attribute.
		/// Also write default values in it.
		/// </summary>
		private void CreateSettingsFile()
		{
			Debug.WriteLine("CreateSettingsFile()");
			try
			{
				Settings = new XElement("settings",
					new XElement("test", 1000)
					);
				Save();
			}
			catch (IOException e)
			{
				Console.WriteLine("Cannot create " + PathToFileName + "! :(");
			}
		}

		/// <summary>
		/// Writes the settings to the settings file.
		/// </summary>
		public void Save()
		{
			Settings.Save(PathToFileName);
		}


	}
}
