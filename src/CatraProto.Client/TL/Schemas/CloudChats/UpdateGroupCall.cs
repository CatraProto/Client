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
    public partial class UpdateGroupCall : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 347227392; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase Call { get; set; }


#nullable enable
        public UpdateGroupCall(long chatId, CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase call)
        {
            ChatId = chatId;
            Call = call;
        }
#nullable disable
        internal UpdateGroupCall()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateGroupCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateGroupCall();
            newClonedObject.ChatId = ChatId;
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateGroupCall castedOther)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}