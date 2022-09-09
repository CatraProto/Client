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
    public partial class WallPaperNoFile : CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Default = 1 << 1,
            Dark = 1 << 4,
            Settings = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -528465642; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("default")]
        public sealed override bool Default { get; set; }

        [Newtonsoft.Json.JsonProperty("dark")] public sealed override bool Dark { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }


#nullable enable
        public WallPaperNoFile(long id)
        {
            Id = id;
        }
#nullable disable
        internal WallPaperNoFile()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Dark ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            UpdateFlags();

            writer.WriteInt32(Flags);
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
            Default = FlagsHelper.IsFlagSet(Flags, 1);
            Dark = FlagsHelper.IsFlagSet(Flags, 4);
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
            return "wallPaperNoFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WallPaperNoFile();
            newClonedObject.Id = Id;
            newClonedObject.Flags = Flags;
            newClonedObject.Default = Default;
            newClonedObject.Dark = Dark;
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
            if (other is not WallPaperNoFile castedOther)
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

            if (Default != castedOther.Default)
            {
                return true;
            }

            if (Dark != castedOther.Dark)
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