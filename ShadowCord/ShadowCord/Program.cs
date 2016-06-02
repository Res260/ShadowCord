using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ShadowCord
{
    static class Program
    {
        /// <summary>
        /// ShadowCord.
        /// </summary>
        static void Main()
        {
			SettingsManager settings = new SettingsManager();
			Console.WriteLine(settings.GetSetting<Boolean>("test"));
			Thread.Sleep(5000);
        }
    }
}
