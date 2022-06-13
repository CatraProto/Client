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
    public partial class MsgsAllInfo : CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1933520591; }

        [Newtonsoft.Json.JsonProperty("msg_ids")]
        public sealed override List<long> MsgIds { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public sealed override byte[] Info { get; set; }


#nullable enable
        public MsgsAllInfo(List<long> msgIds, byte[] info)
        {
            MsgIds = msgIds;
            Info = info;

        }
#nullable disable
        internal MsgsAllInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(MsgIds, false);

            writer.WriteBytes(Info);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgIds = reader.ReadVector<long>(ParserTypes.Int64);
            if (trymsgIds.IsError)
            {
                return ReadResult<IObject>.Move(trymsgIds);
            }
            MsgIds = trymsgIds.Value;
            var tryinfo = reader.ReadBytes();
            if (tryinfo.IsError)
            {
                return ReadResult<IObject>.Move(tryinfo);
            }
            Info = tryinfo.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msgs_all_info";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgsAllInfo
            {
                MsgIds = new List<long>()
            };
            foreach (var msgIds in MsgIds)
            {
                newClonedObject.MsgIds.Add(msgIds);
            }
            newClonedObject.Info = Info;
            return newClonedObject;

        }
#nullable disable
    }
}