using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1107729093; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

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

        [MaybeNull]
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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            writer.WriteString(ShortName);

            writer.WriteString(Title);

            writer.WriteString(Description);
            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkdocument = writer.WriteObject(Document);
                if (checkdocument.IsError)
                {
                    return checkdocument;
                }
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }
            AccessHash = tryaccessHash.Value;
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }
            Description = trydescription.Value;
            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }
            Photo = tryphoto.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trydocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydocument);
                }
                Document = trydocument.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "game";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}