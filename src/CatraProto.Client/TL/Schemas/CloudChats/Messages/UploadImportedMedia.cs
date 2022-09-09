using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class UploadImportedMedia : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 713433234; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("import_id")]
        public long ImportId { get; set; }

        [Newtonsoft.Json.JsonProperty("file_name")]
        public string FileName { get; set; }

        [Newtonsoft.Json.JsonProperty("media")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }


#nullable enable
        public UploadImportedMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long importId, string fileName, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media)
        {
            Peer = peer;
            ImportId = importId;
            FileName = fileName;
            Media = media;
        }
#nullable disable

        internal UploadImportedMedia()
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

            writer.WriteString(FileName);
            var checkmedia = writer.WriteObject(Media);
            if (checkmedia.IsError)
            {
                return checkmedia;
            }

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
            var tryfileName = reader.ReadString();
            if (tryfileName.IsError)
            {
                return ReadResult<IObject>.Move(tryfileName);
            }

            FileName = tryfileName.Value;
            var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
            if (trymedia.IsError)
            {
                return ReadResult<IObject>.Move(trymedia);
            }

            Media = trymedia.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.uploadImportedMedia";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UploadImportedMedia();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.ImportId = ImportId;
            newClonedObject.FileName = FileName;
            var cloneMedia = (CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase?)Media.Clone();
            if (cloneMedia is null)
            {
                return null;
            }

            newClonedObject.Media = cloneMedia;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UploadImportedMedia castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (ImportId != castedOther.ImportId)
            {
                return true;
            }

            if (FileName != castedOther.FileName)
            {
                return true;
            }

            if (Media.Compare(castedOther.Media))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}