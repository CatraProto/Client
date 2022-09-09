using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UploadRingtone : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2095414366; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("file")] public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

        [Newtonsoft.Json.JsonProperty("file_name")]
        public string FileName { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public string MimeType { get; set; }


#nullable enable
        public UploadRingtone(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string fileName, string mimeType)
        {
            File = file;
            FileName = fileName;
            MimeType = mimeType;
        }
#nullable disable

        internal UploadRingtone()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            writer.WriteString(FileName);

            writer.WriteString(MimeType);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }

            File = tryfile.Value;
            var tryfileName = reader.ReadString();
            if (tryfileName.IsError)
            {
                return ReadResult<IObject>.Move(tryfileName);
            }

            FileName = tryfileName.Value;
            var trymimeType = reader.ReadString();
            if (trymimeType.IsError)
            {
                return ReadResult<IObject>.Move(trymimeType);
            }

            MimeType = trymimeType.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.uploadRingtone";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UploadRingtone();
            var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)File.Clone();
            if (cloneFile is null)
            {
                return null;
            }

            newClonedObject.File = cloneFile;
            newClonedObject.FileName = FileName;
            newClonedObject.MimeType = MimeType;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UploadRingtone castedOther)
            {
                return true;
            }

            if (File.Compare(castedOther.File))
            {
                return true;
            }

            if (FileName != castedOther.FileName)
            {
                return true;
            }

            if (MimeType != castedOther.MimeType)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}