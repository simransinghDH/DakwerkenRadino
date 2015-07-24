using System.Configuration;
using System.Linq;
using DakwerkenRadino.Business.Email;
using log4net;

namespace DakwerkenRadino.Business.AppSetting
{
    public class ConfigurationReader : IConfigurationReader
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EmailProcessor));

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
                Logger.Error("An error has occured while reading a value from the configuration: " + configEx.GetBaseException(), configEx);
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
                Logger.Error("An error has occured while reading a value from the configuration: " + configEx.GetBaseException(), configEx);
            }

            return result;
        }
    }
}