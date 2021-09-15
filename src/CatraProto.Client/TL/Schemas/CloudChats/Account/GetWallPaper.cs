using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetWallPaper : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -57811990;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(WallPaperBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("wallpaper")] public InputWallPaperBase Wallpaper { get; set; }

        public override string ToString()
        {
            return "account.getWallPaper";
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

            writer.Write(Wallpaper);
        }

        public void Deserialize(Reader reader)
        {
            Wallpaper = reader.Read<InputWallPaperBase>();
        }
    }
}