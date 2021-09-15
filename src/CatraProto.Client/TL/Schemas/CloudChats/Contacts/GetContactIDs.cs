using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetContactIDs : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 749357634;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(int);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "contacts.getContactIDs";
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

            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
        }
    }
}