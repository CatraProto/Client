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
    public partial class DocumentAttributeFilename : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 358154344; }

        [Newtonsoft.Json.JsonProperty("file_name")]
        public string FileName { get; set; }


#nullable enable
        public DocumentAttributeFilename(string fileName)
        {
            FileName = fileName;
        }
#nullable disable
        internal DocumentAttributeFilename()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(FileName);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfileName = reader.ReadString();
            if (tryfileName.IsError)
            {
                return ReadResult<IObject>.Move(tryfileName);
            }

            FileName = tryfileName.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "documentAttributeFilename";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentAttributeFilename();
            newClonedObject.FileName = FileName;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentAttributeFilename castedOther)
            {
                return true;
            }

            if (FileName != castedOther.FileName)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}