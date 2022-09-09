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
    public partial class BaseThemeTinted : CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1834973166; }


        public BaseThemeTinted()
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
            return "baseThemeTinted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BaseThemeTinted();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BaseThemeTinted castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}