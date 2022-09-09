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
    public partial class WebFile : CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 568808380; }

        [Newtonsoft.Json.JsonProperty("size")] public sealed override int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public sealed override string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("file_type")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase FileType { get; set; }

        [Newtonsoft.Json.JsonProperty("mtime")]
        public sealed override int Mtime { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override byte[] Bytes { get; set; }


#nullable enable
        public WebFile(int size, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase fileType, int mtime, byte[] bytes)
        {
            Size = size;
            MimeType = mimeType;
            FileType = fileType;
            Mtime = mtime;
            Bytes = bytes;
        }
#nullable disable
        internal WebFile()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Size);

            writer.WriteString(MimeType);
            var checkfileType = writer.WriteObject(FileType);
            if (checkfileType.IsError)
            {
                return checkfileType;
            }

            writer.WriteInt32(Mtime);

            writer.WriteBytes(Bytes);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysize = reader.ReadInt32();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }

            Size = trysize.Value;
            var trymimeType = reader.ReadString();
            if (trymimeType.IsError)
            {
                return ReadResult<IObject>.Move(trymimeType);
            }

            MimeType = trymimeType.Value;
            var tryfileType = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase>();
            if (tryfileType.IsError)
            {
                return ReadResult<IObject>.Move(tryfileType);
            }

            FileType = tryfileType.Value;
            var trymtime = reader.ReadInt32();
            if (trymtime.IsError)
            {
                return ReadResult<IObject>.Move(trymtime);
            }

            Mtime = trymtime.Value;
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
            return "upload.webFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebFile();
            newClonedObject.Size = Size;
            newClonedObject.MimeType = MimeType;
            var cloneFileType = (CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase?)FileType.Clone();
            if (cloneFileType is null)
            {
                return null;
            }

            newClonedObject.FileType = cloneFileType;
            newClonedObject.Mtime = Mtime;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebFile castedOther)
            {
                return true;
            }

            if (Size != castedOther.Size)
            {
                return true;
            }

            if (MimeType != castedOther.MimeType)
            {
                return true;
            }

            if (FileType.Compare(castedOther.FileType))
            {
                return true;
            }

            if (Mtime != castedOther.Mtime)
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