using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordVault
{
    public class Utilities
    {
        /// <summary>
        /// Function takes in the name as it would appear in the app add/uninstall list
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="isX86Platform"></param>
        /// <returns></returns>
        public static bool isApplicationInstalled(string appDisplayName, bool isX86Platform = false)
        {
            string uninstallKey = string.Empty;

            // based on the platform we would have a different key to use
            if (isX86Platform)
            {
                uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            }
            else
            {
                uninstallKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            }

            // Search the registry looking for the display names that might match our appName
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        if (sk.GetValue("DisplayName") != null && sk.GetValue("DisplayName").ToString().ToUpper().Contains(appDisplayName.ToUpper()))
                        {
                            return true;
                        }

                    }
                }
            }

            // We failed to find the app in the registry
            return false;
        }
    }
}
