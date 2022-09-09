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
    public partial class FeaturedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Premium = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1103615738; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("premium")]
        public bool Premium { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("sets")] public List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }

        [Newtonsoft.Json.JsonProperty("unread")]
        public List<long> Unread { get; set; }


#nullable enable
        public FeaturedStickers(long hash, int count, List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets, List<long> unread)
        {
            Hash = hash;
            Count = count;
            Sets = sets;
            Unread = unread;
        }
#nullable disable
        internal FeaturedStickers()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Premium ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Hash);
            writer.WriteInt32(Count);
            var checksets = writer.WriteVector(Sets, false);
            if (checksets.IsError)
            {
                return checksets;
            }

            writer.WriteVector(Unread, false);

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
            Premium = FlagsHelper.IsFlagSet(Flags, 0);
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var trysets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysets.IsError)
            {
                return ReadResult<IObject>.Move(trysets);
            }

            Sets = trysets.Value;
            var tryunread = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryunread.IsError)
            {
                return ReadResult<IObject>.Move(tryunread);
            }

            Unread = tryunread.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.featuredStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FeaturedStickers();
            newClonedObject.Flags = Flags;
            newClonedObject.Premium = Premium;
            newClonedObject.Hash = Hash;
            newClonedObject.Count = Count;
            newClonedObject.Sets = new List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
            foreach (var sets in Sets)
            {
                var clonesets = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase?)sets.Clone();
                if (clonesets is null)
                {
                    return null;
                }

                newClonedObject.Sets.Add(clonesets);
            }

            newClonedObject.Unread = new List<long>();
            foreach (var unread in Unread)
            {
                newClonedObject.Unread.Add(unread);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not FeaturedStickers castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Premium != castedOther.Premium)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var setssize = castedOther.Sets.Count;
            if (setssize != Sets.Count)
            {
                return true;
            }

            for (var i = 0; i < setssize; i++)
            {
                if (castedOther.Sets[i].Compare(Sets[i]))
                {
                    return true;
                }
            }

            var unreadsize = castedOther.Unread.Count;
            if (unreadsize != Unread.Count)
            {
                return true;
            }

            for (var i = 0; i < unreadsize; i++)
            {
                if (castedOther.Unread[i] != Unread[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}