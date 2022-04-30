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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class SetCallRating : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            UserInitiative = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1508562471; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_initiative")]
        public bool UserInitiative { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("rating")]
        public int Rating { get; set; }

        [Newtonsoft.Json.JsonProperty("comment")]
        public string Comment { get; set; }


#nullable enable
        public SetCallRating(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int rating, string comment)
        {
            Peer = peer;
            Rating = rating;
            Comment = comment;

        }
#nullable disable

        internal SetCallRating()
        {
        }

        public void UpdateFlags()
        {
            Flags = UserInitiative ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

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
            writer.WriteInt32(Rating);

            writer.WriteString(Comment);

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
            UserInitiative = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryrating = reader.ReadInt32();
            if (tryrating.IsError)
            {
                return ReadResult<IObject>.Move(tryrating);
            }
            Rating = tryrating.Value;
            var trycomment = reader.ReadString();
            if (trycomment.IsError)
            {
                return ReadResult<IObject>.Move(trycomment);
            }
            Comment = trycomment.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.setCallRating";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetCallRating
            {
                Flags = Flags,
                UserInitiative = UserInitiative
            };
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.Rating = Rating;
            newClonedObject.Comment = Comment;
            return newClonedObject;

        }
#nullable disable
    }
}