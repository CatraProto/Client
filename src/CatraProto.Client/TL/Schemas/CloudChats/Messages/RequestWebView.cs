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
    public partial class RequestWebView : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            FromBotMenu = 1 << 4,
            Silent = 1 << 5,
            Url = 1 << 1,
            StartParam = 1 << 3,
            ThemeParams = 1 << 2,
            ReplyToMsgId = 1 << 0,
            SendAs = 1 << 13
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1850648527; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("from_bot_menu")]
        public bool FromBotMenu { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("start_param")]
        public string StartParam { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase ThemeParams { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int? ReplyToMsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("send_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase SendAs { get; set; }


#nullable enable
        public RequestWebView(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot)
        {
            Peer = peer;
            Bot = bot;
        }
#nullable disable

        internal RequestWebView()
        {
        }

        public void UpdateFlags()
        {
            Flags = FromBotMenu ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = StartParam == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = ThemeParams == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SendAs == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
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

            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Url);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(StartParam);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkthemeParams = writer.WriteObject(ThemeParams);
                if (checkthemeParams.IsError)
                {
                    return checkthemeParams;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(ReplyToMsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var checksendAs = writer.WriteObject(SendAs);
                if (checksendAs.IsError)
                {
                    return checksendAs;
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
            FromBotMenu = FlagsHelper.IsFlagSet(Flags, 4);
            Silent = FlagsHelper.IsFlagSet(Flags, 5);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }

            Bot = trybot.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }

                Url = tryurl.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trystartParam = reader.ReadString();
                if (trystartParam.IsError)
                {
                    return ReadResult<IObject>.Move(trystartParam);
                }

                StartParam = trystartParam.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trythemeParams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
                if (trythemeParams.IsError)
                {
                    return ReadResult<IObject>.Move(trythemeParams);
                }

                ThemeParams = trythemeParams.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreplyToMsgId = reader.ReadInt32();
                if (tryreplyToMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyToMsgId);
                }

                ReplyToMsgId = tryreplyToMsgId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var trysendAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
                if (trysendAs.IsError)
                {
                    return ReadResult<IObject>.Move(trysendAs);
                }

                SendAs = trysendAs.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.requestWebView";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestWebView();
            newClonedObject.Flags = Flags;
            newClonedObject.FromBotMenu = FromBotMenu;
            newClonedObject.Silent = Silent;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }

            newClonedObject.Bot = cloneBot;
            newClonedObject.Url = Url;
            newClonedObject.StartParam = StartParam;
            if (ThemeParams is not null)
            {
                var cloneThemeParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)ThemeParams.Clone();
                if (cloneThemeParams is null)
                {
                    return null;
                }

                newClonedObject.ThemeParams = cloneThemeParams;
            }

            newClonedObject.ReplyToMsgId = ReplyToMsgId;
            if (SendAs is not null)
            {
                var cloneSendAs = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)SendAs.Clone();
                if (cloneSendAs is null)
                {
                    return null;
                }

                newClonedObject.SendAs = cloneSendAs;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestWebView castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (FromBotMenu != castedOther.FromBotMenu)
            {
                return true;
            }

            if (Silent != castedOther.Silent)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Bot.Compare(castedOther.Bot))
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (StartParam != castedOther.StartParam)
            {
                return true;
            }

            if (ThemeParams is null && castedOther.ThemeParams is not null || ThemeParams is not null && castedOther.ThemeParams is null)
            {
                return true;
            }

            if (ThemeParams is not null && castedOther.ThemeParams is not null && ThemeParams.Compare(castedOther.ThemeParams))
            {
                return true;
            }

            if (ReplyToMsgId != castedOther.ReplyToMsgId)
            {
                return true;
            }

            if (SendAs is null && castedOther.SendAs is not null || SendAs is not null && castedOther.SendAs is null)
            {
                return true;
            }

            if (SendAs is not null && castedOther.SendAs is not null && SendAs.Compare(castedOther.SendAs))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}