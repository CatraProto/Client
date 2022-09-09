using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ToggleStickerSets : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Uninstall = 1 << 0,
            Archive = 1 << 1,
            Unarchive = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1257951254; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("uninstall")]
        public bool Uninstall { get; set; }

        [Newtonsoft.Json.JsonProperty("archive")]
        public bool Archive { get; set; }

        [Newtonsoft.Json.JsonProperty("unarchive")]
        public bool Unarchive { get; set; }

        [Newtonsoft.Json.JsonProperty("stickersets")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> Stickersets { get; set; }


#nullable enable
        public ToggleStickerSets(List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> stickersets)
        {
            Stickersets = stickersets;
        }
#nullable disable

        internal ToggleStickerSets()
        {
        }

        public void UpdateFlags()
        {
            Flags = Uninstall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Archive ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Unarchive ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkstickersets = writer.WriteVector(Stickersets, false);
            if (checkstickersets.IsError)
            {
                return checkstickersets;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Uninstall = FlagsHelper.IsFlagSet(Flags, 0);
            Archive = FlagsHelper.IsFlagSet(Flags, 1);
            Unarchive = FlagsHelper.IsFlagSet(Flags, 2);
            var trystickersets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystickersets.IsError)
            {
                return ReadResult<IObject>.Move(trystickersets);
            }

            Stickersets = trystickersets.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.toggleStickerSets";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleStickerSets();
            newClonedObject.Flags = Flags;
            newClonedObject.Uninstall = Uninstall;
            newClonedObject.Archive = Archive;
            newClonedObject.Unarchive = Unarchive;
            newClonedObject.Stickersets = new List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            foreach (var stickersets in Stickersets)
            {
                var clonestickersets = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)stickersets.Clone();
                if (clonestickersets is null)
                {
                    return null;
                }

                newClonedObject.Stickersets.Add(clonestickersets);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleStickerSets castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Uninstall != castedOther.Uninstall)
            {
                return true;
            }

            if (Archive != castedOther.Archive)
            {
                return true;
            }

            if (Unarchive != castedOther.Unarchive)
            {
                return true;
            }

            var stickersetssize = castedOther.Stickersets.Count;
            if (stickersetssize != Stickersets.Count)
            {
                return true;
            }

            for (var i = 0; i < stickersetssize; i++)
            {
                if (castedOther.Stickersets[i].Compare(Stickersets[i]))
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}