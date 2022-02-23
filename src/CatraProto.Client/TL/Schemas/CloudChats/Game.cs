using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Game : CatraProto.Client.TL.Schemas.CloudChats.GameBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Document = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1107729093;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public sealed override string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }


    #nullable enable
        public Game(long id, long accessHash, string shortName, string title, string description, CatraProto.Client.TL.Schemas.CloudChats.PhotoBase photo)
        {
            Id = id;
            AccessHash = accessHash;
            ShortName = shortName;
            Title = title;
            Description = description;
            Photo = photo;
        }
    #nullable disable
        internal Game()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(ShortName);
            writer.Write(Title);
            writer.Write(Description);
            writer.Write(Photo);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Document);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
            ShortName = reader.Read<string>();
            Title = reader.Read<string>();
            Description = reader.Read<string>();
            Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            }
        }

        public override string ToString()
        {
            return "game";
        }
    }
}