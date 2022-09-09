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
    public partial class SecureRequiredTypeOneOf : CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 41187252; }

        [Newtonsoft.Json.JsonProperty("types")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> Types { get; set; }


#nullable enable
        public SecureRequiredTypeOneOf(List<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> types)
        {
            Types = types;
        }
#nullable disable
        internal SecureRequiredTypeOneOf()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktypes = writer.WriteVector(Types, false);
            if (checktypes.IsError)
            {
                return checktypes;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytypes.IsError)
            {
                return ReadResult<IObject>.Move(trytypes);
            }

            Types = trytypes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "secureRequiredTypeOneOf";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureRequiredTypeOneOf();
            newClonedObject.Types = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase>();
            foreach (var types in Types)
            {
                var clonetypes = (CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase?)types.Clone();
                if (clonetypes is null)
                {
                    return null;
                }

                newClonedObject.Types.Add(clonetypes);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureRequiredTypeOneOf castedOther)
            {
                return true;
            }

            var typessize = castedOther.Types.Count;
            if (typessize != Types.Count)
            {
                return true;
            }

            for (var i = 0; i < typessize; i++)
            {
                if (castedOther.Types[i].Compare(Types[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}