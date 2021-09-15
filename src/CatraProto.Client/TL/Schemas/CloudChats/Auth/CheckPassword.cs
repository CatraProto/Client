using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CheckPassword : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -779399914;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AuthorizationBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("password")] public InputCheckPasswordSRPBase Password { get; set; }

        public override string ToString()
        {
            return "auth.checkPassword";
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

            writer.Write(Password);
        }

        public void Deserialize(Reader reader)
        {
            Password = reader.Read<InputCheckPasswordSRPBase>();
        }
    }
}