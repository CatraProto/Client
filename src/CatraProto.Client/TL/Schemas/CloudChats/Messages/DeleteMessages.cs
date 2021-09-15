using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeleteMessages : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Revoke = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -443640366;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AffectedMessagesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("revoke")] public bool Revoke { get; set; }

        [JsonProperty("id")] public IList<int> Id { get; set; }

        public override string ToString()
        {
            return "messages.deleteMessages";
        }


        public void UpdateFlags()
        {
            Flags = Revoke ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Revoke = FlagsHelper.IsFlagSet(Flags, 0);
            Id = reader.ReadVector<int>();
        }
    }
}