using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace ShadowCord
{
	// -----------------------------------------------------------------------
	// <copyright>Copyright (c) 2016 Émilio Gonzalez. Licensed under the GNU
	//           Public License (GPL) version 3.0
	//			 See LICENSE file for details.
	// </copyright>
	// <author>Émilio Gonzalez</author>
	//-----------------------------------------------------------------------

	/// <summary>
	/// This class holds the basic settings (in XML) of the application. It deals with the file to
	/// read so the user doesn't have to.
	/// </summary>
	internal class SettingsManager
	{
		/// <summary>
		/// The settings file name.
		/// </summary>
		private string fileName;

		/// <summary>
		/// The path to the settings file name.
		/// </summary>
		private string pathToFileName;

		/// <summary>
		/// The XML element that contains the settings.
		/// </summary>
		private XElement settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsManager"/> class. Reads the settings
		/// file (in XML) or creates one with default values if none exist.
		/// </summary>
		public SettingsManager()
		{
			fileName = "SCSettings.xml";
			pathToFileName = Directory.GetCurrentDirectory() + fileName;
			Debug.WriteLine(pathToFileName);
			if (!File.Exists(pathToFileName))
			{
				CreateSettingsFile();
			}

			ReadSettingsFile();
			if (settings == null)
			{
				Console.WriteLine("There was a problem instantiating SettingsManager. Application closing.");
				System.Environment.Exit(420);
			}
		}

		/// <summary>
		/// Gets the value of the requested setting.
		/// </summary>
		/// <typeparam name="T">The type of the setting's value you want to get</typeparam>
		/// <param name="setting">the name of the setting you want to get</param>
		/// <returns>
		/// The value (of type T) of the setting. If the value cannot be converted to type T, it
		/// returns the default value of that type.
		/// </returns>
		public T GetSetting<T>(string setting)
		{
			string value = settings.Element(setting).Value;
			T convertedValue;
			try
			{
				TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));
				convertedValue = (T)typeConverter.ConvertFromString(value);
			}
			catch (Exception e)
			{
				convertedValue = default(T);
			}

			return convertedValue;
		}

		/// <summary>
		/// Writes the settings to the settings file.
		/// </summary>
		public void Save()
		{
			settings.Save(pathToFileName);
		}

		/// <summary>
		/// Creates a setting file named after the FileName attribute. Also write default values in it.
		/// </summary>
		private void CreateSettingsFile()
		{
			Debug.WriteLine("CreateSettingsFile()");
			try
			{
				settings = new XElement("settings", new XElement("test", 1000));
				Save();
			}
			catch (IOException e)
			{
				Console.WriteLine("Cannot create " + pathToFileName + "! :(");
			}
		}

		/// <summary>
		/// Reads the settings file and sets the class' attributes with the file's content.
		/// </summary>
		private void ReadSettingsFile()
		{
			try
			{
				XDocument document = XDocument.Load(pathToFileName);
				settings = document.Root;
			}
			catch (Exception e)
			{
				Console.WriteLine("Cannot open " + pathToFileName + " as a valid XML document.");
			}
		}
	}
}