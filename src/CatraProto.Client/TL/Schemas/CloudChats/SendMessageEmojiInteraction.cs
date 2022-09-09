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
    public partial class SendMessageEmojiInteraction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 630664139; }

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("interaction")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Interaction { get; set; }


#nullable enable
        public SendMessageEmojiInteraction(string emoticon, int msgId, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase interaction)
        {
            Emoticon = emoticon;
            MsgId = msgId;
            Interaction = interaction;
        }
#nullable disable
        internal SendMessageEmojiInteraction()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Emoticon);
            writer.WriteInt32(MsgId);
            var checkinteraction = writer.WriteObject(Interaction);
            if (checkinteraction.IsError)
            {
                return checkinteraction;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemoticon = reader.ReadString();
            if (tryemoticon.IsError)
            {
                return ReadResult<IObject>.Move(tryemoticon);
            }

            Emoticon = tryemoticon.Value;
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
            var tryinteraction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (tryinteraction.IsError)
            {
                return ReadResult<IObject>.Move(tryinteraction);
            }

            Interaction = tryinteraction.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "sendMessageEmojiInteraction";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SendMessageEmojiInteraction();
            newClonedObject.Emoticon = Emoticon;
            newClonedObject.MsgId = MsgId;
            var cloneInteraction = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Interaction.Clone();
            if (cloneInteraction is null)
            {
                return null;
            }

            newClonedObject.Interaction = cloneInteraction;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SendMessageEmojiInteraction castedOther)
            {
                return true;
            }

            if (Emoticon != castedOther.Emoticon)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (Interaction.Compare(castedOther.Interaction))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}