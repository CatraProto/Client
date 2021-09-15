using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdateDeviceLocked : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 954152242;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("period")] public int Period { get; set; }

        public override string ToString()
        {
            return "account.updateDeviceLocked";
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

            writer.Write(Period);
        }

        public void Deserialize(Reader reader)
        {
            Period = reader.Read<int>();
        }
    }
}