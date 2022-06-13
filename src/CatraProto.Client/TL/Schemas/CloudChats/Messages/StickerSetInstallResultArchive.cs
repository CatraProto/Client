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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StickerSetInstallResultArchive : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 904138920; }

        [Newtonsoft.Json.JsonProperty("sets")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }


#nullable enable
        public StickerSetInstallResultArchive(List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets)
        {
            Sets = sets;

        }
#nullable disable
        internal StickerSetInstallResultArchive()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksets = writer.WriteVector(Sets, false);
            if (checksets.IsError)
            {
                return checksets;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysets.IsError)
            {
                return ReadResult<IObject>.Move(trysets);
            }
            Sets = trysets.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.stickerSetInstallResultArchive";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSetInstallResultArchive
            {
                Sets = new List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>()
            };
            foreach (var sets in Sets)
            {
                var clonesets = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase?)sets.Clone();
                if (clonesets is null)
                {
                    return null;
                }
                newClonedObject.Sets.Add(clonesets);
            }
            return newClonedObject;

        }
#nullable disable
    }
}