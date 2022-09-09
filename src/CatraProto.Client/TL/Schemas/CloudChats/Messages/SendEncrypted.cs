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
    public partial class SendEncrypted : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1157265941; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public byte[] Data { get; set; }


#nullable enable
        public SendEncrypted(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data)
        {
            Peer = peer;
            RandomId = randomId;
            Data = data;
        }
#nullable disable

        internal SendEncrypted()
        {
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt64(RandomId);

            writer.WriteBytes(Data);

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
            Silent = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryrandomId = reader.ReadInt64();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendEncrypted";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendEncrypted();
            newClonedObject.Flags = Flags;
            newClonedObject.Silent = Silent;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.RandomId = RandomId;
            newClonedObject.Data = Data;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendEncrypted castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Silent != castedOther.Silent)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}