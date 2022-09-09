using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class SaveBigFilePart : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -562337987; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("file_id")]
        public long FileId { get; set; }

        [Newtonsoft.Json.JsonProperty("file_part")]
        public int FilePart { get; set; }

        [Newtonsoft.Json.JsonProperty("file_total_parts")]
        public int FileTotalParts { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public SaveBigFilePart(long fileId, int filePart, int fileTotalParts, byte[] bytes)
        {
            FileId = fileId;
            FilePart = filePart;
            FileTotalParts = fileTotalParts;
            Bytes = bytes;
        }
#nullable disable

        internal SaveBigFilePart()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(FileId);
            writer.WriteInt32(FilePart);
            writer.WriteInt32(FileTotalParts);

            writer.WriteBytes(Bytes);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfileId = reader.ReadInt64();
            if (tryfileId.IsError)
            {
                return ReadResult<IObject>.Move(tryfileId);
            }

            FileId = tryfileId.Value;
            var tryfilePart = reader.ReadInt32();
            if (tryfilePart.IsError)
            {
                return ReadResult<IObject>.Move(tryfilePart);
            }

            FilePart = tryfilePart.Value;
            var tryfileTotalParts = reader.ReadInt32();
            if (tryfileTotalParts.IsError)
            {
                return ReadResult<IObject>.Move(tryfileTotalParts);
            }

            FileTotalParts = tryfileTotalParts.Value;
            var trybytes = reader.ReadBytes();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }

            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "upload.saveBigFilePart";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveBigFilePart();
            newClonedObject.FileId = FileId;
            newClonedObject.FilePart = FilePart;
            newClonedObject.FileTotalParts = FileTotalParts;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveBigFilePart castedOther)
            {
                return true;
            }

            if (FileId != castedOther.FileId)
            {
                return true;
            }

            if (FilePart != castedOther.FilePart)
            {
                return true;
            }

            if (FileTotalParts != castedOther.FileTotalParts)
            {
                return true;
            }

            if (Bytes != castedOther.Bytes)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}