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
    public partial class LeaveGroupCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1342404601; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("source")]
        public int Source { get; set; }


#nullable enable
        public LeaveGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, int source)
        {
            Call = call;
            Source = source;
        }
#nullable disable

        internal LeaveGroupCall()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            writer.WriteInt32(Source);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            var trysource = reader.ReadInt32();
            if (trysource.IsError)
            {
                return ReadResult<IObject>.Move(trysource);
            }

            Source = trysource.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.leaveGroupCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new LeaveGroupCall();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.Source = Source;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not LeaveGroupCall castedOther)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (Source != castedOther.Source)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}