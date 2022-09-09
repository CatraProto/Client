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
    public partial class InputFileBig : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -95482955; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("parts")]
        public sealed override int Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }


#nullable enable
        public InputFileBig(long id, int parts, string name)
        {
            Id = id;
            Parts = parts;
            Name = name;
        }
#nullable disable
        internal InputFileBig()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputFileBig";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputFileBig();
            newClonedObject.Id = Id;
            newClonedObject.Parts = Parts;
            newClonedObject.Name = Name;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputFileBig castedOther)
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

            return false;
        }

#nullable disable
    }
}