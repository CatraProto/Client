using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetStickers : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -710552671;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


    #nullable enable
        public GetStickers(string emoticon, long hash)
        {
            Emoticon = emoticon;
            Hash = hash;
        }
    #nullable disable

        internal GetStickers()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Emoticon);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Emoticon = reader.Read<string>();
            Hash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "messages.getStickers";
        }
    }
}