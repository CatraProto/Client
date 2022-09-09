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
    public partial class RequestCall : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1124046573; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public int RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a_hash")]
        public byte[] GAHash { get; set; }

        [Newtonsoft.Json.JsonProperty("protocol")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


#nullable enable
        public RequestCall(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gAHash, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
        {
            UserId = userId;
            RandomId = randomId;
            GAHash = gAHash;
            Protocol = protocol;
        }
#nullable disable

        internal RequestCall()
        {
        }

        public void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            writer.WriteInt32(RandomId);

            writer.WriteBytes(GAHash);
            var checkprotocol = writer.WriteObject(Protocol);
            if (checkprotocol.IsError)
            {
                return checkprotocol;
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
            Video = FlagsHelper.IsFlagSet(Flags, 0);
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryrandomId = reader.ReadInt32();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trygAHash = reader.ReadBytes();
            if (trygAHash.IsError)
            {
                return ReadResult<IObject>.Move(trygAHash);
            }

            GAHash = trygAHash.Value;
            var tryprotocol = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
            if (tryprotocol.IsError)
            {
                return ReadResult<IObject>.Move(tryprotocol);
            }

            Protocol = tryprotocol.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.requestCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestCall();
            newClonedObject.Flags = Flags;
            newClonedObject.Video = Video;
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            newClonedObject.RandomId = RandomId;
            newClonedObject.GAHash = GAHash;
            var cloneProtocol = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase?)Protocol.Clone();
            if (cloneProtocol is null)
            {
                return null;
            }

            newClonedObject.Protocol = cloneProtocol;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestCall castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Video != castedOther.Video)
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            if (GAHash != castedOther.GAHash)
            {
                return true;
            }

            if (Protocol.Compare(castedOther.Protocol))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}