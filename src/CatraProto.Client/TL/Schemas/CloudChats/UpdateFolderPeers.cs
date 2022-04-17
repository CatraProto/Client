using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateFolderPeers : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 422972864; }

        [Newtonsoft.Json.JsonProperty("folder_peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase> FolderPeers { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


#nullable enable
        public UpdateFolderPeers(List<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase> folderPeers, int pts, int ptsCount)
        {
            FolderPeers = folderPeers;
            Pts = pts;
            PtsCount = ptsCount;

        }
#nullable disable
        internal UpdateFolderPeers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkfolderPeers = writer.WriteVector(FolderPeers, false);
            if (checkfolderPeers.IsError)
            {
                return checkfolderPeers;
            }
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfolderPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryfolderPeers.IsError)
            {
                return ReadResult<IObject>.Move(tryfolderPeers);
            }
            FolderPeers = tryfolderPeers.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }
            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }
            PtsCount = tryptsCount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateFolderPeers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}