using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ResolveUsername : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -113456221;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ResolvedPeerBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("username")] public string Username { get; set; }

        public override string ToString()
        {
            return "contacts.resolveUsername";
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

            writer.Write(Username);
        }

        public void Deserialize(Reader reader)
        {
            Username = reader.Read<string>();
        }
    }
}