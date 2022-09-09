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
    public partial class InviteText : CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 415997816; }

        [Newtonsoft.Json.JsonProperty("message")]
        public sealed override string Message { get; set; }


#nullable enable
        public InviteText(string message)
        {
            Message = message;
        }
#nullable disable
        internal InviteText()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Message);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "help.inviteText";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InviteText();
            newClonedObject.Message = Message;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InviteText castedOther)
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