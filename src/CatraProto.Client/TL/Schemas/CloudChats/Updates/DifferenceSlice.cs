using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class DifferenceSlice : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {
        public static int StaticConstructorId
        {
            get => -1459938943;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("new_messages")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> NewMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("new_encrypted_messages")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase> NewEncryptedMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("other_updates")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> OtherUpdates { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("intermediate_state")]
        public CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase IntermediateState { get; set; }


    #nullable enable
        public DifferenceSlice(IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> newMessages, IList<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase> newEncryptedMessages, IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> otherUpdates, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase intermediateState)
        {
            NewMessages = newMessages;
            NewEncryptedMessages = newEncryptedMessages;
            OtherUpdates = otherUpdates;
            Chats = chats;
            Users = users;
            IntermediateState = intermediateState;
        }
    #nullable disable
        internal DifferenceSlice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(NewMessages);
            writer.Write(NewEncryptedMessages);
            writer.Write(OtherUpdates);
            writer.Write(Chats);
            writer.Write(Users);
            writer.Write(IntermediateState);
        }

        public override void Deserialize(Reader reader)
        {
            NewMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            NewEncryptedMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase>();
            OtherUpdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            IntermediateState = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();
        }

        public override string ToString()
        {
            return "updates.differenceSlice";
        }
    }
}