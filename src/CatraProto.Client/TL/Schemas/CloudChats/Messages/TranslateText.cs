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
    public partial class TranslateText : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Peer = 1 << 0,
            MsgId = 1 << 0,
            Text = 1 << 1,
            FromLang = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 617508334; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int? MsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_lang")]
        public string FromLang { get; set; }

        [Newtonsoft.Json.JsonProperty("to_lang")]
        public string ToLang { get; set; }


#nullable enable
        public TranslateText(string toLang)
        {
            ToLang = toLang;
        }
#nullable disable

        internal TranslateText()
        {
        }

        public void UpdateFlags()
        {
            Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Text == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = FromLang == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkpeer = writer.WriteObject(Peer);
                if (checkpeer.IsError)
                {
                    return checkpeer;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(MsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Text);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(FromLang);
            }


            writer.WriteString(ToLang);

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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
                if (trypeer.IsError)
                {
                    return ReadResult<IObject>.Move(trypeer);
                }

                Peer = trypeer.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
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
                var trytext = reader.ReadString();
                if (trytext.IsError)
                {
                    return ReadResult<IObject>.Move(trytext);
                }

                Text = trytext.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryfromLang = reader.ReadString();
                if (tryfromLang.IsError)
                {
                    return ReadResult<IObject>.Move(tryfromLang);
                }

                FromLang = tryfromLang.Value;
            }

            var trytoLang = reader.ReadString();
            if (trytoLang.IsError)
            {
                return ReadResult<IObject>.Move(trytoLang);
            }

            ToLang = trytoLang.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.translateText";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new TranslateText();
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
            newClonedObject.Text = Text;
            newClonedObject.FromLang = FromLang;
            newClonedObject.ToLang = ToLang;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not TranslateText castedOther)
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

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (FromLang != castedOther.FromLang)
            {
                return true;
            }

            if (ToLang != castedOther.ToLang)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}