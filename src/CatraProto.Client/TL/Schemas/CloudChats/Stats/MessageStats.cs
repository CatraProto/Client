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
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class MessageStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1986399595; }

        [Newtonsoft.Json.JsonProperty("views_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsGraph { get; set; }


#nullable enable
        public MessageStats(CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase viewsGraph)
        {
            ViewsGraph = viewsGraph;

        }
#nullable disable
        internal MessageStats()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkviewsGraph = writer.WriteObject(ViewsGraph);
            if (checkviewsGraph.IsError)
            {
                return checkviewsGraph;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryviewsGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryviewsGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryviewsGraph);
            }
            ViewsGraph = tryviewsGraph.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stats.messageStats";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageStats();
            var cloneViewsGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)ViewsGraph.Clone();
            if (cloneViewsGraph is null)
            {
                return null;
            }
            newClonedObject.ViewsGraph = cloneViewsGraph;
            return newClonedObject;

        }
#nullable disable
    }
}