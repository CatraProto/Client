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

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SaveAppLog : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1862465352; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("events")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> Events { get; set; }


#nullable enable
        public SaveAppLog(List<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> events)
        {
            Events = events;

        }
#nullable disable

        internal SaveAppLog()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkevents = writer.WriteVector(Events, false);
            if (checkevents.IsError)
            {
                return checkevents;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryevents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryevents.IsError)
            {
                return ReadResult<IObject>.Move(tryevents);
            }
            Events = tryevents.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.saveAppLog";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveAppLog
            {
                Events = new List<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase>()
            };
            foreach (var events in Events)
            {
                var cloneevents = (CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase?)events.Clone();
                if (cloneevents is null)
                {
                    return null;
                }
                newClonedObject.Events.Add(cloneevents);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SaveAppLog castedOther)
            {
                return true;
            }
            var eventssize = castedOther.Events.Count;
            if (eventssize != Events.Count)
            {
                return true;
            }
            for (var i = 0; i < eventssize; i++)
            {
                if (castedOther.Events[i].Compare(Events[i]))
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}