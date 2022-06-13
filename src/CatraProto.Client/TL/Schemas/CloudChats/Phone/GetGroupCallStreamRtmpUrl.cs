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

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GetGroupCallStreamRtmpUrl : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -558650433; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke")]
        public bool Revoke { get; set; }


#nullable enable
        public GetGroupCallStreamRtmpUrl(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool revoke)
        {
            Peer = peer;
            Revoke = revoke;

        }
#nullable disable

        internal GetGroupCallStreamRtmpUrl()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            var checkrevoke = writer.WriteBool(Revoke);
            if (checkrevoke.IsError)
            {
                return checkrevoke;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryrevoke = reader.ReadBool();
            if (tryrevoke.IsError)
            {
                return ReadResult<IObject>.Move(tryrevoke);
            }
            Revoke = tryrevoke.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.getGroupCallStreamRtmpUrl";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetGroupCallStreamRtmpUrl();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.Revoke = Revoke;
            return newClonedObject;

        }
#nullable disable
    }
}