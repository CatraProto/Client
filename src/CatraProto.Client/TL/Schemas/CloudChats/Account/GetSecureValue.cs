using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetSecureValue : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1936088002;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SecureValueBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("types")] public IList<SecureValueTypeBase> Types { get; set; }

        public override string ToString()
        {
            return "account.getSecureValue";
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