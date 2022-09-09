using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputFile : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -181407105; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("parts")]
        public sealed override int Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("md5_checksum")]
        public string Md5Checksum { get; set; }


#nullable enable
        public InputFile(long id, int parts, string name, string md5Checksum)
        {
            Id = id;
            Parts = parts;
            Name = name;
            Md5Checksum = md5Checksum;
        }
#nullable disable
        internal InputFile()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt32(Parts);

            writer.WriteString(Name);

            writer.WriteString(Md5Checksum);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryparts = reader.ReadInt32();
            if (tryparts.IsError)
            {
                return ReadResult<IObject>.Move(tryparts);
            }

            Parts = tryparts.Value;
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }

            Name = tryname.Value;
            var trymd5Checksum = reader.ReadString();
            if (trymd5Checksum.IsError)
            {
                return ReadResult<IObject>.Move(trymd5Checksum);
            }

            Md5Checksum = trymd5Checksum.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputFile();
            newClonedObject.Id = Id;
            newClonedObject.Parts = Parts;
            newClonedObject.Name = Name;
            newClonedObject.Md5Checksum = Md5Checksum;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputFile castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Parts != castedOther.Parts)
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            if (Md5Checksum != castedOther.Md5Checksum)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}