using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageTableRow : CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -524237339; }

        [Newtonsoft.Json.JsonProperty("cells")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }


#nullable enable
        public PageTableRow(List<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> cells)
        {
            Cells = cells;

        }
#nullable disable
        internal PageTableRow()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcells = writer.WriteVector(Cells, false);
            if (checkcells.IsError)
            {
                return checkcells;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycells = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycells.IsError)
            {
                return ReadResult<IObject>.Move(trycells);
            }
            Cells = trycells.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageTableRow";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageTableRow();
            foreach (var cells in Cells)
            {
                var clonecells = (CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase?)cells.Clone();
                if (clonecells is null)
                {
                    return null;
                }
                newClonedObject.Cells.Add(clonecells);
            }
            return newClonedObject;

        }
#nullable disable
    }
}