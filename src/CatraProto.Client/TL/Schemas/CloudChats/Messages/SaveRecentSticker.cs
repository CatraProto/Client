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
    public partial class SaveRecentSticker : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Attached = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 958863608; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("attached")]
        public bool Attached { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("unsave")]
        public bool Unsave { get; set; }


#nullable enable
        public SaveRecentSticker(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave)
        {
            Id = id;
            Unsave = unsave;
        }
#nullable disable

        internal SaveRecentSticker()
        {
        }

        public void UpdateFlags()
        {
            Flags = Attached ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            var checkunsave = writer.WriteBool(Unsave);
            if (checkunsave.IsError)
            {
                return checkunsave;
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
            Attached = FlagsHelper.IsFlagSet(Flags, 0);
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryunsave = reader.ReadBool();
            if (tryunsave.IsError)
            {
                return ReadResult<IObject>.Move(tryunsave);
            }

            Unsave = tryunsave.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.saveRecentSticker";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveRecentSticker();
            newClonedObject.Flags = Flags;
            newClonedObject.Attached = Attached;
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.Unsave = Unsave;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveRecentSticker castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Attached != castedOther.Attached)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            if (Unsave != castedOther.Unsave)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}