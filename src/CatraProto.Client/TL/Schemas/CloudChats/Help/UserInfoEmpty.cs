using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class UserInfoEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -206688531; }


        public UserInfoEmpty()
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
            return "help.userInfoEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserInfoEmpty();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UserInfoEmpty castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}