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
    public partial class GetBotCallbackAnswer : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Game = 1 << 1,
            Data = 1 << 0,
            Password = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1824339449; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("game")] public bool Game { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public byte[] Data { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }


#nullable enable
        public GetBotCallbackAnswer(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId)
        {
            Peer = peer;
            MsgId = msgId;
        }
#nullable disable

        internal GetBotCallbackAnswer()
        {
        }

        public void UpdateFlags()
        {
            Flags = Game ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Password == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(MsgId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteBytes(Data);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkpassword = writer.WriteObject(Password);
                if (checkpassword.IsError)
                {
                    return checkpassword;
                }
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
            Game = FlagsHelper.IsFlagSet(Flags, 1);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydata = reader.ReadBytes();
                if (trydata.IsError)
                {
                    return ReadResult<IObject>.Move(trydata);
                }

                Data = trydata.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trypassword = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
                if (trypassword.IsError)
                {
                    return ReadResult<IObject>.Move(trypassword);
                }

                Password = trypassword.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getBotCallbackAnswer";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetBotCallbackAnswer();
            newClonedObject.Flags = Flags;
            newClonedObject.Game = Game;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            newClonedObject.Data = Data;
            if (Password is not null)
            {
                var clonePassword = (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase?)Password.Clone();
                if (clonePassword is null)
                {
                    return null;
                }

                newClonedObject.Password = clonePassword;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetBotCallbackAnswer castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Game != castedOther.Game)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            if (Password is null && castedOther.Password is not null || Password is not null && castedOther.Password is null)
            {
                return true;
            }

            if (Password is not null && castedOther.Password is not null && Password.Compare(castedOther.Password))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}