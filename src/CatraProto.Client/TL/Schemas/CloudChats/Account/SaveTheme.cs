using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SaveTheme : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -229175188;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("theme")] public InputThemeBase Theme { get; set; }

        [JsonProperty("unsave")] public bool Unsave { get; set; }

        public override string ToString()
        {
            return "account.saveTheme";
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

            writer.Write(Theme);
            writer.Write(Unsave);
        }

        public void Deserialize(Reader reader)
        {
            Theme = reader.Read<InputThemeBase>();
            Unsave = reader.Read<bool>();
        }
    }
}