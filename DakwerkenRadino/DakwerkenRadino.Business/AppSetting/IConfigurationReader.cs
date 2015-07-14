namespace DakwerkenRadino.Business.AppSetting
{
    public interface IConfigurationReader
    {
        bool HasKey(string key);
        string GetValue(string key);
    }
}