using System;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SentCode : SentCodeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NextType = 1 << 1,
            Timeout = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => 1577067778;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("type")] public override SentCodeTypeBase Type { get; set; }

        [JsonProperty("phone_code_hash")] public override string PhoneCodeHash { get; set; }

        [JsonProperty("next_type")] public override CodeTypeBase NextType { get; set; }

        [JsonProperty("timeout")] public override int? Timeout { get; set; }


        public override void UpdateFlags()
        {
            Flags = NextType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Type);
            writer.Write(PhoneCodeHash);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(NextType);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Timeout.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Type = reader.Read<SentCodeTypeBase>();
            PhoneCodeHash = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                NextType = reader.Read<CodeTypeBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Timeout = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "auth.sentCode";
        }
    }
}