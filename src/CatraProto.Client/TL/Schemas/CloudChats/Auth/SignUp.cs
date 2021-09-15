using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SignUp : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -2131827673;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AuthorizationBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }

        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }

        [JsonProperty("first_name")] public string FirstName { get; set; }

        [JsonProperty("last_name")] public string LastName { get; set; }

        public override string ToString()
        {
            return "auth.signUp";
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
            writer.Write(FirstName);
            writer.Write(LastName);
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            PhoneCodeHash = reader.Read<string>();
            FirstName = reader.Read<string>();
            LastName = reader.Read<string>();
        }
    }
}