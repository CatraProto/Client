using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineResultDocument : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Title = 1 << 1,
            Description = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => -459324;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


    #nullable enable
        public InputBotInlineResultDocument(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase document, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            Document = document;
            SendMessage = sendMessage;
        }
    #nullable disable
        internal InputBotInlineResultDocument()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Type);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Description);
            }

            writer.Write(Document);
            writer.Write(SendMessage);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<string>();
            Type = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Title = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Description = reader.Read<string>();
            }

            Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();
        }

        public override string ToString()
        {
            return "inputBotInlineResultDocument";
        }
    }
}