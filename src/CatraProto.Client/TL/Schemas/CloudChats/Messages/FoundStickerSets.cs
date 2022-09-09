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
    public partial class FoundStickerSets : CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1963942446; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("sets")] public List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }


#nullable enable
        public FoundStickerSets(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets)
        {
            Hash = hash;
            Sets = sets;
        }
#nullable disable
        internal FoundStickerSets()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checksets = writer.WriteVector(Sets, false);
            if (checksets.IsError)
            {
                return checksets;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            var trysets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysets.IsError)
            {
                return ReadResult<IObject>.Move(trysets);
            }

            Sets = trysets.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.foundStickerSets";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FoundStickerSets();
            newClonedObject.Hash = Hash;
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

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not FoundStickerSets castedOther)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
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

            return false;
        }

#nullable disable
    }
}