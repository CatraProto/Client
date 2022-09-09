using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetAllSecureValues : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1299661699; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;


        public GetAllSecureValues()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.getAllSecureValues";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAllSecureValues();
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAllSecureValues castedOther)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}