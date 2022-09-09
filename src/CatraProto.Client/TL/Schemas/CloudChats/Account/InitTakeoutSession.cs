using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class InitTakeoutSession : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Contacts = 1 << 0,
            MessageUsers = 1 << 1,
            MessageChats = 1 << 2,
            MessageMegagroups = 1 << 3,
            MessageChannels = 1 << 4,
            Files = 1 << 5,
            FileMaxSize = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1896617296; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("contacts")]
        public bool Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("message_users")]
        public bool MessageUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("message_chats")]
        public bool MessageChats { get; set; }

        [Newtonsoft.Json.JsonProperty("message_megagroups")]
        public bool MessageMegagroups { get; set; }

        [Newtonsoft.Json.JsonProperty("message_channels")]
        public bool MessageChannels { get; set; }

        [Newtonsoft.Json.JsonProperty("files")]
        public bool Files { get; set; }

        [Newtonsoft.Json.JsonProperty("file_max_size")]
        public long? FileMaxSize { get; set; }


        public InitTakeoutSession()
        {
        }

        public void UpdateFlags()
        {
            Flags = Contacts ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = MessageUsers ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = MessageChats ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = MessageMegagroups ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = MessageChannels ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Files ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = FileMaxSize == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt64(FileMaxSize.Value);
            }


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
            Contacts = FlagsHelper.IsFlagSet(Flags, 0);
            MessageUsers = FlagsHelper.IsFlagSet(Flags, 1);
            MessageChats = FlagsHelper.IsFlagSet(Flags, 2);
            MessageMegagroups = FlagsHelper.IsFlagSet(Flags, 3);
            MessageChannels = FlagsHelper.IsFlagSet(Flags, 4);
            Files = FlagsHelper.IsFlagSet(Flags, 5);
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryfileMaxSize = reader.ReadInt64();
                if (tryfileMaxSize.IsError)
                {
                    return ReadResult<IObject>.Move(tryfileMaxSize);
                }

                FileMaxSize = tryfileMaxSize.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.initTakeoutSession";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InitTakeoutSession();
            newClonedObject.Flags = Flags;
            newClonedObject.Contacts = Contacts;
            newClonedObject.MessageUsers = MessageUsers;
            newClonedObject.MessageChats = MessageChats;
            newClonedObject.MessageMegagroups = MessageMegagroups;
            newClonedObject.MessageChannels = MessageChannels;
            newClonedObject.Files = Files;
            newClonedObject.FileMaxSize = FileMaxSize;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InitTakeoutSession castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Contacts != castedOther.Contacts)
            {
                return true;
            }

            if (MessageUsers != castedOther.MessageUsers)
            {
                return true;
            }

            if (MessageChats != castedOther.MessageChats)
            {
                return true;
            }

            if (MessageMegagroups != castedOther.MessageMegagroups)
            {
                return true;
            }

            if (MessageChannels != castedOther.MessageChannels)
            {
                return true;
            }

            if (Files != castedOther.Files)
            {
                return true;
            }

            if (FileMaxSize != castedOther.FileMaxSize)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}