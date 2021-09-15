using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetMessages : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1383294429;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(MessagesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("id")] public IList<InputMessageBase> Id { get; set; }

        public override string ToString()
        {
            return "channels.getMessages";
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
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Id = reader.ReadVector<InputMessageBase>();
        }
    }
}