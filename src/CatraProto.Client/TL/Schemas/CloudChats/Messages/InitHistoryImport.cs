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
    public partial class InitHistoryImport : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 873008187; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("file")] public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

        [Newtonsoft.Json.JsonProperty("media_count")]
        public int MediaCount { get; set; }


#nullable enable
        public InitHistoryImport(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, int mediaCount)
        {
            Peer = peer;
            File = file;
            MediaCount = mediaCount;
        }
#nullable disable

        internal InitHistoryImport()
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

            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            writer.WriteInt32(MediaCount);

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
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }

            File = tryfile.Value;
            var trymediaCount = reader.ReadInt32();
            if (trymediaCount.IsError)
            {
                return ReadResult<IObject>.Move(trymediaCount);
            }

            MediaCount = trymediaCount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.initHistoryImport";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InitHistoryImport();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)File.Clone();
            if (cloneFile is null)
            {
                return null;
            }

            newClonedObject.File = cloneFile;
            newClonedObject.MediaCount = MediaCount;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InitHistoryImport castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (File.Compare(castedOther.File))
            {
                return true;
            }

            if (MediaCount != castedOther.MediaCount)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}