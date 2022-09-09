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
    public partial class StickerSetMultiCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 872932635; }

        [Newtonsoft.Json.JsonProperty("set")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("covers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Covers { get; set; }


#nullable enable
        public StickerSetMultiCovered(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> covers)
        {
            Set = set;
            Covers = covers;
        }
#nullable disable
        internal StickerSetMultiCovered()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkset = writer.WriteObject(Set);
            if (checkset.IsError)
            {
                return checkset;
            }

            var checkcovers = writer.WriteVector(Covers, false);
            if (checkcovers.IsError)
            {
                return checkcovers;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
            if (tryset.IsError)
            {
                return ReadResult<IObject>.Move(tryset);
            }

            Set = tryset.Value;
            var trycovers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycovers.IsError)
            {
                return ReadResult<IObject>.Move(trycovers);
            }

            Covers = trycovers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickerSetMultiCovered";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSetMultiCovered();
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }

            newClonedObject.Set = cloneSet;
            newClonedObject.Covers = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            foreach (var covers in Covers)
            {
                var clonecovers = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)covers.Clone();
                if (clonecovers is null)
                {
                    return null;
                }

                newClonedObject.Covers.Add(clonecovers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StickerSetMultiCovered castedOther)
            {
                return true;
            }

            if (Set.Compare(castedOther.Set))
            {
                return true;
            }

            var coverssize = castedOther.Covers.Count;
            if (coverssize != Covers.Count)
            {
                return true;
            }

            for (var i = 0; i < coverssize; i++)
            {
                if (castedOther.Covers[i].Compare(Covers[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}