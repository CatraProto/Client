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
    public partial class MessageInteractionCounters : CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1387279939; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public sealed override int Views { get; set; }

        [Newtonsoft.Json.JsonProperty("forwards")]
        public sealed override int Forwards { get; set; }


#nullable enable
        public MessageInteractionCounters(int msgId, int views, int forwards)
        {
            MsgId = msgId;
            Views = views;
            Forwards = forwards;
        }
#nullable disable
        internal MessageInteractionCounters()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MsgId);
            writer.WriteInt32(Views);
            writer.WriteInt32(Forwards);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
            var tryviews = reader.ReadInt32();
            if (tryviews.IsError)
            {
                return ReadResult<IObject>.Move(tryviews);
            }

            Views = tryviews.Value;
            var tryforwards = reader.ReadInt32();
            if (tryforwards.IsError)
            {
                return ReadResult<IObject>.Move(tryforwards);
            }

            Forwards = tryforwards.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageInteractionCounters";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageInteractionCounters();
            newClonedObject.MsgId = MsgId;
            newClonedObject.Views = Views;
            newClonedObject.Forwards = Forwards;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageInteractionCounters castedOther)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (Views != castedOther.Views)
            {
                return true;
            }

            if (Forwards != castedOther.Forwards)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}