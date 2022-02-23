using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReorderStickerSets : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Masks = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 2016638777;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("order")]
        public IList<long> Order { get; set; }


    #nullable enable
        public ReorderStickerSets(IList<long> order)
        {
            Order = order;
        }
    #nullable disable

        internal ReorderStickerSets()
        {
        }

        public void UpdateFlags()
        {
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Order);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Masks = FlagsHelper.IsFlagSet(Flags, 0);
            Order = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "messages.reorderStickerSets";
        }
    }
}