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
    public partial class RequestEncryption : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -162681021; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public int RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a")] public byte[] GA { get; set; }


#nullable enable
        public RequestEncryption(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gA)
        {
            UserId = userId;
            RandomId = randomId;
            GA = gA;
        }
#nullable disable

        internal RequestEncryption()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            writer.WriteInt32(RandomId);

            writer.WriteBytes(GA);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
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
            var trygA = reader.ReadBytes();
            if (trygA.IsError)
            {
                return ReadResult<IObject>.Move(trygA);
            }

            GA = trygA.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.requestEncryption";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestEncryption();
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            newClonedObject.RandomId = RandomId;
            newClonedObject.GA = GA;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestEncryption castedOther)
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

            if (GA != castedOther.GA)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}