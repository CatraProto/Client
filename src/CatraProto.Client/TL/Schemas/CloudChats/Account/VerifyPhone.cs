using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class VerifyPhone : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1305716726;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }

        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }

        [JsonProperty("phone_code")] public string PhoneCode { get; set; }

        public override string ToString()
        {
            return "account.verifyPhone";
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

            writer.Write(PhoneNumber);
            writer.Write(PhoneCodeHash);
            writer.Write(PhoneCode);
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            PhoneCodeHash = reader.Read<string>();
            PhoneCode = reader.Read<string>();
        }
    }
}