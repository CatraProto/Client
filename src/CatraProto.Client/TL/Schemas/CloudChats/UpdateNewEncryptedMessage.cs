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
    public partial class UpdateNewEncryptedMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 314359194; }

        [Newtonsoft.Json.JsonProperty("message")]
        public CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase Message { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


#nullable enable
        public UpdateNewEncryptedMessage(CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase message, int qts)
        {
            Message = message;
            Qts = qts;
        }
#nullable disable
        internal UpdateNewEncryptedMessage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmessage = writer.WriteObject(Message);
            if (checkmessage.IsError)
            {
                return checkmessage;
            }

            writer.WriteInt32(Qts);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase>();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }

            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateNewEncryptedMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateNewEncryptedMessage();
            var cloneMessage = (CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase?)Message.Clone();
            if (cloneMessage is null)
            {
                return null;
            }

            newClonedObject.Message = cloneMessage;
            newClonedObject.Qts = Qts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateNewEncryptedMessage castedOther)
            {
                return true;
            }

            if (Message.Compare(castedOther.Message))
            {
                return true;
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}