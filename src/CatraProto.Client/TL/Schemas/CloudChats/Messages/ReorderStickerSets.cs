using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 2016638777;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("masks")] public bool Masks { get; set; }

        [JsonProperty("order")] public IList<long> Order { get; set; }

        public override string ToString()
        {
            return "messages.reorderStickerSets";
        }


        public void UpdateFlags()
        {
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

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
    }
}