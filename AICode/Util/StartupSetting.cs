using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace AICode.Util
{
    class StartupSetting
    {
        public static void autoRun(string exeName, string exePath)
        {
            RegistryKey runItem = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                if(runItem != null)
                {
                    runItem.SetValue(exeName, exePath);
                }
            }
            catch(Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        public static void deleteAutoRun(string exeName)
        {
            RegistryKey runItem = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                if(runItem != null)
                {
                    runItem.DeleteSubKey("AICode");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        } 
    }
}
