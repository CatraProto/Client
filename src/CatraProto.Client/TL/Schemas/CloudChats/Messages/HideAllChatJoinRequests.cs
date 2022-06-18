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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HideAllChatJoinRequests : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Approved = 1 << 0,
            Link = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -528091926; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("approved")]
        public bool Approved { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("link")]
        public string Link { get; set; }


#nullable enable
        public HideAllChatJoinRequests(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
        {
            Peer = peer;

        }
#nullable disable

        internal HideAllChatJoinRequests()
        {
        }

        public void UpdateFlags()
        {
            Flags = Approved ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Link == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(Link);
            }


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
            Approved = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trylink = reader.ReadString();
                if (trylink.IsError)
                {
                    return ReadResult<IObject>.Move(trylink);
                }
                Link = trylink.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.hideAllChatJoinRequests";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new HideAllChatJoinRequests
            {
                Flags = Flags,
                Approved = Approved
            };
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.Link = Link;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not HideAllChatJoinRequests castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Approved != castedOther.Approved)
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            if (Link != castedOther.Link)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}