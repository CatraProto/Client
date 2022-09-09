using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class SetDiscussionGroup : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1079520178; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

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

        public bool Compare(IObject other)
        {
            if (other is not SetDiscussionGroup castedOther)
            {
                return true;
            }

            if (Broadcast.Compare(castedOther.Broadcast))
            {
                return true;
            }

            if (Group.Compare(castedOther.Group))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}