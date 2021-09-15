using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ResetTopPeerRating : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 451113900;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("category")] public TopPeerCategoryBase Category { get; set; }

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        public override string ToString()
        {
            return "contacts.resetTopPeerRating";
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

            writer.Write(Category);
            writer.Write(Peer);
        }

        public void Deserialize(Reader reader)
        {
            Category = reader.Read<TopPeerCategoryBase>();
            Peer = reader.Read<InputPeerBase>();
        }
    }
}