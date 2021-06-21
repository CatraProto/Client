using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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

        public static int ConstructorId { get; } = -1043505495;
        public int Flags { get; set; }
        public int ApiId { get; set; }
        public string DeviceModel { get; set; }
        public string SystemVersion { get; set; }
        public string AppVersion { get; set; }
        public string SystemLangCode { get; set; }
        public string LangPack { get; set; }
        public string LangCode { get; set; }
        public InputClientProxyBase Proxy { get; set; }
        public JSONValueBase Params { get; set; }
        public IObject Query { get; set; }

        public Type Type { get; init; } = typeof(IObject);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = Proxy == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Params == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ApiId);
            writer.Write(DeviceModel);
            writer.Write(SystemVersion);
            writer.Write(AppVersion);
            writer.Write(SystemLangCode);
            writer.Write(LangPack);
            writer.Write(LangCode);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Proxy);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Params);
            }

            writer.Write(Query);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ApiId = reader.Read<int>();
            DeviceModel = reader.Read<string>();
            SystemVersion = reader.Read<string>();
            AppVersion = reader.Read<string>();
            SystemLangCode = reader.Read<string>();
            LangPack = reader.Read<string>();
            LangCode = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Proxy = reader.Read<InputClientProxyBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Params = reader.Read<JSONValueBase>();
            }

            Query = reader.Read<IObject>();
        }
    }
}