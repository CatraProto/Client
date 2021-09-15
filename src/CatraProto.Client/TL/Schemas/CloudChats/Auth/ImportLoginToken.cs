using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ImportLoginToken : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1783866140;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(LoginTokenBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("token")] public byte[] Token { get; set; }

        public override string ToString()
        {
            return "auth.importLoginToken";
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