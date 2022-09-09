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
    public partial class DeleteHistory : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ForEveryone = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1683319225; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("for_everyone")]
        public bool ForEveryone { get; set; }

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }


#nullable enable
        public DeleteHistory(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId)
        {
            Channel = channel;
            MaxId = maxId;
        }
#nullable disable

        internal DeleteHistory()
        {
        }

        public void UpdateFlags()
        {
            Flags = ForEveryone ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            writer.WriteInt32(MaxId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            ForEveryone = FlagsHelper.IsFlagSet(Flags, 0);
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.deleteHistory";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteHistory();
            newClonedObject.Flags = Flags;
            newClonedObject.ForEveryone = ForEveryone;
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.MaxId = MaxId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteHistory castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ForEveryone != castedOther.ForEveryone)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}