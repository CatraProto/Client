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
    public partial class UpdateEncryption : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1264392051; }

        [Newtonsoft.Json.JsonProperty("chat")] public CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


#nullable enable
        public UpdateEncryption(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase chat, int date)
        {
            Chat = chat;
            Date = date;
        }
#nullable disable
        internal UpdateEncryption()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchat = writer.WriteObject(Chat);
            if (checkchat.IsError)
            {
                return checkchat;
            }

            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychat = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>();
            if (trychat.IsError)
            {
                return ReadResult<IObject>.Move(trychat);
            }

            Chat = trychat.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateEncryption";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateEncryption();
            var cloneChat = (CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase?)Chat.Clone();
            if (cloneChat is null)
            {
                return null;
            }

            newClonedObject.Chat = cloneChat;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateEncryption castedOther)
            {
                return true;
            }

            if (Chat.Compare(castedOther.Chat))
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}