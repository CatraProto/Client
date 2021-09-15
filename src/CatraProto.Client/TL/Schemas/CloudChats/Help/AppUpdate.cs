using System;
using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class AppUpdate : AppUpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanNotSkip = 1 << 0,
            Document = 1 << 1,
            Url = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => 497489295;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("can_not_skip")] public bool CanNotSkip { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("version")] public string Version { get; set; }

        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("entities")] public IList<MessageEntityBase> Entities { get; set; }

        [JsonProperty("document")] public DocumentBase Document { get; set; }

        [JsonProperty("url")] public string Url { get; set; }


        public override void UpdateFlags()
        {
            Flags = CanNotSkip ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Version);
            writer.Write(Text);
            writer.Write(Entities);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Document);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Url);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CanNotSkip = FlagsHelper.IsFlagSet(Flags, 0);
            Id = reader.Read<int>();
            Version = reader.Read<string>();
            Text = reader.Read<string>();
            Entities = reader.ReadVector<MessageEntityBase>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Document = reader.Read<DocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Url = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "help.appUpdate";
        }
    }
}