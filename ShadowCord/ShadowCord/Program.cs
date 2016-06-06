using Discord;

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
	/// The root class for the program.
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// The ShadowCord
		/// </summary>
		private static void Main()
		{
			SettingsManager settings = new SettingsManager();
			DiscordClient client = new DiscordClient(x =>
			{
				x.AppName = "ShadowCord";
				x.AppUrl = "https://github.com/Res260/ShadowCord";
			});
		}
	}
}