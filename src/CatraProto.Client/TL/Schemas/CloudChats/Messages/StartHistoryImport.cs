using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StartHistoryImport : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1271008444; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("import_id")]
        public long ImportId { get; set; }


#nullable enable
        public StartHistoryImport(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long importId)
        {
            Peer = peer;
            ImportId = importId;

        }
#nullable disable

        internal StartHistoryImport()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt64(ImportId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryimportId = reader.ReadInt64();
            if (tryimportId.IsError)
            {
                return ReadResult<IObject>.Move(tryimportId);
            }
            ImportId = tryimportId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.startHistoryImport";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new StartHistoryImport();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.ImportId = ImportId;
            return newClonedObject;

        }
#nullable disable
    }
}