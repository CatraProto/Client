using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineResult : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Title = 1 << 1,
            Description = 1 << 2,
            Url = 1 << 3,
            Thumb = 1 << 4,
            Content = 1 << 5
        }

        public static int StaticConstructorId
        {
            get => -2000710887;
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

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase Thumb { get; set; }

        [Newtonsoft.Json.JsonProperty("content")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase Content { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


    #nullable enable
        public InputBotInlineResult(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            SendMessage = sendMessage;
        }
    #nullable disable
        internal InputBotInlineResult()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = Content == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
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

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Url);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(Thumb);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.Write(Content);
            }

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

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Url = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                Thumb = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                Content = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
            }

            SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();
        }

        public override string ToString()
        {
            return "inputBotInlineResult";
        }
    }
}