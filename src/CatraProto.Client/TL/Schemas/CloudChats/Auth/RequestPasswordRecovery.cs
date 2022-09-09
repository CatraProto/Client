using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class RequestPasswordRecovery : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -661144474; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;


        public RequestPasswordRecovery()
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
            return "auth.requestPasswordRecovery";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestPasswordRecovery();
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestPasswordRecovery castedOther)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}