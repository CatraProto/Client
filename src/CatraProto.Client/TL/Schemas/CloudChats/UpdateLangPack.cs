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
    public partial class UpdateLangPack : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1442983757; }

        [Newtonsoft.Json.JsonProperty("difference")]
        public CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase Difference { get; set; }


#nullable enable
        public UpdateLangPack(CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase difference)
        {
            Difference = difference;
        }
#nullable disable
        internal UpdateLangPack()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdifference = writer.WriteObject(Difference);
            if (checkdifference.IsError)
            {
                return checkdifference;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydifference = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>();
            if (trydifference.IsError)
            {
                return ReadResult<IObject>.Move(trydifference);
            }

            Difference = trydifference.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateLangPack";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateLangPack();
            var cloneDifference = (CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase?)Difference.Clone();
            if (cloneDifference is null)
            {
                return null;
            }

            newClonedObject.Difference = cloneDifference;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateLangPack castedOther)
            {
                return true;
            }

            if (Difference.Compare(castedOther.Difference))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}