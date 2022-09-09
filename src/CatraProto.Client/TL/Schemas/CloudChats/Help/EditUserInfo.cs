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
    public partial class EditUserInfo : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1723407216; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


#nullable enable
        public EditUserInfo(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string message, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities)
        {
            UserId = userId;
            Message = message;
            Entities = entities;
        }
#nullable disable

        internal EditUserInfo()
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

            writer.WriteString(Message);
            var checkentities = writer.WriteVector(Entities, false);
            if (checkentities.IsError)
            {
                return checkentities;
            }

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
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryentities.IsError)
            {
                return ReadResult<IObject>.Move(tryentities);
            }

            Entities = tryentities.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.editUserInfo";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditUserInfo();
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            newClonedObject.Message = Message;
            newClonedObject.Entities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
            foreach (var entities in Entities)
            {
                var cloneentities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)entities.Clone();
                if (cloneentities is null)
                {
                    return null;
                }

                newClonedObject.Entities.Add(cloneentities);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditUserInfo castedOther)
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            var entitiessize = castedOther.Entities.Count;
            if (entitiessize != Entities.Count)
            {
                return true;
            }

            for (var i = 0; i < entitiessize; i++)
            {
                if (castedOther.Entities[i].Compare(Entities[i]))
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}