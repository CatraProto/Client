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
    public partial class UploadTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Thumb = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 473805619; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("file")] public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Thumb { get; set; }

        [Newtonsoft.Json.JsonProperty("file_name")]
        public string FileName { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public string MimeType { get; set; }


#nullable enable
        public UploadTheme(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string fileName, string mimeType)
        {
            File = file;
            FileName = fileName;
            MimeType = mimeType;
        }
#nullable disable

        internal UploadTheme()
        {
        }

        public void UpdateFlags()
        {
            Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkthumb = writer.WriteObject(Thumb);
                if (checkthumb.IsError)
                {
                    return checkthumb;
                }
            }


            writer.WriteString(FileName);

            writer.WriteString(MimeType);

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
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }

            File = tryfile.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
                if (trythumb.IsError)
                {
                    return ReadResult<IObject>.Move(trythumb);
                }

                Thumb = trythumb.Value;
            }

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
            return "account.uploadTheme";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UploadTheme();
            newClonedObject.Flags = Flags;
            var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)File.Clone();
            if (cloneFile is null)
            {
                return null;
            }

            newClonedObject.File = cloneFile;
            if (Thumb is not null)
            {
                var cloneThumb = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)Thumb.Clone();
                if (cloneThumb is null)
                {
                    return null;
                }

                newClonedObject.Thumb = cloneThumb;
            }

            newClonedObject.FileName = FileName;
            newClonedObject.MimeType = MimeType;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UploadTheme castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (File.Compare(castedOther.File))
            {
                return true;
            }

            if (Thumb is null && castedOther.Thumb is not null || Thumb is not null && castedOther.Thumb is null)
            {
                return true;
            }

            if (Thumb is not null && castedOther.Thumb is not null && Thumb.Compare(castedOther.Thumb))
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