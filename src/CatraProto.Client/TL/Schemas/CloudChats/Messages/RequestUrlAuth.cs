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
    public partial class RequestUrlAuth : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Peer = 1 << 1,
            MsgId = 1 << 1,
            ButtonId = 1 << 1,
            Url = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 428848198; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int? MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("button_id")]
        public int? ButtonId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }


        public RequestUrlAuth()
        {
        }

        public void UpdateFlags()
        {
            Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ButtonId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkpeer = writer.WriteObject(Peer);
                if (checkpeer.IsError)
                {
                    return checkpeer;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(MsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(ButtonId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Url);
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
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
                if (trypeer.IsError)
                {
                    return ReadResult<IObject>.Move(trypeer);
                }

                Peer = trypeer.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trymsgId = reader.ReadInt32();
                if (trymsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trymsgId);
                }

                MsgId = trymsgId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trybuttonId = reader.ReadInt32();
                if (trybuttonId.IsError)
                {
                    return ReadResult<IObject>.Move(trybuttonId);
                }

                ButtonId = trybuttonId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }

                Url = tryurl.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.requestUrlAuth";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestUrlAuth();
            newClonedObject.Flags = Flags;
            if (Peer is not null)
            {
                var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
                if (clonePeer is null)
                {
                    return null;
                }

                newClonedObject.Peer = clonePeer;
            }

            newClonedObject.MsgId = MsgId;
            newClonedObject.ButtonId = ButtonId;
            newClonedObject.Url = Url;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestUrlAuth castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Peer is null && castedOther.Peer is not null || Peer is not null && castedOther.Peer is null)
            {
                return true;
            }

            if (Peer is not null && castedOther.Peer is not null && Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (ButtonId != castedOther.ButtonId)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}