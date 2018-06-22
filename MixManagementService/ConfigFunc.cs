using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace MixManagementService
{
    static class ConfigFunc
    {
        public const string RegeditApplicationKey = "MixManagementService";
        public const string RegeditDirKey = "StartApp";

        /// <summary>
        /// 获取CurrentUser注册表
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetRegeditData(string dirName, string keyName)
        {
            object value = 0;
           // using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey(RegeditApplicationKey).CreateSubKey(dirName))
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey(RegeditApplicationKey).CreateSubKey(dirName))
            {
                value = regKey.GetValue(keyName, 0);
            }
            return value;
        }

        /// <summary>
        /// 获取LocalMachine注册表  由于服务运行时权限为LocalSystem  所以注册表只能采用公共部分  LocalMachine
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetRegeditData_LocalMachine(string dirName, string keyName)
        {
            object value = 0;
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SYSTEM", true).OpenSubKey("CurrentControlSet",true).OpenSubKey("services",true).OpenSubKey(RegeditApplicationKey,true).CreateSubKey(dirName))
            {
                value = regKey.GetValue(keyName, 0);
            }
            return value;
        }


        /// <summary>
        /// 写入CurrentUser注册表
        /// </summary>
        /// <param name="dirName">数据对应注册表路径</param>
        /// <param name="keyName">子键名</param>
        /// <param name="keyValue">写入keyName的键值</param>
        public static void SetRegeditData(string dirName, string keyName, object keyValue)
        {
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey(RegeditApplicationKey).CreateSubKey(dirName))
            {
                regKey.SetValue(keyName, keyValue);
            }
            MixLogHelper.Info("Program", string.Format("注册表写入: SOFTWARE\\" + RegeditApplicationKey + "\\" + dirName + "({0})", keyValue));
        }

        /// <summary>
        /// 写入LocalMachine注册表
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        public static void SetRegeditData_LocalMachine(string dirName, string keyName, object keyValue)
        {
          //  using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey(RegeditApplicationKey).CreateSubKey(dirName))
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SYSTEM", true).OpenSubKey("CurrentControlSet", true).OpenSubKey("services", true).OpenSubKey(RegeditApplicationKey, true).CreateSubKey(dirName))
            {
                regKey.SetValue(keyName, keyValue);
            }
            MixLogHelper.Info("Program", string.Format("注册表写入: SOFTWARE\\" + RegeditApplicationKey + "\\" + dirName + "({0})", keyValue));
        }

        public static void SaveConfig(string key, string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings[key].Value = value;
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void SaveConfig(string[] keys, string[] values)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            for (int i = 0; i < keys.Length; i++)
            {
                cfa.AppSettings.Settings[keys[i]].Value = values[i];
            }
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void SaveConfig(Dictionary<string, string> configs)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (var key in configs.Keys)
            {
                cfa.AppSettings.Settings[key].Value = configs[key];
            }
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
