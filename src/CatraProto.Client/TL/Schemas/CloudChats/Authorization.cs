using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1392388579; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Hash);

            writer.WriteString(DeviceModel);

            writer.WriteString(Platform);

            writer.WriteString(SystemVersion);
            writer.WriteInt32(ApiId);

            writer.WriteString(AppName);

            writer.WriteString(AppVersion);
            writer.WriteInt32(DateCreated);
            writer.WriteInt32(DateActive);

            writer.WriteString(Ip);

            writer.WriteString(Country);

            writer.WriteString(Region);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Current = FlagsHelper.IsFlagSet(Flags, 0);
            OfficialApp = FlagsHelper.IsFlagSet(Flags, 1);
            PasswordPending = FlagsHelper.IsFlagSet(Flags, 2);
            EncryptedRequestsDisabled = FlagsHelper.IsFlagSet(Flags, 3);
            CallRequestsDisabled = FlagsHelper.IsFlagSet(Flags, 4);
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            var trydeviceModel = reader.ReadString();
            if (trydeviceModel.IsError)
            {
                return ReadResult<IObject>.Move(trydeviceModel);
            }

            DeviceModel = trydeviceModel.Value;
            var tryplatform = reader.ReadString();
            if (tryplatform.IsError)
            {
                return ReadResult<IObject>.Move(tryplatform);
            }

            Platform = tryplatform.Value;
            var trysystemVersion = reader.ReadString();
            if (trysystemVersion.IsError)
            {
                return ReadResult<IObject>.Move(trysystemVersion);
            }

            SystemVersion = trysystemVersion.Value;
            var tryapiId = reader.ReadInt32();
            if (tryapiId.IsError)
            {
                return ReadResult<IObject>.Move(tryapiId);
            }

            ApiId = tryapiId.Value;
            var tryappName = reader.ReadString();
            if (tryappName.IsError)
            {
                return ReadResult<IObject>.Move(tryappName);
            }

            AppName = tryappName.Value;
            var tryappVersion = reader.ReadString();
            if (tryappVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryappVersion);
            }

            AppVersion = tryappVersion.Value;
            var trydateCreated = reader.ReadInt32();
            if (trydateCreated.IsError)
            {
                return ReadResult<IObject>.Move(trydateCreated);
            }

            DateCreated = trydateCreated.Value;
            var trydateActive = reader.ReadInt32();
            if (trydateActive.IsError)
            {
                return ReadResult<IObject>.Move(trydateActive);
            }

            DateActive = trydateActive.Value;
            var tryip = reader.ReadString();
            if (tryip.IsError)
            {
                return ReadResult<IObject>.Move(tryip);
            }

            Ip = tryip.Value;
            var trycountry = reader.ReadString();
            if (trycountry.IsError)
            {
                return ReadResult<IObject>.Move(trycountry);
            }

            Country = trycountry.Value;
            var tryregion = reader.ReadString();
            if (tryregion.IsError)
            {
                return ReadResult<IObject>.Move(tryregion);
            }

            Region = tryregion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "authorization";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Authorization();
            newClonedObject.Flags = Flags;
            newClonedObject.Current = Current;
            newClonedObject.OfficialApp = OfficialApp;
            newClonedObject.PasswordPending = PasswordPending;
            newClonedObject.EncryptedRequestsDisabled = EncryptedRequestsDisabled;
            newClonedObject.CallRequestsDisabled = CallRequestsDisabled;
            newClonedObject.Hash = Hash;
            newClonedObject.DeviceModel = DeviceModel;
            newClonedObject.Platform = Platform;
            newClonedObject.SystemVersion = SystemVersion;
            newClonedObject.ApiId = ApiId;
            newClonedObject.AppName = AppName;
            newClonedObject.AppVersion = AppVersion;
            newClonedObject.DateCreated = DateCreated;
            newClonedObject.DateActive = DateActive;
            newClonedObject.Ip = Ip;
            newClonedObject.Country = Country;
            newClonedObject.Region = Region;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Authorization castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Current != castedOther.Current)
            {
                return true;
            }

            if (OfficialApp != castedOther.OfficialApp)
            {
                return true;
            }

            if (PasswordPending != castedOther.PasswordPending)
            {
                return true;
            }

            if (EncryptedRequestsDisabled != castedOther.EncryptedRequestsDisabled)
            {
                return true;
            }

            if (CallRequestsDisabled != castedOther.CallRequestsDisabled)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            if (DeviceModel != castedOther.DeviceModel)
            {
                return true;
            }

            if (Platform != castedOther.Platform)
            {
                return true;
            }

            if (SystemVersion != castedOther.SystemVersion)
            {
                return true;
            }

            if (ApiId != castedOther.ApiId)
            {
                return true;
            }

            if (AppName != castedOther.AppName)
            {
                return true;
            }

            if (AppVersion != castedOther.AppVersion)
            {
                return true;
            }

            if (DateCreated != castedOther.DateCreated)
            {
                return true;
            }

            if (DateActive != castedOther.DateActive)
            {
                return true;
            }

            if (Ip != castedOther.Ip)
            {
                return true;
            }

            if (Country != castedOther.Country)
            {
                return true;
            }

            if (Region != castedOther.Region)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}