using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetDeepLinkInfo : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1072547679;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("path")] public string Path { get; set; }


    #nullable enable
        public GetDeepLinkInfo(string path)
        {
            Path = path;
        }
    #nullable disable

        internal GetDeepLinkInfo()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Path);
        }

        public void Deserialize(Reader reader)
        {
            Path = reader.Read<string>();
        }

        public override string ToString()
        {
            return "help.getDeepLinkInfo";
        }
    }
}