using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SponsoredMessage : CatraProto.Client.TL.Schemas.CloudChats.SponsoredMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ChannelPost = 1 << 2,
            StartParam = 1 << 0,
            Entities = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => -783162982;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public sealed override byte[] RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("from_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_post")]
        public sealed override int? ChannelPost { get; set; }

        [Newtonsoft.Json.JsonProperty("start_param")]
        public sealed override string StartParam { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public sealed override string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


    #nullable enable
        public SponsoredMessage(byte[] randomId, CatraProto.Client.TL.Schemas.CloudChats.PeerBase fromId, string message)
        {
            RandomId = randomId;
            FromId = fromId;
            Message = message;
        }
    #nullable disable
        internal SponsoredMessage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ChannelPost == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = StartParam == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(RandomId);
            writer.Write(FromId);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ChannelPost.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(StartParam);
            }

            writer.Write(Message);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Entities);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RandomId = reader.Read<byte[]>();
            FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ChannelPost = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                StartParam = reader.Read<string>();
            }

            Message = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
            }
        }

        public override string ToString()
        {
            return "sponsoredMessage";
        }
    }
}