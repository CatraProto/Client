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
    public partial class PageBlockDetails : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Open = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1987480557; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("open")] public bool Open { get; set; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }


#nullable enable
        public PageBlockDetails(List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks, CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title)
        {
            Blocks = blocks;
            Title = title;
        }
#nullable disable
        internal PageBlockDetails()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Open ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkblocks = writer.WriteVector(Blocks, false);
            if (checkblocks.IsError)
            {
                return checkblocks;
            }

            var checktitle = writer.WriteObject(Title);
            if (checktitle.IsError)
            {
                return checktitle;
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
            Open = FlagsHelper.IsFlagSet(Flags, 0);
            var tryblocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblocks.IsError)
            {
                return ReadResult<IObject>.Move(tryblocks);
            }

            Blocks = tryblocks.Value;
            var trytitle = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockDetails";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockDetails();
            newClonedObject.Flags = Flags;
            newClonedObject.Open = Open;
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

            var cloneTitle = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Title.Clone();
            if (cloneTitle is null)
            {
                return null;
            }

            newClonedObject.Title = cloneTitle;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockDetails castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Open != castedOther.Open)
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

            if (Title.Compare(castedOther.Title))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}