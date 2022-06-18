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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGroupTopInviter : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1398765469; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("invitations")]
        public sealed override int Invitations { get; set; }


#nullable enable
        public StatsGroupTopInviter(long userId, int invitations)
        {
            UserId = userId;
            Invitations = invitations;

        }
#nullable disable
        internal StatsGroupTopInviter()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Invitations);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var tryinvitations = reader.ReadInt32();
            if (tryinvitations.IsError)
            {
                return ReadResult<IObject>.Move(tryinvitations);
            }
            Invitations = tryinvitations.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsGroupTopInviter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGroupTopInviter
            {
                UserId = UserId,
                Invitations = Invitations
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGroupTopInviter castedOther)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Invitations != castedOther.Invitations)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}