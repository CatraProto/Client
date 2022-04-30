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

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class SetDiscussionGroup : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1079520178; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("broadcast")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Broadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("group")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Group { get; set; }


#nullable enable
        public SetDiscussionGroup(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase broadcast, CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase group)
        {
            Broadcast = broadcast;
            Group = group;

        }
#nullable disable

        internal SetDiscussionGroup()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkbroadcast = writer.WriteObject(Broadcast);
            if (checkbroadcast.IsError)
            {
                return checkbroadcast;
            }
            var checkgroup = writer.WriteObject(Group);
            if (checkgroup.IsError)
            {
                return checkgroup;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybroadcast = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trybroadcast.IsError)
            {
                return ReadResult<IObject>.Move(trybroadcast);
            }
            Broadcast = trybroadcast.Value;
            var trygroup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trygroup.IsError)
            {
                return ReadResult<IObject>.Move(trygroup);
            }
            Group = trygroup.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channels.setDiscussionGroup";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetDiscussionGroup();
            var cloneBroadcast = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Broadcast.Clone();
            if (cloneBroadcast is null)
            {
                return null;
            }
            newClonedObject.Broadcast = cloneBroadcast;
            var cloneGroup = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Group.Clone();
            if (cloneGroup is null)
            {
                return null;
            }
            newClonedObject.Group = cloneGroup;
            return newClonedObject;

        }
#nullable disable
    }
}