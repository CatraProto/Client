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
    public partial class PageListOrderedItemBlocks : CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1730311882; }

        [Newtonsoft.Json.JsonProperty("num")] public sealed override string Num { get; set; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }


#nullable enable
        public PageListOrderedItemBlocks(string num, List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks)
        {
            Num = num;
            Blocks = blocks;
        }
#nullable disable
        internal PageListOrderedItemBlocks()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Num);
            var checkblocks = writer.WriteVector(Blocks, false);
            if (checkblocks.IsError)
            {
                return checkblocks;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynum = reader.ReadString();
            if (trynum.IsError)
            {
                return ReadResult<IObject>.Move(trynum);
            }

            Num = trynum.Value;
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
            return "pageListOrderedItemBlocks";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageListOrderedItemBlocks();
            newClonedObject.Num = Num;
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
            if (other is not PageListOrderedItemBlocks castedOther)
            {
                return true;
            }

            if (Num != castedOther.Num)
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