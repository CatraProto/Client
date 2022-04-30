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
    public partial class DialogFilterSuggested : CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2004110666; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }


#nullable enable
        public DialogFilterSuggested(CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase filter, string description)
        {
            Filter = filter;
            Description = description;

        }
#nullable disable
        internal DialogFilterSuggested()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkfilter = writer.WriteObject(Filter);
            if (checkfilter.IsError)
            {
                return checkfilter;
            }

            writer.WriteString(Description);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
            if (tryfilter.IsError)
            {
                return ReadResult<IObject>.Move(tryfilter);
            }
            Filter = tryfilter.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }
            Description = trydescription.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "dialogFilterSuggested";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DialogFilterSuggested();
            var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase?)Filter.Clone();
            if (cloneFilter is null)
            {
                return null;
            }
            newClonedObject.Filter = cloneFilter;
            newClonedObject.Description = Description;
            return newClonedObject;

        }
#nullable disable
    }
}