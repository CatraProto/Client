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
    public partial class PageBlockCollage : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1705048653; }

        [Newtonsoft.Json.JsonProperty("items")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Items { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


#nullable enable
        public PageBlockCollage(List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> items, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            Items = items;
            Caption = caption;
        }
#nullable disable
        internal PageBlockCollage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkitems = writer.WriteVector(Items, false);
            if (checkitems.IsError)
            {
                return checkitems;
            }

            var checkcaption = writer.WriteObject(Caption);
            if (checkcaption.IsError)
            {
                return checkcaption;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryitems = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryitems.IsError)
            {
                return ReadResult<IObject>.Move(tryitems);
            }

            Items = tryitems.Value;
            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }

            Caption = trycaption.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockCollage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockCollage();
            newClonedObject.Items = new List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
            foreach (var items in Items)
            {
                var cloneitems = (CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase?)items.Clone();
                if (cloneitems is null)
                {
                    return null;
                }

                newClonedObject.Items.Add(cloneitems);
            }

            var cloneCaption = (CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase?)Caption.Clone();
            if (cloneCaption is null)
            {
                return null;
            }

            newClonedObject.Caption = cloneCaption;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockCollage castedOther)
            {
                return true;
            }

            var itemssize = castedOther.Items.Count;
            if (itemssize != Items.Count)
            {
                return true;
            }

            for (var i = 0; i < itemssize; i++)
            {
                if (castedOther.Items[i].Compare(Items[i]))
                {
                    return true;
                }
            }

            if (Caption.Compare(castedOther.Caption))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}