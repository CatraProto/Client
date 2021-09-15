using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdateUsername : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1040964988;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UserBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("username")] public string Username { get; set; }

        public override string ToString()
        {
            return "account.updateUsername";
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

            writer.Write(Username);
        }

        public void Deserialize(Reader reader)
        {
            Username = reader.Read<string>();
        }
    }
}