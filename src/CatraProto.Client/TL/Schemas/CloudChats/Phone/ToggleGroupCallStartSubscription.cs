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
    public partial class ToggleGroupCallStartSubscription : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 563885286; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("subscribed")]
        public bool Subscribed { get; set; }


#nullable enable
        public ToggleGroupCallStartSubscription(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, bool subscribed)
        {
            Call = call;
            Subscribed = subscribed;
        }
#nullable disable

        internal ToggleGroupCallStartSubscription()
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

            var checksubscribed = writer.WriteBool(Subscribed);
            if (checksubscribed.IsError)
            {
                return checksubscribed;
            }

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
            var trysubscribed = reader.ReadBool();
            if (trysubscribed.IsError)
            {
                return ReadResult<IObject>.Move(trysubscribed);
            }

            Subscribed = trysubscribed.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.toggleGroupCallStartSubscription";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleGroupCallStartSubscription();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.Subscribed = Subscribed;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleGroupCallStartSubscription castedOther)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (Subscribed != castedOther.Subscribed)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}