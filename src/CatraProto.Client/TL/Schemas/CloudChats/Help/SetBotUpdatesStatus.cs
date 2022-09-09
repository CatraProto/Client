using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SetBotUpdatesStatus : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -333262899; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("pending_updates_count")]
        public int PendingUpdatesCount { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }


#nullable enable
        public SetBotUpdatesStatus(int pendingUpdatesCount, string message)
        {
            PendingUpdatesCount = pendingUpdatesCount;
            Message = message;
        }
#nullable disable

        internal SetBotUpdatesStatus()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(PendingUpdatesCount);

            writer.WriteString(Message);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypendingUpdatesCount = reader.ReadInt32();
            if (trypendingUpdatesCount.IsError)
            {
                return ReadResult<IObject>.Move(trypendingUpdatesCount);
            }

            PendingUpdatesCount = trypendingUpdatesCount.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.setBotUpdatesStatus";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotUpdatesStatus();
            newClonedObject.PendingUpdatesCount = PendingUpdatesCount;
            newClonedObject.Message = Message;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetBotUpdatesStatus castedOther)
            {
                return true;
            }

            if (PendingUpdatesCount != castedOther.PendingUpdatesCount)
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}