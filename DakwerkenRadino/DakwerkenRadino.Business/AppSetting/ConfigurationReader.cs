using System.Configuration;
using System.Linq;

namespace DakwerkenRadino.Business.AppSetting
{
    public class ConfigurationReader : IConfigurationReader
    {
        public bool HasKey(string key)
        {
            bool result = false;

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings.AllKeys.Contains(key);
            }
            catch (ConfigurationErrorsException configEx)
            {
                //TODO 
            }

            return result;
        }

        public string GetValue(string key)
        {
            string result = string.Empty;

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings.AllKeys.Contains(key) ? appSettings[key] : string.Empty;
            }
            catch(ConfigurationErrorsException configEx)
            {
                //TODO 
            }

            return result;
        }
    }
}