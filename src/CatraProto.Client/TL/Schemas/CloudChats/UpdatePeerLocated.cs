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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePeerLocated : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1263546448; }

        [Newtonsoft.Json.JsonProperty("peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase> Peers { get; set; }


#nullable enable
        public UpdatePeerLocated(List<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase> peers)
        {
            Peers = peers;

        }
#nullable disable
        internal UpdatePeerLocated()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeers = writer.WriteVector(Peers, false);
            if (checkpeers.IsError)
            {
                return checkpeers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypeers.IsError)
            {
                return ReadResult<IObject>.Move(trypeers);
            }
            Peers = trypeers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePeerLocated";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePeerLocated
            {
                Peers = new List<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase>()
            };
            foreach (var peers in Peers)
            {
                var clonepeers = (CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase?)peers.Clone();
                if (clonepeers is null)
                {
                    return null;
                }
                newClonedObject.Peers.Add(clonepeers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}