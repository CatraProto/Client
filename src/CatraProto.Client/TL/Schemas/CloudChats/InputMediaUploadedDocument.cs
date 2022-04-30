/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaUploadedDocument : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NosoundVideo = 1 << 3,
            ForceFile = 1 << 4,
            Thumb = 1 << 2,
            Stickers = 1 << 0,
            TtlSeconds = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1530447553; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("nosound_video")]
        public bool NosoundVideo { get; set; }

        [Newtonsoft.Json.JsonProperty("force_file")]
        public bool ForceFile { get; set; }

        [Newtonsoft.Json.JsonProperty("file")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Thumb { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("attributes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("stickers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase> Stickers { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }


#nullable enable
        public InputMediaUploadedDocument(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string mimeType, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
        {
            File = file;
            MimeType = mimeType;
            Attributes = attributes;

        }
#nullable disable
        internal InputMediaUploadedDocument()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NosoundVideo ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = ForceFile ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Stickers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkthumb = writer.WriteObject(Thumb);
                if (checkthumb.IsError)
                {
                    return checkthumb;
                }
            }


            writer.WriteString(MimeType);
            var checkattributes = writer.WriteVector(Attributes, false);
            if (checkattributes.IsError)
            {
                return checkattributes;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkstickers = writer.WriteVector(Stickers, false);
                if (checkstickers.IsError)
                {
                    return checkstickers;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(TtlSeconds.Value);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            NosoundVideo = FlagsHelper.IsFlagSet(Flags, 3);
            ForceFile = FlagsHelper.IsFlagSet(Flags, 4);
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }
            File = tryfile.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
                if (trythumb.IsError)
                {
                    return ReadResult<IObject>.Move(trythumb);
                }
                Thumb = trythumb.Value;
            }

            var trymimeType = reader.ReadString();
            if (trymimeType.IsError)
            {
                return ReadResult<IObject>.Move(trymimeType);
            }
            MimeType = trymimeType.Value;
            var tryattributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryattributes.IsError)
            {
                return ReadResult<IObject>.Move(tryattributes);
            }
            Attributes = tryattributes.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trystickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trystickers.IsError)
                {
                    return ReadResult<IObject>.Move(trystickers);
                }
                Stickers = trystickers.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryttlSeconds = reader.ReadInt32();
                if (tryttlSeconds.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlSeconds);
                }
                TtlSeconds = tryttlSeconds.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputMediaUploadedDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaUploadedDocument
            {
                Flags = Flags,
                NosoundVideo = NosoundVideo,
                ForceFile = ForceFile
            };
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
            newClonedObject.MimeType = MimeType;
            foreach (var attributes in Attributes)
            {
                var cloneattributes = (CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase?)attributes.Clone();
                if (cloneattributes is null)
                {
                    return null;
                }
                newClonedObject.Attributes.Add(cloneattributes);
            }
            if (Stickers is not null)
            {
                foreach (var stickers in Stickers)
                {
                    var clonestickers = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)stickers.Clone();
                    if (clonestickers is null)
                    {
                        return null;
                    }
                    newClonedObject.Stickers.Add(clonestickers);
                }
            }
            newClonedObject.TtlSeconds = TtlSeconds;
            return newClonedObject;

        }
#nullable disable
    }
}