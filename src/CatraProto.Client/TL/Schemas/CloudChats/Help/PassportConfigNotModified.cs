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
    public partial class PassportConfigNotModified : CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1078332329; }


        public PassportConfigNotModified()
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
            return "help.passportConfigNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PassportConfigNotModified();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PassportConfigNotModified castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}