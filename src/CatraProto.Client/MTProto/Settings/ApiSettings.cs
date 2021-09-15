namespace CatraProto.Client.MTProto.Settings
{
    public class ApiSettings
    {
        public int ApiId { get; }
        public string ApiHash { get; }
        public string DeviceModel { get; }
        public string AppVersion { get; }
        public string LangCode { get; }
        public string LangPack { get; }
        public string SystemLangCode { get; }
        public string SystemVersion { get; }

        public ApiSettings(int apiId, string apiHash, string deviceModel, string appVersion, string langCode, string langPack, string systemLangCode, string systemVersion)
        {
            ApiHash = apiHash;
            ApiId = apiId;
            DeviceModel = deviceModel;
            AppVersion = appVersion;
            LangCode = langCode;
            LangPack = langPack;
            SystemLangCode = systemLangCode;
            SystemVersion = systemVersion;
        }
    }
}