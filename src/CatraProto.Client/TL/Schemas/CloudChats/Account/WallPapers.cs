using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class WallPapers : CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase
    {
        public static int StaticConstructorId
        {
            get => -842824308;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("wallpapers")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase> Wallpapers { get; set; }


    #nullable enable
        public WallPapers(long hash, IList<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase> wallpapers)
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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Hash);
            writer.Write(Wallpapers);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<long>();
            Wallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
        }

        public override string ToString()
        {
            return "account.wallPapers";
        }
    }
}