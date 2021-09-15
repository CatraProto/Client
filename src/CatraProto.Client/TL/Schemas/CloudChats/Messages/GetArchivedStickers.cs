using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetArchivedStickers : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Masks = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1475442322;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ArchivedStickersBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("masks")] public bool Masks { get; set; }

        [JsonProperty("offset_id")] public long OffsetId { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        public override string ToString()
        {
            return "messages.getArchivedStickers";
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
            writer.Write(OffsetId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Masks = FlagsHelper.IsFlagSet(Flags, 0);
            OffsetId = reader.Read<long>();
            Limit = reader.Read<int>();
        }
    }
}