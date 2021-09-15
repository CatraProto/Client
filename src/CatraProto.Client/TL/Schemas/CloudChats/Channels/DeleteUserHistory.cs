using System;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class DeleteUserHistory : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -787622117;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AffectedHistoryBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        public override string ToString()
        {
            return "channels.deleteUserHistory";
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

            writer.Write(Channel);
            writer.Write(UserId);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            UserId = reader.Read<InputUserBase>();
        }
    }
}