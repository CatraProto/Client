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
    public partial class SendEncryptedFile : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1431914525; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public byte[] Data { get; set; }

        [Newtonsoft.Json.JsonProperty("file")] public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase File { get; set; }


#nullable enable
        public SendEncryptedFile(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file)
        {
            Peer = peer;
            RandomId = randomId;
            Data = data;
            File = file;
        }
#nullable disable

        internal SendEncryptedFile()
        {
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt64(RandomId);

            writer.WriteBytes(Data);
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Silent = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryrandomId = reader.ReadInt64();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }

            File = tryfile.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendEncryptedFile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendEncryptedFile();
            newClonedObject.Flags = Flags;
            newClonedObject.Silent = Silent;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.RandomId = RandomId;
            newClonedObject.Data = Data;
            var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase?)File.Clone();
            if (cloneFile is null)
            {
                return null;
            }

            newClonedObject.File = cloneFile;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendEncryptedFile castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Silent != castedOther.Silent)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            if (File.Compare(castedOther.File))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}