using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CancelCode : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 520357240;
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

        public override string ToString()
        {
            return "auth.cancelCode";
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
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            PhoneCodeHash = reader.Read<string>();
        }
    }
}