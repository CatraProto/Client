using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DialogFilterSuggested : CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2004110666; }

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

        public override bool Compare(IObject other)
        {
            if (other is not DialogFilterSuggested castedOther)
            {
                return true;
            }

            if (Filter.Compare(castedOther.Filter))
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}