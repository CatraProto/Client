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
    public partial class InlineBotSwitchPM : CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1008755359; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("start_param")]
        public sealed override string StartParam { get; set; }


#nullable enable
        public InlineBotSwitchPM(string text, string startParam)
        {
            Text = text;
            StartParam = startParam;

        }
#nullable disable
        internal InlineBotSwitchPM()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            writer.WriteString(StartParam);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            var trystartParam = reader.ReadString();
            if (trystartParam.IsError)
            {
                return ReadResult<IObject>.Move(trystartParam);
            }
            StartParam = trystartParam.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inlineBotSwitchPM";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InlineBotSwitchPM
            {
                Text = Text,
                StartParam = StartParam
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InlineBotSwitchPM castedOther)
            {
                return true;
            }
            if (Text != castedOther.Text)
            {
                return true;
            }
            if (StartParam != castedOther.StartParam)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}