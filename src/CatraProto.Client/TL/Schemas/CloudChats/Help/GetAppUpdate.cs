using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetAppUpdate : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1378703997;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("source")]
        public string Source { get; set; }


    #nullable enable
        public GetAppUpdate(string source)
        {
            Source = source;
        }
    #nullable disable

        internal GetAppUpdate()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Source);
        }

        public void Deserialize(Reader reader)
        {
            Source = reader.Read<string>();
        }

        public override string ToString()
        {
            return "help.getAppUpdate";
        }
    }
}