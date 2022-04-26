using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class FileCdnRedirect : CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -242427324; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("file_token")]
        public byte[] FileToken { get; set; }

        [Newtonsoft.Json.JsonProperty("encryption_key")]
        public byte[] EncryptionKey { get; set; }

        [Newtonsoft.Json.JsonProperty("encryption_iv")]
        public byte[] EncryptionIv { get; set; }

        [Newtonsoft.Json.JsonProperty("file_hashes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase> FileHashes { get; set; }


#nullable enable
        public FileCdnRedirect(int dcId, byte[] fileToken, byte[] encryptionKey, byte[] encryptionIv, List<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase> fileHashes)
        {
            DcId = dcId;
            FileToken = fileToken;
            EncryptionKey = encryptionKey;
            EncryptionIv = encryptionIv;
            FileHashes = fileHashes;

        }
#nullable disable
        internal FileCdnRedirect()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(DcId);

            writer.WriteBytes(FileToken);

            writer.WriteBytes(EncryptionKey);

            writer.WriteBytes(EncryptionIv);
            var checkfileHashes = writer.WriteVector(FileHashes, false);
            if (checkfileHashes.IsError)
            {
                return checkfileHashes;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }
            DcId = trydcId.Value;
            var tryfileToken = reader.ReadBytes();
            if (tryfileToken.IsError)
            {
                return ReadResult<IObject>.Move(tryfileToken);
            }
            FileToken = tryfileToken.Value;
            var tryencryptionKey = reader.ReadBytes();
            if (tryencryptionKey.IsError)
            {
                return ReadResult<IObject>.Move(tryencryptionKey);
            }
            EncryptionKey = tryencryptionKey.Value;
            var tryencryptionIv = reader.ReadBytes();
            if (tryencryptionIv.IsError)
            {
                return ReadResult<IObject>.Move(tryencryptionIv);
            }
            EncryptionIv = tryencryptionIv.Value;
            var tryfileHashes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryfileHashes.IsError)
            {
                return ReadResult<IObject>.Move(tryfileHashes);
            }
            FileHashes = tryfileHashes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "upload.fileCdnRedirect";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FileCdnRedirect
            {
                DcId = DcId,
                FileToken = FileToken,
                EncryptionKey = EncryptionKey,
                EncryptionIv = EncryptionIv
            };
            foreach (var fileHashes in FileHashes)
            {
                var clonefileHashes = (CatraProto.Client.TL.Schemas.CloudChats.FileHashBase?)fileHashes.Clone();
                if (clonefileHashes is null)
                {
                    return null;
                }
                newClonedObject.FileHashes.Add(clonefileHashes);
            }
            return newClonedObject;

        }
#nullable disable
    }
}