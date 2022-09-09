using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelMessagesFilter : CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ExcludeNewMessages = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -847783593; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_new_messages")]
        public bool ExcludeNewMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("ranges")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase> Ranges { get; set; }


#nullable enable
        public ChannelMessagesFilter(List<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase> ranges)
        {
            Ranges = ranges;
        }
#nullable disable
        internal ChannelMessagesFilter()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ExcludeNewMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkranges = writer.WriteVector(Ranges, false);
            if (checkranges.IsError)
            {
                return checkranges;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            ExcludeNewMessages = FlagsHelper.IsFlagSet(Flags, 1);
            var tryranges = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryranges.IsError)
            {
                return ReadResult<IObject>.Move(tryranges);
            }

            Ranges = tryranges.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelMessagesFilter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelMessagesFilter();
            newClonedObject.Flags = Flags;
            newClonedObject.ExcludeNewMessages = ExcludeNewMessages;
            newClonedObject.Ranges = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
            foreach (var ranges in Ranges)
            {
                var cloneranges = (CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase?)ranges.Clone();
                if (cloneranges is null)
                {
                    return null;
                }

                newClonedObject.Ranges.Add(cloneranges);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelMessagesFilter castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ExcludeNewMessages != castedOther.ExcludeNewMessages)
            {
                return true;
            }

            var rangessize = castedOther.Ranges.Count;
            if (rangessize != Ranges.Count)
            {
                return true;
            }

            for (var i = 0; i < rangessize; i++)
            {
                if (castedOther.Ranges[i].Compare(Ranges[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}