using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GroupCallStreamChannels : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamChannelsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -790330702; }

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
            var newClonedObject = new GroupCallStreamChannels();
            newClonedObject.Channels = new List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase>();
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