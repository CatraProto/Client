using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FavedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 750063767; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("packs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Stickers { get; set; }


#nullable enable
        public FavedStickers(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> packs, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> stickers)
        {
            Hash = hash;
            Packs = packs;
            Stickers = stickers;

        }
#nullable disable
        internal FavedStickers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkpacks = writer.WriteVector(Packs, false);
            if (checkpacks.IsError)
            {
                return checkpacks;
            }
            var checkstickers = writer.WriteVector(Stickers, false);
            if (checkstickers.IsError)
            {
                return checkstickers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trypacks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypacks.IsError)
            {
                return ReadResult<IObject>.Move(trypacks);
            }
            Packs = trypacks.Value;
            var trystickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystickers.IsError)
            {
                return ReadResult<IObject>.Move(trystickers);
            }
            Stickers = trystickers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.favedStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}