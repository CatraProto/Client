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
    public partial class AllStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -843329861; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("sets")] public List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> Sets { get; set; }


#nullable enable
        public AllStickers(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> sets)
        {
            Hash = hash;
            Sets = sets;
        }
#nullable disable
        internal AllStickers()
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
            var trysets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysets.IsError)
            {
                return ReadResult<IObject>.Move(trysets);
            }

            Sets = trysets.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.allStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AllStickers();
            newClonedObject.Hash = Hash;
            newClonedObject.Sets = new List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
            foreach (var sets in Sets)
            {
                var clonesets = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)sets.Clone();
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
            if (other is not AllStickers castedOther)
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