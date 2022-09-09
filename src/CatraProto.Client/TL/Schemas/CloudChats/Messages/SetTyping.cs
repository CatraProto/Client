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
    public partial class SetTyping : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            TopMsgId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1486110434; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("top_msg_id")]
        public int? TopMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("action")]
        public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }


#nullable enable
        public SetTyping(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action)
        {
            Peer = peer;
            Action = action;
        }
#nullable disable

        internal SetTyping()
        {
        }

        public void UpdateFlags()
        {
            Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
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

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TopMsgId.Value);
            }

            var checkaction = writer.WriteObject(Action);
            if (checkaction.IsError)
            {
                return checkaction;
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
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytopMsgId = reader.ReadInt32();
                if (trytopMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trytopMsgId);
                }

                TopMsgId = trytopMsgId.Value;
            }

            var tryaction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();
            if (tryaction.IsError)
            {
                return ReadResult<IObject>.Move(tryaction);
            }

            Action = tryaction.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setTyping";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetTyping();
            newClonedObject.Flags = Flags;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.TopMsgId = TopMsgId;
            var cloneAction = (CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase?)Action.Clone();
            if (cloneAction is null)
            {
                return null;
            }

            newClonedObject.Action = cloneAction;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetTyping castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (TopMsgId != castedOther.TopMsgId)
            {
                return true;
            }

            if (Action.Compare(castedOther.Action))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}