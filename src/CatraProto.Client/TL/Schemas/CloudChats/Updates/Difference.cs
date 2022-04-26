using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class Difference : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 16030880; }

        [Newtonsoft.Json.JsonProperty("new_messages")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> NewMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("new_encrypted_messages")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase> NewEncryptedMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("other_updates")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> OtherUpdates { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("state")]
        public CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase State { get; set; }


#nullable enable
        public Difference(List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> newMessages, List<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase> newEncryptedMessages, List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> otherUpdates, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase state)
        {
            NewMessages = newMessages;
            NewEncryptedMessages = newEncryptedMessages;
            OtherUpdates = otherUpdates;
            Chats = chats;
            Users = users;
            State = state;

        }
#nullable disable
        internal Difference()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checknewMessages = writer.WriteVector(NewMessages, false);
            if (checknewMessages.IsError)
            {
                return checknewMessages;
            }
            var checknewEncryptedMessages = writer.WriteVector(NewEncryptedMessages, false);
            if (checknewEncryptedMessages.IsError)
            {
                return checknewEncryptedMessages;
            }
            var checkotherUpdates = writer.WriteVector(OtherUpdates, false);
            if (checkotherUpdates.IsError)
            {
                return checkotherUpdates;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }
            var checkstate = writer.WriteObject(State);
            if (checkstate.IsError)
            {
                return checkstate;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynewMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trynewMessages.IsError)
            {
                return ReadResult<IObject>.Move(trynewMessages);
            }
            NewMessages = trynewMessages.Value;
            var trynewEncryptedMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trynewEncryptedMessages.IsError)
            {
                return ReadResult<IObject>.Move(trynewEncryptedMessages);
            }
            NewEncryptedMessages = trynewEncryptedMessages.Value;
            var tryotherUpdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryotherUpdates.IsError)
            {
                return ReadResult<IObject>.Move(tryotherUpdates);
            }
            OtherUpdates = tryotherUpdates.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            var trystate = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();
            if (trystate.IsError)
            {
                return ReadResult<IObject>.Move(trystate);
            }
            State = trystate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updates.difference";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Difference();
            foreach (var newMessages in NewMessages)
            {
                var clonenewMessages = (CatraProto.Client.TL.Schemas.CloudChats.MessageBase?)newMessages.Clone();
                if (clonenewMessages is null)
                {
                    return null;
                }
                newClonedObject.NewMessages.Add(clonenewMessages);
            }
            foreach (var newEncryptedMessages in NewEncryptedMessages)
            {
                var clonenewEncryptedMessages = (CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase?)newEncryptedMessages.Clone();
                if (clonenewEncryptedMessages is null)
                {
                    return null;
                }
                newClonedObject.NewEncryptedMessages.Add(clonenewEncryptedMessages);
            }
            foreach (var otherUpdates in OtherUpdates)
            {
                var cloneotherUpdates = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)otherUpdates.Clone();
                if (cloneotherUpdates is null)
                {
                    return null;
                }
                newClonedObject.OtherUpdates.Add(cloneotherUpdates);
            }
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }
                newClonedObject.Chats.Add(clonechats);
            }
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            var cloneState = (CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase?)State.Clone();
            if (cloneState is null)
            {
                return null;
            }
            newClonedObject.State = cloneState;
            return newClonedObject;

        }
#nullable disable
    }
}