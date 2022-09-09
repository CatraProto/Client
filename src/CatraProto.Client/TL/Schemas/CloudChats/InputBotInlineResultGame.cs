using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineResultGame : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1336154098; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


#nullable enable
        public InputBotInlineResultGame(string id, string shortName, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            ShortName = shortName;
            SendMessage = sendMessage;
        }
#nullable disable
        internal InputBotInlineResultGame()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteString(ShortName);
            var checksendMessage = writer.WriteObject(SendMessage);
            if (checksendMessage.IsError)
            {
                return checksendMessage;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }

            ShortName = tryshortName.Value;
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
            return "inputBotInlineResultGame";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputBotInlineResultGame();
            newClonedObject.Id = Id;
            newClonedObject.ShortName = ShortName;
            var cloneSendMessage = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase?)SendMessage.Clone();
            if (cloneSendMessage is null)
            {
                return null;
            }

            newClonedObject.SendMessage = cloneSendMessage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputBotInlineResultGame castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (ShortName != castedOther.ShortName)
            {
                return true;
            }

            if (SendMessage.Compare(castedOther.SendMessage))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}