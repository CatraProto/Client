using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Authorization : CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Current = 1 << 0,
            OfficialApp = 1 << 1,
            PasswordPending = 1 << 2,
            EncryptedRequestsDisabled = 1 << 3,
            CallRequestsDisabled = 1 << 4
        }

        public static int StaticConstructorId
        {
            get => -1392388579;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("current")]
        public sealed override bool Current { get; set; }

        [Newtonsoft.Json.JsonProperty("official_app")]
        public sealed override bool OfficialApp { get; set; }

        [Newtonsoft.Json.JsonProperty("password_pending")]
        public sealed override bool PasswordPending { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_requests_disabled")]
        public sealed override bool EncryptedRequestsDisabled { get; set; }

        [Newtonsoft.Json.JsonProperty("call_requests_disabled")]
        public sealed override bool CallRequestsDisabled { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public sealed override long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("device_model")]
        public sealed override string DeviceModel { get; set; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public sealed override string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("system_version")]
        public sealed override string SystemVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("api_id")]
        public sealed override int ApiId { get; set; }

        [Newtonsoft.Json.JsonProperty("app_name")]
        public sealed override string AppName { get; set; }

        [Newtonsoft.Json.JsonProperty("app_version")]
        public sealed override string AppVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("date_created")]
        public sealed override int DateCreated { get; set; }

        [Newtonsoft.Json.JsonProperty("date_active")]
        public sealed override int DateActive { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")] public sealed override string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("country")]
        public sealed override string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("region")]
        public sealed override string Region { get; set; }


    #nullable enable
        public Authorization(long hash, string deviceModel, string platform, string systemVersion, int apiId, string appName, string appVersion, int dateCreated, int dateActive, string ip, string country, string region)
        {
            Hash = hash;
            DeviceModel = deviceModel;
            Platform = platform;
            SystemVersion = systemVersion;
            ApiId = apiId;
            AppName = appName;
            AppVersion = appVersion;
            DateCreated = dateCreated;
            DateActive = dateActive;
            Ip = ip;
            Country = country;
            Region = region;
        }
    #nullable disable
        internal Authorization()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Current ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = OfficialApp ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = PasswordPending ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = EncryptedRequestsDisabled ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = CallRequestsDisabled ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Hash);
            writer.Write(DeviceModel);
            writer.Write(Platform);
            writer.Write(SystemVersion);
            writer.Write(ApiId);
            writer.Write(AppName);
            writer.Write(AppVersion);
            writer.Write(DateCreated);
            writer.Write(DateActive);
            writer.Write(Ip);
            writer.Write(Country);
            writer.Write(Region);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Current = FlagsHelper.IsFlagSet(Flags, 0);
            OfficialApp = FlagsHelper.IsFlagSet(Flags, 1);
            PasswordPending = FlagsHelper.IsFlagSet(Flags, 2);
            EncryptedRequestsDisabled = FlagsHelper.IsFlagSet(Flags, 3);
            CallRequestsDisabled = FlagsHelper.IsFlagSet(Flags, 4);
            Hash = reader.Read<long>();
            DeviceModel = reader.Read<string>();
            Platform = reader.Read<string>();
            SystemVersion = reader.Read<string>();
            ApiId = reader.Read<int>();
            AppName = reader.Read<string>();
            AppVersion = reader.Read<string>();
            DateCreated = reader.Read<int>();
            DateActive = reader.Read<int>();
            Ip = reader.Read<string>();
            Country = reader.Read<string>();
            Region = reader.Read<string>();
        }

        public override string ToString()
        {
            return "authorization";
        }
    }
}