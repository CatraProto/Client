using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Block : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1758204945;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("id")] public InputPeerBase Id { get; set; }

        public override string ToString()
        {
            return "contacts.block";
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

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputPeerBase>();
        }
    }
}