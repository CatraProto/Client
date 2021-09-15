using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class RecoverPassword : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1319464594;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AuthorizationBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("code")] public string Code { get; set; }

        public override string ToString()
        {
            return "auth.recoverPassword";
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

            writer.Write(Code);
        }

        public void Deserialize(Reader reader)
        {
            Code = reader.Read<string>();
        }
    }
}