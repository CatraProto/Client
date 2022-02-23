using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockTable : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Bordered = 1 << 0,
            Striped = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => -1085412734;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bordered")]
        public bool Bordered { get; set; }

        [Newtonsoft.Json.JsonProperty("striped")]
        public bool Striped { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

        [Newtonsoft.Json.JsonProperty("rows")] public IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase> Rows { get; set; }


    #nullable enable
        public PageBlockTable(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title, IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase> rows)
        {
            Title = title;
            Rows = rows;
        }
    #nullable disable
        internal PageBlockTable()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Bordered ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Striped ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Title);
            writer.Write(Rows);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Bordered = FlagsHelper.IsFlagSet(Flags, 0);
            Striped = FlagsHelper.IsFlagSet(Flags, 1);
            Title = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            Rows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase>();
        }

        public override string ToString()
        {
            return "pageBlockTable";
        }
    }
}