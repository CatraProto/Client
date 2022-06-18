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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGraph : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ZoomToken = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1901828938; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("json")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Json { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("zoom_token")]
        public string ZoomToken { get; set; }


#nullable enable
        public StatsGraph(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase json)
        {
            Json = json;

        }
#nullable disable
        internal StatsGraph()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ZoomToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkjson = writer.WriteObject(Json);
            if (checkjson.IsError)
            {
                return checkjson;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(ZoomToken);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var tryjson = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (tryjson.IsError)
            {
                return ReadResult<IObject>.Move(tryjson);
            }
            Json = tryjson.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryzoomToken = reader.ReadString();
                if (tryzoomToken.IsError)
                {
                    return ReadResult<IObject>.Move(tryzoomToken);
                }
                ZoomToken = tryzoomToken.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsGraph";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGraph
            {
                Flags = Flags
            };
            var cloneJson = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Json.Clone();
            if (cloneJson is null)
            {
                return null;
            }
            newClonedObject.Json = cloneJson;
            newClonedObject.ZoomToken = ZoomToken;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGraph castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Json.Compare(castedOther.Json))
            {
                return true;
            }
            if (ZoomToken != castedOther.ZoomToken)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}