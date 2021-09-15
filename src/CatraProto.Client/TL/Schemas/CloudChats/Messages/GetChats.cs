using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetChats : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1013621127;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ChatsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("id")] public IList<int> Id { get; set; }

        public override string ToString()
        {
            return "messages.getChats";
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
            Id = reader.ReadVector<int>();
        }
    }
}