using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StickerSetInstallResultArchive : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 904138920; }

        [Newtonsoft.Json.JsonProperty("sets")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }


#nullable enable
        public StickerSetInstallResultArchive(List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets)
        {
            Sets = sets;

        }
#nullable disable
        internal StickerSetInstallResultArchive()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksets = writer.WriteVector(Sets, false);
            if (checksets.IsError)
            {
                return checksets;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysets.IsError)
            {
                return ReadResult<IObject>.Move(trysets);
            }
            Sets = trysets.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.stickerSetInstallResultArchive";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}