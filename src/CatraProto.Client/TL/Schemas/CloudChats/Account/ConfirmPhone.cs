using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ConfirmPhone : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1596029123;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }

        [JsonProperty("phone_code")] public string PhoneCode { get; set; }

        public override string ToString()
        {
            return "account.confirmPhone";
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

            writer.Write(PhoneCodeHash);
            writer.Write(PhoneCode);
        }

        public void Deserialize(Reader reader)
        {
            PhoneCodeHash = reader.Read<string>();
            PhoneCode = reader.Read<string>();
        }
    }
}