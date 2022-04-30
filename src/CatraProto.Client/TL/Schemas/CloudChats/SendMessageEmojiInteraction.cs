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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SendMessageEmojiInteraction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 630664139; }

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
            var newClonedObject = new SendMessageEmojiInteraction
            {
                Emoticon = Emoticon,
                MsgId = MsgId
            };
            var cloneInteraction = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Interaction.Clone();
            if (cloneInteraction is null)
            {
                return null;
            }
            newClonedObject.Interaction = cloneInteraction;
            return newClonedObject;

        }
#nullable disable
    }
}