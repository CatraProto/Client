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
    public partial class InputEncryptedFileEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 406307684; }


        public InputEncryptedFileEmpty()
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
            return "inputEncryptedFileEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputEncryptedFileEmpty();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputEncryptedFileEmpty castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}