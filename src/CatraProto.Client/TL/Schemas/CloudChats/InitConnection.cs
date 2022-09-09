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
    public partial class InitConnection : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Proxy = 1 << 0,
            Params = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1043505495; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("api_id")]
        public int ApiId { get; set; }

        [Newtonsoft.Json.JsonProperty("device_model")]
        public string DeviceModel { get; set; }

        [Newtonsoft.Json.JsonProperty("system_version")]
        public string SystemVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("app_version")]
        public string AppVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("system_lang_code")]
        public string SystemLangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("proxy")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase Proxy { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("params")]
        public CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Params { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


#nullable enable
        public InitConnection(int apiId, string deviceModel, string systemVersion, string appVersion, string systemLangCode, string langPack, string langCode, IObject query)
        {
            ApiId = apiId;
            DeviceModel = deviceModel;
            SystemVersion = systemVersion;
            AppVersion = appVersion;
            SystemLangCode = systemLangCode;
            LangPack = langPack;
            LangCode = langCode;
            Query = query;
        }
#nullable disable

        internal InitConnection()
        {
        }

        public void UpdateFlags()
        {
            Flags = Proxy == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Params == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(ApiId);

            writer.WriteString(DeviceModel);

            writer.WriteString(SystemVersion);

            writer.WriteString(AppVersion);

            writer.WriteString(SystemLangCode);

            writer.WriteString(LangPack);

            writer.WriteString(LangCode);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkproxy = writer.WriteObject(Proxy);
                if (checkproxy.IsError)
                {
                    return checkproxy;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkpparams = writer.WriteObject(Params);
                if (checkpparams.IsError)
                {
                    return checkpparams;
                }
            }

            var checkquery = writer.WriteObject(Query);
            if (checkquery.IsError)
            {
                return checkquery;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var tryapiId = reader.ReadInt32();
            if (tryapiId.IsError)
            {
                return ReadResult<IObject>.Move(tryapiId);
            }

            ApiId = tryapiId.Value;
            var trydeviceModel = reader.ReadString();
            if (trydeviceModel.IsError)
            {
                return ReadResult<IObject>.Move(trydeviceModel);
            }

            DeviceModel = trydeviceModel.Value;
            var trysystemVersion = reader.ReadString();
            if (trysystemVersion.IsError)
            {
                return ReadResult<IObject>.Move(trysystemVersion);
            }

            SystemVersion = trysystemVersion.Value;
            var tryappVersion = reader.ReadString();
            if (tryappVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryappVersion);
            }

            AppVersion = tryappVersion.Value;
            var trysystemLangCode = reader.ReadString();
            if (trysystemLangCode.IsError)
            {
                return ReadResult<IObject>.Move(trysystemLangCode);
            }

            SystemLangCode = trysystemLangCode.Value;
            var trylangPack = reader.ReadString();
            if (trylangPack.IsError)
            {
                return ReadResult<IObject>.Move(trylangPack);
            }

            LangPack = trylangPack.Value;
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }

            LangCode = trylangCode.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryproxy = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase>();
                if (tryproxy.IsError)
                {
                    return ReadResult<IObject>.Move(tryproxy);
                }

                Proxy = tryproxy.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trypparams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
                if (trypparams.IsError)
                {
                    return ReadResult<IObject>.Move(trypparams);
                }

                Params = trypparams.Value;
            }

            var tryquery = reader.ReadObject<IObject>();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "initConnection";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InitConnection();
            newClonedObject.Flags = Flags;
            newClonedObject.ApiId = ApiId;
            newClonedObject.DeviceModel = DeviceModel;
            newClonedObject.SystemVersion = SystemVersion;
            newClonedObject.AppVersion = AppVersion;
            newClonedObject.SystemLangCode = SystemLangCode;
            newClonedObject.LangPack = LangPack;
            newClonedObject.LangCode = LangCode;
            if (Proxy is not null)
            {
                var cloneProxy = (CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase?)Proxy.Clone();
                if (cloneProxy is null)
                {
                    return null;
                }

                newClonedObject.Proxy = cloneProxy;
            }

            if (Params is not null)
            {
                var cloneParams = (CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase?)Params.Clone();
                if (cloneParams is null)
                {
                    return null;
                }

                newClonedObject.Params = cloneParams;
            }

            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InitConnection castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ApiId != castedOther.ApiId)
            {
                return true;
            }

            if (DeviceModel != castedOther.DeviceModel)
            {
                return true;
            }

            if (SystemVersion != castedOther.SystemVersion)
            {
                return true;
            }

            if (AppVersion != castedOther.AppVersion)
            {
                return true;
            }

            if (SystemLangCode != castedOther.SystemLangCode)
            {
                return true;
            }

            if (LangPack != castedOther.LangPack)
            {
                return true;
            }

            if (LangCode != castedOther.LangCode)
            {
                return true;
            }

            if (Proxy is null && castedOther.Proxy is not null || Proxy is not null && castedOther.Proxy is null)
            {
                return true;
            }

            if (Proxy is not null && castedOther.Proxy is not null && Proxy.Compare(castedOther.Proxy))
            {
                return true;
            }

            if (Params is null && castedOther.Params is not null || Params is not null && castedOther.Params is null)
            {
                return true;
            }

            if (Params is not null && castedOther.Params is not null && Params.Compare(castedOther.Params))
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}