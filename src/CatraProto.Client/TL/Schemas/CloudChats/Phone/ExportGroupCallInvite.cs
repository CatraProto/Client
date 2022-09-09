using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class ExportGroupCallInvite : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            CanSelfUnmute = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -425040769; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_self_unmute")]
        public bool CanSelfUnmute { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }


#nullable enable
        public ExportGroupCallInvite(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
        {
            Call = call;
        }
#nullable disable

        internal ExportGroupCallInvite()
        {
        }

        public void UpdateFlags()
        {
            Flags = CanSelfUnmute ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
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
            CanSelfUnmute = FlagsHelper.IsFlagSet(Flags, 0);
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.exportGroupCallInvite";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ExportGroupCallInvite();
            newClonedObject.Flags = Flags;
            newClonedObject.CanSelfUnmute = CanSelfUnmute;
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ExportGroupCallInvite castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CanSelfUnmute != castedOther.CanSelfUnmute)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}