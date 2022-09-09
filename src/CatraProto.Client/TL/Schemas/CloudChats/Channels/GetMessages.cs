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
    public partial class GetMessages : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1383294429; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> Id { get; set; }


#nullable enable
        public GetMessages(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id)
        {
            Channel = channel;
            Id = id;
        }
#nullable disable

        internal GetMessages()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            var checkid = writer.WriteVector(Id, false);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var tryid = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.getMessages";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetMessages();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.Id = new List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase>();
            foreach (var id in Id)
            {
                var cloneid = (CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase?)id.Clone();
                if (cloneid is null)
                {
                    return null;
                }

                newClonedObject.Id.Add(cloneid);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetMessages castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            var idsize = castedOther.Id.Count;
            if (idsize != Id.Count)
            {
                return true;
            }

            for (var i = 0; i < idsize; i++)
            {
                if (castedOther.Id[i].Compare(Id[i]))
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}