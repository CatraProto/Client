using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Folder : CatraProto.Client.TL.Schemas.CloudChats.FolderBase
    {
        [Flags]
        public enum FlagsEnum
        {
            AutofillNewBroadcasts = 1 << 0,
            AutofillPublicGroups = 1 << 1,
            AutofillNewCorrespondents = 1 << 2,
            Photo = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -11252123; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("autofill_new_broadcasts")]
        public sealed override bool AutofillNewBroadcasts { get; set; }

        [Newtonsoft.Json.JsonProperty("autofill_public_groups")]
        public sealed override bool AutofillPublicGroups { get; set; }

        [Newtonsoft.Json.JsonProperty("autofill_new_correspondents")]
        public sealed override bool AutofillNewCorrespondents { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase Photo { get; set; }


#nullable enable
        public Folder(int id, string title)
        {
            Id = id;
            Title = title;

        }
#nullable disable
        internal Folder()
        {
        }

        public override void UpdateFlags()
        {
            Flags = AutofillNewBroadcasts ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = AutofillPublicGroups ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = AutofillNewCorrespondents ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);

            writer.WriteString(Title);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
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
            AutofillNewBroadcasts = FlagsHelper.IsFlagSet(Flags, 0);
            AutofillPublicGroups = FlagsHelper.IsFlagSet(Flags, 1);
            AutofillNewCorrespondents = FlagsHelper.IsFlagSet(Flags, 2);
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }
                Photo = tryphoto.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "folder";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}