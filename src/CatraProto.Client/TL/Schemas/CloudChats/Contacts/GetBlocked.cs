using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetBlocked : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -176409329;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(BlockedBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("offset")] public int Offset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        public override string ToString()
        {
            return "contacts.getBlocked";
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

            writer.Write(Offset);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}