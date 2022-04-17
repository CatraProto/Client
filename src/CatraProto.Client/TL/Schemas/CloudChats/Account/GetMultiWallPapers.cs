using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetMultiWallPapers : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1705865692; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("wallpapers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> Wallpapers { get; set; }


#nullable enable
        public GetMultiWallPapers(List<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> wallpapers)
        {
            Wallpapers = wallpapers;

        }
#nullable disable

        internal GetMultiWallPapers()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkwallpapers = writer.WriteVector(Wallpapers, false);
            if (checkwallpapers.IsError)
            {
                return checkwallpapers;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trywallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trywallpapers.IsError)
            {
                return ReadResult<IObject>.Move(trywallpapers);
            }
            Wallpapers = trywallpapers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.getMultiWallPapers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}