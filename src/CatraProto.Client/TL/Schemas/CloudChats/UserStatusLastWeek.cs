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
    public partial class UserStatusLastWeek : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 129960444; }


        public UserStatusLastWeek()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "userStatusLastWeek";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserStatusLastWeek();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UserStatusLastWeek castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}