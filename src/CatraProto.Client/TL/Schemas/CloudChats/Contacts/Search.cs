using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Search : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 301470424;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(FoundBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("q")] public string Q { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        public override string ToString()
        {
            return "contacts.search";
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

            writer.Write(Q);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Q = reader.Read<string>();
            Limit = reader.Read<int>();
        }
    }
}