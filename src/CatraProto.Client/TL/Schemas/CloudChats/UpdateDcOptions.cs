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
    public partial class UpdateDcOptions : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1906403213; }

        [Newtonsoft.Json.JsonProperty("dc_options")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }


#nullable enable
        public UpdateDcOptions(List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> dcOptions)
        {
            DcOptions = dcOptions;
        }
#nullable disable
        internal UpdateDcOptions()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdcOptions = writer.WriteVector(DcOptions, false);
            if (checkdcOptions.IsError)
            {
                return checkdcOptions;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydcOptions.IsError)
            {
                return ReadResult<IObject>.Move(trydcOptions);
            }

            DcOptions = trydcOptions.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateDcOptions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateDcOptions();
            newClonedObject.DcOptions = new List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>();
            foreach (var dcOptions in DcOptions)
            {
                var clonedcOptions = (CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase?)dcOptions.Clone();
                if (clonedcOptions is null)
                {
                    return null;
                }

                newClonedObject.DcOptions.Add(clonedcOptions);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateDcOptions castedOther)
            {
                return true;
            }

            var dcOptionssize = castedOther.DcOptions.Count;
            if (dcOptionssize != DcOptions.Count)
            {
                return true;
            }

            for (var i = 0; i < dcOptionssize; i++)
            {
                if (castedOther.DcOptions[i].Compare(DcOptions[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}