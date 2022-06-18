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
    public partial class GetPeerDialogs : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -462373635; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> Peers { get; set; }


#nullable enable
        public GetPeerDialogs(List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> peers)
        {
            Peers = peers;

        }
#nullable disable

        internal GetPeerDialogs()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeers = writer.WriteVector(Peers, false);
            if (checkpeers.IsError)
            {
                return checkpeers;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypeers.IsError)
            {
                return ReadResult<IObject>.Move(trypeers);
            }
            Peers = trypeers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getPeerDialogs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetPeerDialogs
            {
                Peers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>()
            };
            foreach (var peers in Peers)
            {
                var clonepeers = (CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase?)peers.Clone();
                if (clonepeers is null)
                {
                    return null;
                }
                newClonedObject.Peers.Add(clonepeers);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetPeerDialogs castedOther)
            {
                return true;
            }
            var peerssize = castedOther.Peers.Count;
            if (peerssize != Peers.Count)
            {
                return true;
            }
            for (var i = 0; i < peerssize; i++)
            {
                if (castedOther.Peers[i].Compare(Peers[i]))
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}