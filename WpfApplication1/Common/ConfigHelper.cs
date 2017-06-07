using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ToolForDan
{
    public class ConfigHelper
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public void Add(string strkey, string value)
        {
            if (!config.HasFile)
            {
                throw new ArgumentException("程序配置文件缺失！");
            }
            if (config.AppSettings.Settings[strkey] == null)
                config.AppSettings.Settings.Add(strkey, value);
            else
                config.AppSettings.Settings[strkey].Value += (string.IsNullOrEmpty(config.AppSettings.Settings[strkey].Value) ? "" : ",") + value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        public void Delete(string strkey)
        {
            if (!config.HasFile)
            {
                throw new ArgumentException("程序配置文件缺失！");
            }
            if (config.AppSettings.Settings[strkey] != null)
                config.AppSettings.Settings.Remove(strkey);
            config.Save(ConfigurationSaveMode.Modified);
        }

        public void Remove(string strkey, string value)
        {
            if (config.AppSettings.Settings[strkey] != null)
            {
                if (config.AppSettings.Settings[strkey].Value.IndexOf(',') > 0)
                {
                    config.AppSettings.Settings[strkey].Value = config.AppSettings.Settings[strkey].Value.Replace("," + value, string.Empty);
                    config.AppSettings.Settings[strkey].Value = config.AppSettings.Settings[strkey].Value.Replace(value + ",", string.Empty);
                }
                else
                {
                    config.AppSettings.Settings[strkey].Value = config.AppSettings.Settings[strkey].Value.Replace(value, string.Empty);
                }
            }
            config.Save(ConfigurationSaveMode.Modified);
        }

        public bool Exist(string strkey)
        {
            return config.AppSettings.Settings[strkey] != null;
        }

        public string GetValue(string strkey)
        {
            if (Exist(strkey))
            {
                return config.AppSettings.Settings[strkey].Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
