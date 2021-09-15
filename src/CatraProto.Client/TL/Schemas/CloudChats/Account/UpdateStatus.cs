using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdateStatus : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1713919532;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("offline")] public bool Offline { get; set; }

        public override string ToString()
        {
            return "account.updateStatus";
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

            writer.Write(Offline);
        }

        public void Deserialize(Reader reader)
        {
            Offline = reader.Read<bool>();
        }
    }
}