using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputSingleMedia : CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Entities = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 482797855;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("media")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public sealed override long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public sealed override string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


    #nullable enable
        public InputSingleMedia(CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, long randomId, string message)
        {
            Media = media;
            RandomId = randomId;
            Message = message;
        }
    #nullable disable
        internal InputSingleMedia()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Media);
            writer.Write(RandomId);
            writer.Write(Message);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Entities);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
            RandomId = reader.Read<long>();
            Message = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
            }
        }

        public override string ToString()
        {
            return "inputSingleMedia";
        }
    }
}