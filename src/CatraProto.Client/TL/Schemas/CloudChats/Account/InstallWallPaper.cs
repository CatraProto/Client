using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class InstallWallPaper : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -18000023;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("wallpaper")] public InputWallPaperBase Wallpaper { get; set; }

        [JsonProperty("settings")] public WallPaperSettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "account.installWallPaper";
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
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            Wallpaper = reader.Read<InputWallPaperBase>();
            Settings = reader.Read<WallPaperSettingsBase>();
        }
    }
}