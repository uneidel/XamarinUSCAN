// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ScannerRemote.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

    #endregion


    public static string GeneralSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
      }
    }
        public static int ServerPort
        {
            get { return AppSettings.GetValueOrDefault<int>(Constants.SERVERPORT, 3000); }
            set { AppSettings.AddOrUpdateValue<int>(Constants.SERVERPORT, value); }
        }
        public static string ServerAddress
        {
            get { return AppSettings.GetValueOrDefault<string>(Constants.SERVERADDRESS, "localhost"); }
            set { AppSettings.AddOrUpdateValue<string>(Constants.SERVERADDRESS, value); }
        }
        public static bool PreProcess
        {
            get { return AppSettings.GetValueOrDefault<bool>(Constants.PREPROCESS, true); }
            set { AppSettings.AddOrUpdateValue<bool>(Constants.PREPROCESS, value); }
        }
        public static bool Merge
        {
            get { return AppSettings.GetValueOrDefault<bool>(Constants.MERGE, false); }
            set { AppSettings.AddOrUpdateValue<bool>(Constants.MERGE, value); }
        }
        public static bool CreatePDF
        {
            get { return AppSettings.GetValueOrDefault<bool>(Constants.CREATEPDFFROMPIC, false); }
            set { AppSettings.AddOrUpdateValue<bool>(Constants.CREATEPDFFROMPIC, value); }
        }
        public static int Resolution
        {
            get { return AppSettings.GetValueOrDefault<int>(Constants.RESOLUTION, 300); }
            set { AppSettings.AddOrUpdateValue<int>(Constants.RESOLUTION, value); }
        }
        public static string Format
        {
            get { return AppSettings.GetValueOrDefault<string>(Constants.SCANFORMAT, Constants.picformats[0]); }
            set { AppSettings.AddOrUpdateValue<string>(Constants.RESOLUTION, value); }
        }
        public static bool FilteronNonTagged
        {
            get { return AppSettings.GetValueOrDefault<bool>(Constants.FILTERNONTAGGED, true); }
            set { AppSettings.AddOrUpdateValue<bool>(Constants.FILTERNONTAGGED, value); }
        }
        public static string KeyWords
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(Constants.KEYWORDS, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(Constants.KEYWORDS, value);
            }
        }

    }
}