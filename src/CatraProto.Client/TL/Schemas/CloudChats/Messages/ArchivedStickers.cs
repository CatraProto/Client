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
    public partial class ArchivedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1338747336; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("sets")] public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }


#nullable enable
        public ArchivedStickers(int count, List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets)
        {
            Count = count;
            Sets = sets;
        }
#nullable disable
        internal ArchivedStickers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checksets = writer.WriteVector(Sets, false);
            if (checksets.IsError)
            {
                return checksets;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.archivedStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ArchivedStickers();
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

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ArchivedStickers castedOther)
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

            return false;
        }

#nullable disable
    }
}