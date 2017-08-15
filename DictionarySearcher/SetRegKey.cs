using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace DictionarySearcher
{
    static class SetRegKey
    {
        public static void SetValue()
        {
            Microsoft.Win32.RegistryKey regkey1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION");
            string name = System.IO.Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            // レジストリに書き込む
            regkey1.SetValue(name, 11001);

        }
    }
}
