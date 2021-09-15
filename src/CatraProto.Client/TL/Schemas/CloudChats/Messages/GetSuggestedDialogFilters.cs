using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetSuggestedDialogFilters : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1566780372;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(DialogFilterSuggestedBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        public override string ToString()
        {
            return "messages.getSuggestedDialogFilters";
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