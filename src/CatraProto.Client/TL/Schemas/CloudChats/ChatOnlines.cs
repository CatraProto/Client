using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatOnlines : CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -264117680; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Onlines);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryonlines = reader.ReadInt32();
            if (tryonlines.IsError)
            {
                return ReadResult<IObject>.Move(tryonlines);
            }
            Onlines = tryonlines.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatOnlines";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}