using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UrlAuthResultRequest : CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RequestWriteAccess = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1831650802;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("request_write_access")]
        public bool RequestWriteAccess { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.UserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("domain")]
        public string Domain { get; set; }


    #nullable enable
        public UrlAuthResultRequest(CatraProto.Client.TL.Schemas.CloudChats.UserBase bot, string domain)
        {
            Bot = bot;
            Domain = domain;
        }
    #nullable disable
        internal UrlAuthResultRequest()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Bot);
            writer.Write(Domain);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RequestWriteAccess = FlagsHelper.IsFlagSet(Flags, 0);
            Bot = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            Domain = reader.Read<string>();
        }

        public override string ToString()
        {
            return "urlAuthResultRequest";
        }
    }
}