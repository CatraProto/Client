using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SendVerifyEmailCode : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1880182943;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SentEmailCodeBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("email")] public string Email { get; set; }

        public override string ToString()
        {
            return "account.sendVerifyEmailCode";
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
        }

        public void Deserialize(Reader reader)
        {
            Email = reader.Read<string>();
        }
    }
}