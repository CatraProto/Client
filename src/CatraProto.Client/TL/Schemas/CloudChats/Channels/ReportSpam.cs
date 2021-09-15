using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ReportSpam : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -32999408;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        [JsonProperty("id")] public IList<int> Id { get; set; }

        public override string ToString()
        {
            return "channels.reportSpam";
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
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            UserId = reader.Read<InputUserBase>();
            Id = reader.ReadVector<int>();
        }
    }
}