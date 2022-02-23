using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class ClearSavedInfo : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Credentials = 1 << 0,
            Info = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -667062079;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials")]
        public bool Credentials { get; set; }

        [Newtonsoft.Json.JsonProperty("info")] public bool Info { get; set; }


        public ClearSavedInfo()
        {
        }

        public void UpdateFlags()
        {
            Flags = Credentials ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Info ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Credentials = FlagsHelper.IsFlagSet(Flags, 0);
            Info = FlagsHelper.IsFlagSet(Flags, 1);
        }

        public override string ToString()
        {
            return "payments.clearSavedInfo";
        }
    }
}