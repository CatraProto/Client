using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UnregisterDevice : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 813089983;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("token_type")] public int TokenType { get; set; }

        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("other_uids")] public IList<int> OtherUids { get; set; }

        public override string ToString()
        {
            return "account.unregisterDevice";
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

            writer.Write(TokenType);
            writer.Write(Token);
            writer.Write(OtherUids);
        }

        public void Deserialize(Reader reader)
        {
            TokenType = reader.Read<int>();
            Token = reader.Read<string>();
            OtherUids = reader.ReadVector<int>();
        }
    }
}