using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class FinishTakeoutSession : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Success = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 489050862;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success { get; set; }


        public FinishTakeoutSession()
        {
        }

        public void UpdateFlags()
        {
            Flags = Success ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            Success = FlagsHelper.IsFlagSet(Flags, 0);
        }

        public override string ToString()
        {
            return "account.finishTakeoutSession";
        }
    }
}