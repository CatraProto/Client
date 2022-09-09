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
    public partial class PageListItemBlocks : CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 635466748; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }


#nullable enable
        public PageListItemBlocks(List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks)
        {
            Blocks = blocks;
        }
#nullable disable
        internal PageListItemBlocks()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkblocks = writer.WriteVector(Blocks, false);
            if (checkblocks.IsError)
            {
                return checkblocks;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryblocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblocks.IsError)
            {
                return ReadResult<IObject>.Move(tryblocks);
            }

            Blocks = tryblocks.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageListItemBlocks";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageListItemBlocks();
            newClonedObject.Blocks = new List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
            foreach (var blocks in Blocks)
            {
                var cloneblocks = (CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase?)blocks.Clone();
                if (cloneblocks is null)
                {
                    return null;
                }

                newClonedObject.Blocks.Add(cloneblocks);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageListItemBlocks castedOther)
            {
                return true;
            }

            var blockssize = castedOther.Blocks.Count;
            if (blockssize != Blocks.Count)
            {
                return true;
            }

            for (var i = 0; i < blockssize; i++)
            {
                if (castedOther.Blocks[i].Compare(Blocks[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}