using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetSupport : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1663104819;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SupportBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        public override string ToString()
        {
            return "help.getSupport";
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