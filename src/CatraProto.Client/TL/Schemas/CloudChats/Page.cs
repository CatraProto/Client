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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Page : CatraProto.Client.TL.Schemas.CloudChats.PageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Part = 1 << 0,
            Rtl = 1 << 1,
            V2 = 1 << 2,
            Views = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1738178803; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("part")]
        public sealed override bool Part { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")]
        public sealed override bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("v2")]
        public sealed override bool V2 { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

        [Newtonsoft.Json.JsonProperty("photos")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public sealed override int? Views { get; set; }


#nullable enable
        public Page(string url, List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks, List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> photos, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> documents)
        {
            Url = url;
            Blocks = blocks;
            Photos = photos;
            Documents = documents;

        }
#nullable disable
        internal Page()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Part ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Rtl ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = V2 ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Url);
            var checkblocks = writer.WriteVector(Blocks, false);
            if (checkblocks.IsError)
            {
                return checkblocks;
            }
            var checkphotos = writer.WriteVector(Photos, false);
            if (checkphotos.IsError)
            {
                return checkphotos;
            }
            var checkdocuments = writer.WriteVector(Documents, false);
            if (checkdocuments.IsError)
            {
                return checkdocuments;
            }
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(Views.Value);
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
            Part = FlagsHelper.IsFlagSet(Flags, 0);
            Rtl = FlagsHelper.IsFlagSet(Flags, 1);
            V2 = FlagsHelper.IsFlagSet(Flags, 2);
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }
            Url = tryurl.Value;
            var tryblocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblocks.IsError)
            {
                return ReadResult<IObject>.Move(tryblocks);
            }
            Blocks = tryblocks.Value;
            var tryphotos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryphotos.IsError)
            {
                return ReadResult<IObject>.Move(tryphotos);
            }
            Photos = tryphotos.Value;
            var trydocuments = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydocuments.IsError)
            {
                return ReadResult<IObject>.Move(trydocuments);
            }
            Documents = trydocuments.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryviews = reader.ReadInt32();
                if (tryviews.IsError)
                {
                    return ReadResult<IObject>.Move(tryviews);
                }
                Views = tryviews.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "page";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Page
            {
                Flags = Flags,
                Part = Part,
                Rtl = Rtl,
                V2 = V2,
                Url = Url,
                Blocks = new List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>()
            };
            foreach (var blocks in Blocks)
            {
                var cloneblocks = (CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase?)blocks.Clone();
                if (cloneblocks is null)
                {
                    return null;
                }
                newClonedObject.Blocks.Add(cloneblocks);
            }
            newClonedObject.Photos = new List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            foreach (var photos in Photos)
            {
                var clonephotos = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)photos.Clone();
                if (clonephotos is null)
                {
                    return null;
                }
                newClonedObject.Photos.Add(clonephotos);
            }
            newClonedObject.Documents = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            foreach (var documents in Documents)
            {
                var clonedocuments = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)documents.Clone();
                if (clonedocuments is null)
                {
                    return null;
                }
                newClonedObject.Documents.Add(clonedocuments);
            }
            newClonedObject.Views = Views;
            return newClonedObject;

        }
#nullable disable
    }
}