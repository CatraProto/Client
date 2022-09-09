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
    public partial class RequestSimpleWebView : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ThemeParams = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1790652275; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase ThemeParams { get; set; }


#nullable enable
        public RequestSimpleWebView(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, string url)
        {
            Bot = bot;
            Url = url;
        }
#nullable disable

        internal RequestSimpleWebView()
        {
        }

        public void UpdateFlags()
        {
            Flags = ThemeParams == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            writer.WriteString(Url);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkthemeParams = writer.WriteObject(ThemeParams);
                if (checkthemeParams.IsError)
                {
                    return checkthemeParams;
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
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }

            Bot = trybot.Value;
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trythemeParams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
                if (trythemeParams.IsError)
                {
                    return ReadResult<IObject>.Move(trythemeParams);
                }

                ThemeParams = trythemeParams.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.requestSimpleWebView";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestSimpleWebView();
            newClonedObject.Flags = Flags;
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }

            newClonedObject.Bot = cloneBot;
            newClonedObject.Url = Url;
            if (ThemeParams is not null)
            {
                var cloneThemeParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)ThemeParams.Clone();
                if (cloneThemeParams is null)
                {
                    return null;
                }

                newClonedObject.ThemeParams = cloneThemeParams;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestSimpleWebView castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
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

            if (ThemeParams is null && castedOther.ThemeParams is not null || ThemeParams is not null && castedOther.ThemeParams is null)
            {
                return true;
            }

            if (ThemeParams is not null && castedOther.ThemeParams is not null && ThemeParams.Compare(castedOther.ThemeParams))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}