using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetSupportName : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -748624084;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SupportNameBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        public override string ToString()
        {
            return "help.getSupportName";
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
        }

        public void Deserialize(Reader reader)
        {
        }
    }
}