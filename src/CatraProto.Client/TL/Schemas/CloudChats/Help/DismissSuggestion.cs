using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class DismissSuggestion : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 125807007;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("suggestion")] public string Suggestion { get; set; }

        public override string ToString()
        {
            return "help.dismissSuggestion";
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

            writer.Write(Suggestion);
        }

        public void Deserialize(Reader reader)
        {
            Suggestion = reader.Read<string>();
        }
    }
}