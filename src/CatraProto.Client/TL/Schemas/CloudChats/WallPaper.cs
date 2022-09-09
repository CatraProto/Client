using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WallPaper : CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Creator = 1 << 0,
            Default = 1 << 1,
            Pattern = 1 << 3,
            Dark = 1 << 4,
            Settings = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1539849235; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("creator")]
        public bool Creator { get; set; }

        [Newtonsoft.Json.JsonProperty("default")]
        public sealed override bool Default { get; set; }

        [Newtonsoft.Json.JsonProperty("pattern")]
        public bool Pattern { get; set; }

        [Newtonsoft.Json.JsonProperty("dark")] public sealed override bool Dark { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("slug")] public string Slug { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }


#nullable enable
        public WallPaper(long id, long accessHash, string slug, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase document)
        {
            Id = id;
            AccessHash = accessHash;
            Slug = slug;
            Document = document;
        }
#nullable disable
        internal WallPaper()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Pattern ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Dark ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(AccessHash);

            writer.WriteString(Slug);
            var checkdocument = writer.WriteObject(Document);
            if (checkdocument.IsError)
            {
                return checkdocument;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checksettings = writer.WriteObject(Settings);
                if (checksettings.IsError)
                {
                    return checksettings;
                }
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Creator = FlagsHelper.IsFlagSet(Flags, 0);
            Default = FlagsHelper.IsFlagSet(Flags, 1);
            Pattern = FlagsHelper.IsFlagSet(Flags, 3);
            Dark = FlagsHelper.IsFlagSet(Flags, 4);
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            var tryslug = reader.ReadString();
            if (tryslug.IsError)
            {
                return ReadResult<IObject>.Move(tryslug);
            }

            Slug = tryslug.Value;
            var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (trydocument.IsError)
            {
                return ReadResult<IObject>.Move(trydocument);
            }

            Document = trydocument.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();
                if (trysettings.IsError)
                {
                    return ReadResult<IObject>.Move(trysettings);
                }

                Settings = trysettings.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "wallPaper";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WallPaper();
            newClonedObject.Id = Id;
            newClonedObject.Flags = Flags;
            newClonedObject.Creator = Creator;
            newClonedObject.Default = Default;
            newClonedObject.Pattern = Pattern;
            newClonedObject.Dark = Dark;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Slug = Slug;
            var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
            if (cloneDocument is null)
            {
                return null;
            }

            newClonedObject.Document = cloneDocument;
            if (Settings is not null)
            {
                var cloneSettings = (CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase?)Settings.Clone();
                if (cloneSettings is null)
                {
                    return null;
                }

                newClonedObject.Settings = cloneSettings;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WallPaper castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Creator != castedOther.Creator)
            {
                return true;
            }

            if (Default != castedOther.Default)
            {
                return true;
            }

            if (Pattern != castedOther.Pattern)
            {
                return true;
            }

            if (Dark != castedOther.Dark)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (Slug != castedOther.Slug)
            {
                return true;
            }

            if (Document.Compare(castedOther.Document))
            {
                return true;
            }

            if (Settings is null && castedOther.Settings is not null || Settings is not null && castedOther.Settings is null)
            {
                return true;
            }

            if (Settings is not null && castedOther.Settings is not null && Settings.Compare(castedOther.Settings))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}