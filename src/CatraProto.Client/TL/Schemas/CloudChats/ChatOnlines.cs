using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatOnlines : CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase
    {
        public static int StaticConstructorId
        {
            get => -264117680;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("onlines")]
        public sealed override int Onlines { get; set; }


    #nullable enable
        public ChatOnlines(int onlines)
        {
            Onlines = onlines;
        }
    #nullable disable
        internal ChatOnlines()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Onlines);
        }

        public override void Deserialize(Reader reader)
        {
            Onlines = reader.Read<int>();
        }

        public override string ToString()
        {
            return "chatOnlines";
        }
    }
}