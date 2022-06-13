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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class FutureSalts : CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1370486635; }

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public sealed override long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("now")]
        public sealed override int Now { get; set; }

        [Newtonsoft.Json.JsonProperty("salts")]
        public sealed override List<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }


#nullable enable
        public FutureSalts(long reqMsgId, int now, List<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> salts)
        {
            ReqMsgId = reqMsgId;
            Now = now;
            Salts = salts;

        }
#nullable disable
        internal FutureSalts()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ReqMsgId);
            writer.WriteInt32(Now);
            var checksalts = writer.WriteVector(Salts, true);
            if (checksalts.IsError)
            {
                return checksalts;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreqMsgId = reader.ReadInt64();
            if (tryreqMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryreqMsgId);
            }
            ReqMsgId = tryreqMsgId.Value;
            var trynow = reader.ReadInt32();
            if (trynow.IsError)
            {
                return ReadResult<IObject>.Move(trynow);
            }
            Now = trynow.Value;
            var trysalts = reader.ReadVector<CatraProto.Client.TL.Schemas.MTProto.FutureSalt>(ParserTypes.Object, nakedVector: true, nakedObjects: true);
            if (trysalts.IsError)
            {
                return ReadResult<IObject>.Move(trysalts);
            }
            Salts = trysalts.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "future_salts";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FutureSalts
            {
                ReqMsgId = ReqMsgId,
                Now = Now,
                Salts = new List<CatraProto.Client.TL.Schemas.MTProto.FutureSalt>()
            };
            foreach (var salts in Salts)
            {
                var clonesalts = (CatraProto.Client.TL.Schemas.MTProto.FutureSalt?)salts.Clone();
                if (clonesalts is null)
                {
                    return null;
                }
                newClonedObject.Salts.Add(clonesalts);
            }
            return newClonedObject;

        }
#nullable disable
    }
}