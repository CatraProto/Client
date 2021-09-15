using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetAllChats : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -341307408;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ChatsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("except_ids")] public IList<int> ExceptIds { get; set; }

        public override string ToString()
        {
            return "messages.getAllChats";
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

            writer.Write(ExceptIds);
        }

        public void Deserialize(Reader reader)
        {
            ExceptIds = reader.ReadVector<int>();
        }
    }
}