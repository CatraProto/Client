using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ToggleTopPeers : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -2062238246;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("enabled")] public bool Enabled { get; set; }

        public override string ToString()
        {
            return "contacts.toggleTopPeers";
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

            writer.Write(Enabled);
        }

        public void Deserialize(Reader reader)
        {
            Enabled = reader.Read<bool>();
        }
    }
}