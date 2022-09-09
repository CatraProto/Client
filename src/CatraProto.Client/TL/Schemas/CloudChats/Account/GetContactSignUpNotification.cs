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
    public partial class GetContactSignUpNotification : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1626880216; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;


        public GetContactSignUpNotification()
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
            return "account.getContactSignUpNotification";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetContactSignUpNotification();
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetContactSignUpNotification castedOther)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}