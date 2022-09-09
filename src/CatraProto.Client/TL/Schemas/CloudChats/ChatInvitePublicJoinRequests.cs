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
    public partial class ChatInvitePublicJoinRequests : CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -317687113; }


        public ChatInvitePublicJoinRequests()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatInvitePublicJoinRequests";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInvitePublicJoinRequests();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInvitePublicJoinRequests castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}