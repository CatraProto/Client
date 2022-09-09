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
    public partial class GlobalPrivacySettings : CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ArchiveAndMuteNewNoncontactPeers = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1096616924; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("archive_and_mute_new_noncontact_peers")]
        public sealed override bool? ArchiveAndMuteNewNoncontactPeers { get; set; }


        public GlobalPrivacySettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ArchiveAndMuteNewNoncontactPeers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkarchiveAndMuteNewNoncontactPeers = writer.WriteBool(ArchiveAndMuteNewNoncontactPeers.Value);
                if (checkarchiveAndMuteNewNoncontactPeers.IsError)
                {
                    return checkarchiveAndMuteNewNoncontactPeers;
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryarchiveAndMuteNewNoncontactPeers = reader.ReadBool();
                if (tryarchiveAndMuteNewNoncontactPeers.IsError)
                {
                    return ReadResult<IObject>.Move(tryarchiveAndMuteNewNoncontactPeers);
                }

                ArchiveAndMuteNewNoncontactPeers = tryarchiveAndMuteNewNoncontactPeers.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "globalPrivacySettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GlobalPrivacySettings();
            newClonedObject.Flags = Flags;
            newClonedObject.ArchiveAndMuteNewNoncontactPeers = ArchiveAndMuteNewNoncontactPeers;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GlobalPrivacySettings castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ArchiveAndMuteNewNoncontactPeers != castedOther.ArchiveAndMuteNewNoncontactPeers)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}