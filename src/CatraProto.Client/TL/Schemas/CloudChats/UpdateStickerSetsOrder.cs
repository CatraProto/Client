using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateStickerSetsOrder : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Masks = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 196268545;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("order")]
        public IList<long> Order { get; set; }


    #nullable enable
        public UpdateStickerSetsOrder(IList<long> order)
        {
            Order = order;
        }
    #nullable disable
        internal UpdateStickerSetsOrder()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Order);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Masks = FlagsHelper.IsFlagSet(Flags, 0);
            Order = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "updateStickerSetsOrder";
        }
    }
}