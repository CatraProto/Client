using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DiscardEncryption : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            DeleteHistory = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -208425312; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("delete_history")]
        public bool DeleteHistory { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public int ChatId { get; set; }


#nullable enable
        public DiscardEncryption(int chatId)
        {
            ChatId = chatId;
        }
#nullable disable

        internal DiscardEncryption()
        {
        }

        public void UpdateFlags()
        {
            Flags = DeleteHistory ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(ChatId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            DeleteHistory = FlagsHelper.IsFlagSet(Flags, 0);
            var trychatId = reader.ReadInt32();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.discardEncryption";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DiscardEncryption();
            newClonedObject.Flags = Flags;
            newClonedObject.DeleteHistory = DeleteHistory;
            newClonedObject.ChatId = ChatId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DiscardEncryption castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (DeleteHistory != castedOther.DeleteHistory)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}