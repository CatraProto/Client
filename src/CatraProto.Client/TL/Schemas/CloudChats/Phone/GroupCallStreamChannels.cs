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
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GroupCallStreamChannels : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamChannelsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -790330702; }

        [Newtonsoft.Json.JsonProperty("channels")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase> Channels { get; set; }


#nullable enable
        public GroupCallStreamChannels(List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase> channels)
        {
            Channels = channels;

        }
#nullable disable
        internal GroupCallStreamChannels()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannels = writer.WriteVector(Channels, false);
            if (checkchannels.IsError)
            {
                return checkchannels;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannels = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychannels.IsError)
            {
                return ReadResult<IObject>.Move(trychannels);
            }
            Channels = trychannels.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.groupCallStreamChannels";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallStreamChannels
            {
                Channels = new List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase>()
            };
            foreach (var channels in Channels)
            {
                var clonechannels = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase?)channels.Clone();
                if (clonechannels is null)
                {
                    return null;
                }
                newClonedObject.Channels.Add(clonechannels);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallStreamChannels castedOther)
            {
                return true;
            }
            var channelssize = castedOther.Channels.Count;
            if (channelssize != Channels.Count)
            {
                return true;
            }
            for (var i = 0; i < channelssize; i++)
            {
                if (castedOther.Channels[i].Compare(Channels[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}