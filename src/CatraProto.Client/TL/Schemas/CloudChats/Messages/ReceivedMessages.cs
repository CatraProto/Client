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
    public partial class ReceivedMessages : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 94983360; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }


#nullable enable
        public ReceivedMessages(int maxId)
        {
            MaxId = maxId;
        }
#nullable disable

        internal ReceivedMessages()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MaxId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.receivedMessages";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReceivedMessages();
            newClonedObject.MaxId = MaxId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReceivedMessages castedOther)
            {
                return true;
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}