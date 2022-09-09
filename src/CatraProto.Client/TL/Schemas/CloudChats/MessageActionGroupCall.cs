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
    public partial class MessageActionGroupCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Duration = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2047704898; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }


#nullable enable
        public MessageActionGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
        {
            Call = call;
        }
#nullable disable
        internal MessageActionGroupCall()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(Duration.Value);
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
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryduration = reader.ReadInt32();
                if (tryduration.IsError)
                {
                    return ReadResult<IObject>.Move(tryduration);
                }

                Duration = tryduration.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionGroupCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionGroupCall();
            newClonedObject.Flags = Flags;
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.Duration = Duration;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionGroupCall castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (Duration != castedOther.Duration)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}