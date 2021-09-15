using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class DeleteSecureValue : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1199522741;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("types")] public IList<SecureValueTypeBase> Types { get; set; }

        public override string ToString()
        {
            return "account.deleteSecureValue";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Types);
        }

        public void Deserialize(Reader reader)
        {
            Types = reader.ReadVector<SecureValueTypeBase>();
        }
    }
}