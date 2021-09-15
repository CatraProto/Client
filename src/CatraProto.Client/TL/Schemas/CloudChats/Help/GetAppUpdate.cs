using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetAppUpdate : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1378703997;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AppUpdateBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("source")] public string Source { get; set; }

        public override string ToString()
        {
            return "help.getAppUpdate";
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

            writer.Write(Source);
        }

        public void Deserialize(Reader reader)
        {
            Source = reader.Read<string>();
        }
    }
}