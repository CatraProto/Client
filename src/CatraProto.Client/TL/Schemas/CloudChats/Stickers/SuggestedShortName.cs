using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class SuggestedShortName : CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestedShortNameBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2046910401; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public sealed override string ShortName { get; set; }


#nullable enable
        public SuggestedShortName(string shortName)
        {
            ShortName = shortName;

        }
#nullable disable
        internal SuggestedShortName()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ShortName);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.suggestedShortName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}