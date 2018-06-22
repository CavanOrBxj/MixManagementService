using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MixManagementPlatform.Utils
{
    //Properties属性文件操作类
    /// <summary>
    /// 属性文件读取操作类
    /// </summary>
    public class PropertyFileOperator
    {
        private string filePath;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        public PropertyFileOperator(string strFilePath)
        {
            filePath = strFilePath;
        }

        /// <summary>
        /// 根据键获得值字符串
        /// </summary>
        /// <param name="strKey">键</param>
        /// <returns>值</returns>
        public string GetPropertiesText(string strKey)
        {
            try
            {
                string strResult = string.Empty;
                string str = string.Empty;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sr.BaseStream.Seek(0, SeekOrigin.End);
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    while ((str = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(str) && str[0] != '#' && str.Substring(0, str.IndexOf('=')).Trim().Equals(strKey))
                        {
                            strResult = str.Substring(str.IndexOf('=') + 1).Trim();
                            break;
                        }
                    }
                }
                return strResult;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据键获得值数组
        /// </summary>
        /// <param name="strKey">键</param>
        /// <returns>值数组</returns>
        public string[] GetPropertiesArray(string strKey)
        {
            string strResult = string.Empty;
            string str = string.Empty;
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.BaseStream.Seek(0, SeekOrigin.End);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                while ((str = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(str) && str[0] != '#' && str.Substring(0, str.IndexOf('=')).Trim().Equals(strKey))
                    {
                        strResult = str.Substring(str.IndexOf('=') + 1).Trim();
                        break;
                    }
                }
            }
            return strResult.Split(',');
        }

        public void SetPropertiesText(string strKey, string value)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string str = string.Empty;
                while ((str = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(str) && str[0] != '#' && str.Substring(0, str.IndexOf('=')).Trim().Equals(strKey))
                    {
                        int index = str.IndexOf('=') + 1;
                        str = str.Remove(index);
                        str += value;
                    }
                    list.Add(str);
                }
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(list[i]);
                }
                sw.Flush();
            }
        }

    }
}
