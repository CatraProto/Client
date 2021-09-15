using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ConfirmPasswordEmail : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1881204448;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("code")] public string Code { get; set; }

        public override string ToString()
        {
            return "account.confirmPasswordEmail";
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