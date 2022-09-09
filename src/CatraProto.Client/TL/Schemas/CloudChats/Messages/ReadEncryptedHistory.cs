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
    public partial class ReadEncryptedHistory : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2135648522; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public int MaxDate { get; set; }


#nullable enable
        public ReadEncryptedHistory(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, int maxDate)
        {
            Peer = peer;
            MaxDate = maxDate;
        }
#nullable disable

        internal ReadEncryptedHistory()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(MaxDate);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trymaxDate = reader.ReadInt32();
            if (trymaxDate.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDate);
            }

            MaxDate = trymaxDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.readEncryptedHistory";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReadEncryptedHistory();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MaxDate = MaxDate;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReadEncryptedHistory castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (MaxDate != castedOther.MaxDate)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}