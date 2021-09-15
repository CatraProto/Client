using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class AcceptLoginToken : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -392909491;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(CloudChats.AuthorizationBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("token")] public byte[] Token { get; set; }

        public override string ToString()
        {
            return "auth.acceptLoginToken";
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

            writer.Write(Token);
        }

        public void Deserialize(Reader reader)
        {
            Token = reader.Read<byte[]>();
        }
    }
}