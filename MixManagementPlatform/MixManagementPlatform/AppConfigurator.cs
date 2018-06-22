using System.Configuration;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public class AppConfigurator
    {
        ///<summary>  
        ///在*.exe.config文件中appSettings配置节增加一对键值对  
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        ///<summary> 
        ///返回*.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string GetAppConfig(string strKey)
        {
            string file = Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value;
                }
            }
            return null;
        }


        ///<summary>     
        ///更新连接字符串      
        ///</summary>     
        ///<param name="newName">连接字符串名称</param>     
        ///<param name="newConString">连接字符串内容</param>
        ///<param name="newProviderName">数据提供程序名称</param>     
        public static void UpdateConnectionStringsConfig(string newName,
            string newConString,
            string newProviderName,string configPath)
        {

            string file = configPath;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);



            bool isModified = false;    //记录该连接串是否已经存在      
            //如果要更改的连接串已经存在      
            if (config.ConnectionStrings.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例      
            ConnectionStringSettings mySettings =
                new ConnectionStringSettings(newName, newConString, newProviderName);
            // 如果连接串已存在，首先删除它      
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.      
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改      
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节      
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
    }
}
