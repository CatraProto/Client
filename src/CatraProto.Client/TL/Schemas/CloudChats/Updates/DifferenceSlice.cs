using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class DifferenceSlice : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1459938943; }

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

        [Newtonsoft.Json.JsonProperty("intermediate_state")]
        public CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase IntermediateState { get; set; }


#nullable enable
        public DifferenceSlice(List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> newMessages, List<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase> newEncryptedMessages, List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> otherUpdates, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase intermediateState)
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

            var checkintermediateState = writer.WriteObject(IntermediateState);
            if (checkintermediateState.IsError)
            {
                return checkintermediateState;
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
            var tryintermediateState = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();
            if (tryintermediateState.IsError)
            {
                return ReadResult<IObject>.Move(tryintermediateState);
            }

            IntermediateState = tryintermediateState.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updates.differenceSlice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DifferenceSlice();
            newClonedObject.NewMessages = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            foreach (var newMessages in NewMessages)
            {
                var clonenewMessages = (CatraProto.Client.TL.Schemas.CloudChats.MessageBase?)newMessages.Clone();
                if (clonenewMessages is null)
                {
                    return null;
                }

                newClonedObject.NewMessages.Add(clonenewMessages);
            }

            newClonedObject.NewEncryptedMessages = new List<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase>();
            foreach (var newEncryptedMessages in NewEncryptedMessages)
            {
                var clonenewEncryptedMessages = (CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase?)newEncryptedMessages.Clone();
                if (clonenewEncryptedMessages is null)
                {
                    return null;
                }

                newClonedObject.NewEncryptedMessages.Add(clonenewEncryptedMessages);
            }

            newClonedObject.OtherUpdates = new List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            foreach (var otherUpdates in OtherUpdates)
            {
                var cloneotherUpdates = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)otherUpdates.Clone();
                if (cloneotherUpdates is null)
                {
                    return null;
                }

                newClonedObject.OtherUpdates.Add(cloneotherUpdates);
            }

            newClonedObject.Chats = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }

                newClonedObject.Chats.Add(clonechats);
            }

            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            var cloneIntermediateState = (CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase?)IntermediateState.Clone();
            if (cloneIntermediateState is null)
            {
                return null;
            }

            newClonedObject.IntermediateState = cloneIntermediateState;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DifferenceSlice castedOther)
            {
                return true;
            }

            var newMessagessize = castedOther.NewMessages.Count;
            if (newMessagessize != NewMessages.Count)
            {
                return true;
            }

            for (var i = 0; i < newMessagessize; i++)
            {
                if (castedOther.NewMessages[i].Compare(NewMessages[i]))
                {
                    return true;
                }
            }

            var newEncryptedMessagessize = castedOther.NewEncryptedMessages.Count;
            if (newEncryptedMessagessize != NewEncryptedMessages.Count)
            {
                return true;
            }

            for (var i = 0; i < newEncryptedMessagessize; i++)
            {
                if (castedOther.NewEncryptedMessages[i].Compare(NewEncryptedMessages[i]))
                {
                    return true;
                }
            }

            var otherUpdatessize = castedOther.OtherUpdates.Count;
            if (otherUpdatessize != OtherUpdates.Count)
            {
                return true;
            }

            for (var i = 0; i < otherUpdatessize; i++)
            {
                if (castedOther.OtherUpdates[i].Compare(OtherUpdates[i]))
                {
                    return true;
                }
            }

            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }

            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i].Compare(Chats[i]))
                {
                    return true;
                }
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            if (IntermediateState.Compare(castedOther.IntermediateState))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}