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
    public partial class ReceivedQueue : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1436924774; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Int64;

        [Newtonsoft.Json.JsonProperty("max_qts")]
        public int MaxQts { get; set; }


#nullable enable
        public ReceivedQueue(int maxQts)
        {
            MaxQts = maxQts;
        }
#nullable disable

        internal ReceivedQueue()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MaxQts);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymaxQts = reader.ReadInt32();
            if (trymaxQts.IsError)
            {
                return ReadResult<IObject>.Move(trymaxQts);
            }

            MaxQts = trymaxQts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.receivedQueue";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReceivedQueue();
            newClonedObject.MaxQts = MaxQts;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReceivedQueue castedOther)
            {
                return true;
            }

            if (MaxQts != castedOther.MaxQts)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}