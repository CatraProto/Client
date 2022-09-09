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
    public partial class StickerSetCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1678812626; }

        [Newtonsoft.Json.JsonProperty("set")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("cover")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Cover { get; set; }


#nullable enable
        public StickerSetCovered(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase cover)
        {
            Set = set;
            Cover = cover;
        }
#nullable disable
        internal StickerSetCovered()
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

            var checkcover = writer.WriteObject(Cover);
            if (checkcover.IsError)
            {
                return checkcover;
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
            var trycover = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (trycover.IsError)
            {
                return ReadResult<IObject>.Move(trycover);
            }

            Cover = trycover.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickerSetCovered";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSetCovered();
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }

            newClonedObject.Set = cloneSet;
            var cloneCover = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Cover.Clone();
            if (cloneCover is null)
            {
                return null;
            }

            newClonedObject.Cover = cloneCover;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StickerSetCovered castedOther)
            {
                return true;
            }

            if (Set.Compare(castedOther.Set))
            {
                return true;
            }

            if (Cover.Compare(castedOther.Cover))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}