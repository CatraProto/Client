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
    public partial class HttpWait : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1835453025; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("max_delay")]
        public int MaxDelay { get; set; }

        [Newtonsoft.Json.JsonProperty("wait_after")]
        public int WaitAfter { get; set; }

        [Newtonsoft.Json.JsonProperty("max_wait")]
        public int MaxWait { get; set; }


#nullable enable
        public HttpWait(int maxDelay, int waitAfter, int maxWait)
        {
            MaxDelay = maxDelay;
            WaitAfter = waitAfter;
            MaxWait = maxWait;

        }
#nullable disable

        internal HttpWait()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MaxDelay);
            writer.WriteInt32(WaitAfter);
            writer.WriteInt32(MaxWait);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymaxDelay = reader.ReadInt32();
            if (trymaxDelay.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDelay);
            }
            MaxDelay = trymaxDelay.Value;
            var trywaitAfter = reader.ReadInt32();
            if (trywaitAfter.IsError)
            {
                return ReadResult<IObject>.Move(trywaitAfter);
            }
            WaitAfter = trywaitAfter.Value;
            var trymaxWait = reader.ReadInt32();
            if (trymaxWait.IsError)
            {
                return ReadResult<IObject>.Move(trymaxWait);
            }
            MaxWait = trymaxWait.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "http_wait";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new HttpWait
            {
                MaxDelay = MaxDelay,
                WaitAfter = WaitAfter,
                MaxWait = MaxWait
            };
            return newClonedObject;

        }
#nullable disable
    }
}