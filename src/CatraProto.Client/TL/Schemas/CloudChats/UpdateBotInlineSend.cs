using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotInlineSend : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Geo = 1 << 0,
            MsgId = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => 317794823;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }


    #nullable enable
        public UpdateBotInlineSend(long userId, string query, string id)
        {
            UserId = userId;
            Query = query;
            Id = id;
        }
    #nullable disable
        internal UpdateBotInlineSend()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            writer.Write(Query);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Geo);
            }

            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(MsgId);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            UserId = reader.Read<long>();
            Query = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
            }

            Id = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                MsgId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
            }
        }

        public override string ToString()
        {
            return "updateBotInlineSend";
        }
    }
}