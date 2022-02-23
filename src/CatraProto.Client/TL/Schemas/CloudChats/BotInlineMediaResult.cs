using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotInlineMediaResult : CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Photo = 1 << 0,
            Document = 1 << 1,
            Title = 1 << 2,
            Description = 1 << 3
        }

        public static int StaticConstructorId
        {
            get => 400266251;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }


    #nullable enable
        public BotInlineMediaResult(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            SendMessage = sendMessage;
        }
    #nullable disable
        internal BotInlineMediaResult()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Type);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Photo);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Document);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Description);
            }

            writer.Write(SendMessage);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<string>();
            Type = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Title = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Description = reader.Read<string>();
            }

            SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase>();
        }

        public override string ToString()
        {
            return "botInlineMediaResult";
        }
    }
}