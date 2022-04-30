/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineResult : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Title = 1 << 1,
            Description = 1 << 2,
            Url = 1 << 3,
            Thumb = 1 << 4,
            Content = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2000710887; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase Thumb { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("content")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase Content { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


#nullable enable
        public InputBotInlineResult(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            SendMessage = sendMessage;

        }
#nullable disable
        internal InputBotInlineResult()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = Content == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Id);

            writer.WriteString(Type);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteString(Description);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {

                writer.WriteString(Url);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkthumb = writer.WriteObject(Thumb);
                if (checkthumb.IsError)
                {
                    return checkthumb;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkcontent = writer.WriteObject(Content);
                if (checkcontent.IsError)
                {
                    return checkcontent;
                }
            }

            var checksendMessage = writer.WriteObject(SendMessage);
            if (checksendMessage.IsError)
            {
                return checksendMessage;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }
                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trydescription = reader.ReadString();
                if (trydescription.IsError)
                {
                    return ReadResult<IObject>.Move(trydescription);
                }
                Description = trydescription.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }
                Url = tryurl.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
                if (trythumb.IsError)
                {
                    return ReadResult<IObject>.Move(trythumb);
                }
                Thumb = trythumb.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trycontent = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
                if (trycontent.IsError)
                {
                    return ReadResult<IObject>.Move(trycontent);
                }
                Content = trycontent.Value;
            }

            var trysendMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();
            if (trysendMessage.IsError)
            {
                return ReadResult<IObject>.Move(trysendMessage);
            }
            SendMessage = trysendMessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputBotInlineResult";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputBotInlineResult
            {
                Flags = Flags,
                Id = Id,
                Type = Type,
                Title = Title,
                Description = Description,
                Url = Url
            };
            if (Thumb is not null)
            {
                var cloneThumb = (CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase?)Thumb.Clone();
                if (cloneThumb is null)
                {
                    return null;
                }
                newClonedObject.Thumb = cloneThumb;
            }
            if (Content is not null)
            {
                var cloneContent = (CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase?)Content.Clone();
                if (cloneContent is null)
                {
                    return null;
                }
                newClonedObject.Content = cloneContent;
            }
            var cloneSendMessage = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase?)SendMessage.Clone();
            if (cloneSendMessage is null)
            {
                return null;
            }
            newClonedObject.SendMessage = cloneSendMessage;
            return newClonedObject;

        }
#nullable disable
    }
}