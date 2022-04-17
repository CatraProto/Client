using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateNewStickerSet : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1753886890; }

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase Stickerset { get; set; }


#nullable enable
        public UpdateNewStickerSet(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase stickerset)
        {
            Stickerset = stickerset;

        }
#nullable disable
        internal UpdateNewStickerSet()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }
            Stickerset = trystickerset.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateNewStickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}