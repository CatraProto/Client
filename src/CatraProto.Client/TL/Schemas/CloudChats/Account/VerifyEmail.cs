using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class VerifyEmail : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -323339813;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        public override string ToString()
        {
            return "account.verifyEmail";
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

            writer.Write(Email);
            writer.Write(Code);
        }

        public void Deserialize(Reader reader)
        {
            Email = reader.Read<string>();
            Code = reader.Read<string>();
        }
    }
}