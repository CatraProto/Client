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

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GetFutureSalts : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1188971260; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("num")]
        public int Num { get; set; }


#nullable enable
        public GetFutureSalts(int num)
        {
            Num = num;

        }
#nullable disable

        internal GetFutureSalts()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Num);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynum = reader.ReadInt32();
            if (trynum.IsError)
            {
                return ReadResult<IObject>.Move(trynum);
            }
            Num = trynum.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "get_future_salts";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetFutureSalts
            {
                Num = Num
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetFutureSalts castedOther)
            {
                return true;
            }
            if (Num != castedOther.Num)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}