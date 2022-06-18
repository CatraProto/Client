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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ResetTopPeerRating : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 451113900; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("category")]
        public CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }


#nullable enable
        public ResetTopPeerRating(CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase category, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
        {
            Category = category;
            Peer = peer;

        }
#nullable disable

        internal ResetTopPeerRating()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcategory = writer.WriteObject(Category);
            if (checkcategory.IsError)
            {
                return checkcategory;
            }
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycategory = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase>();
            if (trycategory.IsError)
            {
                return ReadResult<IObject>.Move(trycategory);
            }
            Category = trycategory.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "contacts.resetTopPeerRating";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ResetTopPeerRating();
            var cloneCategory = (CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase?)Category.Clone();
            if (cloneCategory is null)
            {
                return null;
            }
            newClonedObject.Category = cloneCategory;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ResetTopPeerRating castedOther)
            {
                return true;
            }
            if (Category.Compare(castedOther.Category))
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}