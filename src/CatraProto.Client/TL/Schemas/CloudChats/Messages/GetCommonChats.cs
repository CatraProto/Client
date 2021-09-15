using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetCommonChats : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 218777796;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ChatsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        [JsonProperty("max_id")] public int MaxId { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        public override string ToString()
        {
            return "messages.getCommonChats";
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

            writer.Write(UserId);
            writer.Write(MaxId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<InputUserBase>();
            MaxId = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}