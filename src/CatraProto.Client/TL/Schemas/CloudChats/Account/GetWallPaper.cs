using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetWallPaper : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -57811990;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("wallpaper")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }


    #nullable enable
        public GetWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper)
        {
            Wallpaper = wallpaper;
        }
    #nullable disable

        internal GetWallPaper()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Wallpaper);
        }

        public void Deserialize(Reader reader)
        {
            Wallpaper = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
        }

        public override string ToString()
        {
            return "account.getWallPaper";
        }
    }
}