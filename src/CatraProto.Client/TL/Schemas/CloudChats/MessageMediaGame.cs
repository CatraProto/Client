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
    public partial class MessageMediaGame : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -38694904; }

        [Newtonsoft.Json.JsonProperty("game")]
        public CatraProto.Client.TL.Schemas.CloudChats.GameBase Game { get; set; }


#nullable enable
        public MessageMediaGame(CatraProto.Client.TL.Schemas.CloudChats.GameBase game)
        {
            Game = game;

        }
#nullable disable
        internal MessageMediaGame()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkgame = writer.WriteObject(Game);
            if (checkgame.IsError)
            {
                return checkgame;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trygame = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GameBase>();
            if (trygame.IsError)
            {
                return ReadResult<IObject>.Move(trygame);
            }
            Game = trygame.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageMediaGame";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaGame();
            var cloneGame = (CatraProto.Client.TL.Schemas.CloudChats.GameBase?)Game.Clone();
            if (cloneGame is null)
            {
                return null;
            }
            newClonedObject.Game = cloneGame;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaGame castedOther)
            {
                return true;
            }
            if (Game.Compare(castedOther.Game))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}