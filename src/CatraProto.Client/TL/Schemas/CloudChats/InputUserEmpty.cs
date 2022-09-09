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
    public partial class InputUserEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputUserBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1182234929; }


        public InputUserEmpty()
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
            return "inputUserEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputUserEmpty();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputUserEmpty castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}