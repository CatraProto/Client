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
    public partial class ChannelAdminLogEventActionChangeTitle : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -421545947; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public string PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public string NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeTitle(string prevValue, string newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;

        }
#nullable disable
        internal ChannelAdminLogEventActionChangeTitle()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PrevValue);

            writer.WriteString(NewValue);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadString();
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }
            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadString();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }
            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeTitle";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangeTitle
            {
                PrevValue = PrevValue,
                NewValue = NewValue
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionChangeTitle castedOther)
            {
                return true;
            }
            if (PrevValue != castedOther.PrevValue)
            {
                return true;
            }
            if (NewValue != castedOther.NewValue)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}