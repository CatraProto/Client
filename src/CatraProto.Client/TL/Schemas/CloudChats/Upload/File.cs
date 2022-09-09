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
    public partial class File : CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 157948117; }

        [Newtonsoft.Json.JsonProperty("type")] public CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("mtime")]
        public int Mtime { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public File(CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase type, int mtime, byte[] bytes)
        {
            Type = type;
            Mtime = mtime;
            Bytes = bytes;
        }
#nullable disable
        internal File()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }

            writer.WriteInt32(Mtime);

            writer.WriteBytes(Bytes);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
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
            return "upload.file";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new File();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            newClonedObject.Mtime = Mtime;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not File castedOther)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
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