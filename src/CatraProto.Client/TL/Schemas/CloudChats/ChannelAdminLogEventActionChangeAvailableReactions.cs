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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionChangeAvailableReactions : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1661470870; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public List<string> PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public List<string> NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeAvailableReactions(List<string> prevValue, List<string> newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;

        }
#nullable disable
        internal ChannelAdminLogEventActionChangeAvailableReactions()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(PrevValue, false);

            writer.WriteVector(NewValue, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }
            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }
            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeAvailableReactions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangeAvailableReactions
            {
                PrevValue = new List<string>()
            };
            foreach (var prevValue in PrevValue)
            {
                newClonedObject.PrevValue.Add(prevValue);
            }
            newClonedObject.NewValue = new List<string>();
            foreach (var newValue in NewValue)
            {
                newClonedObject.NewValue.Add(newValue);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionChangeAvailableReactions castedOther)
            {
                return true;
            }
            var prevValuesize = castedOther.PrevValue.Count;
            if (prevValuesize != PrevValue.Count)
            {
                return true;
            }
            for (var i = 0; i < prevValuesize; i++)
            {
                if (castedOther.PrevValue[i] != PrevValue[i])
                {
                    return true;
                }
            }
            var newValuesize = castedOther.NewValue.Count;
            if (newValuesize != NewValue.Count)
            {
                return true;
            }
            for (var i = 0; i < newValuesize; i++)
            {
                if (castedOther.NewValue[i] != NewValue[i])
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}