using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetAccountTTL : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 608323678;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("ttl")] public AccountDaysTTLBase Ttl { get; set; }

        public override string ToString()
        {
            return "account.setAccountTTL";
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

            writer.Write(Ttl);
        }

        public void Deserialize(Reader reader)
        {
            Ttl = reader.Read<AccountDaysTTLBase>();
        }
    }
}