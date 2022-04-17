using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class WallPapers : CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -842824308; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("wallpapers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase> Wallpapers { get; set; }


#nullable enable
        public WallPapers(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase> wallpapers)
        {
            Hash = hash;
            Wallpapers = wallpapers;

        }
#nullable disable
        internal WallPapers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkwallpapers = writer.WriteVector(Wallpapers, false);
            if (checkwallpapers.IsError)
            {
                return checkwallpapers;
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
            var trywallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trywallpapers.IsError)
            {
                return ReadResult<IObject>.Move(trywallpapers);
            }
            Wallpapers = trywallpapers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.wallPapers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}