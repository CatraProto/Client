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
    public partial class InstallStickerSet : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -946871200; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("archived")]
        public bool Archived { get; set; }


#nullable enable
        public InstallStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, bool archived)
        {
            Stickerset = stickerset;
            Archived = archived;
        }
#nullable disable

        internal InstallStickerSet()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }

            var checkarchived = writer.WriteBool(Archived);
            if (checkarchived.IsError)
            {
                return checkarchived;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }

            Stickerset = trystickerset.Value;
            var tryarchived = reader.ReadBool();
            if (tryarchived.IsError)
            {
                return ReadResult<IObject>.Move(tryarchived);
            }

            Archived = tryarchived.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.installStickerSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InstallStickerSet();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }

            newClonedObject.Stickerset = cloneStickerset;
            newClonedObject.Archived = Archived;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InstallStickerSet castedOther)
            {
                return true;
            }

            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            if (Archived != castedOther.Archived)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}