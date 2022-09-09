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
    public partial class UpdateUserTyping : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1071741569; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("action")]
        public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }


#nullable enable
        public UpdateUserTyping(long userId, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action)
        {
            UserId = userId;
            Action = action;
        }
#nullable disable
        internal UpdateUserTyping()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            var checkaction = writer.WriteObject(Action);
            if (checkaction.IsError)
            {
                return checkaction;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryaction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();
            if (tryaction.IsError)
            {
                return ReadResult<IObject>.Move(tryaction);
            }

            Action = tryaction.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateUserTyping";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateUserTyping();
            newClonedObject.UserId = UserId;
            var cloneAction = (CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase?)Action.Clone();
            if (cloneAction is null)
            {
                return null;
            }

            newClonedObject.Action = cloneAction;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateUserTyping castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Action.Compare(castedOther.Action))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}