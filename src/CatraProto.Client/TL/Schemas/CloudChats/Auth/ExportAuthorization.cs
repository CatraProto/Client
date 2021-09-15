using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ExportAuthorization : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -440401971;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ExportedAuthorizationBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("dc_id")] public int DcId { get; set; }

        public override string ToString()
        {
            return "auth.exportAuthorization";
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

            writer.Write(DcId);
        }

        public void Deserialize(Reader reader)
        {
            DcId = reader.Read<int>();
        }
    }
}