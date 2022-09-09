using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SearchCounter : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inexact = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -398136321; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("inexact")]
        public sealed override bool Inexact { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }


#nullable enable
        public SearchCounter(CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int count)
        {
            Filter = filter;
            Count = count;
        }
#nullable disable
        internal SearchCounter()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkfilter = writer.WriteObject(Filter);
            if (checkfilter.IsError)
            {
                return checkfilter;
            }

            writer.WriteInt32(Count);

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
            Inexact = FlagsHelper.IsFlagSet(Flags, 1);
            var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
            if (tryfilter.IsError)
            {
                return ReadResult<IObject>.Move(tryfilter);
            }

            Filter = tryfilter.Value;
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.searchCounter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SearchCounter();
            newClonedObject.Flags = Flags;
            newClonedObject.Inexact = Inexact;
            var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase?)Filter.Clone();
            if (cloneFilter is null)
            {
                return null;
            }

            newClonedObject.Filter = cloneFilter;
            newClonedObject.Count = Count;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SearchCounter castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Inexact != castedOther.Inexact)
            {
                return true;
            }

            if (Filter.Compare(castedOther.Filter))
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}