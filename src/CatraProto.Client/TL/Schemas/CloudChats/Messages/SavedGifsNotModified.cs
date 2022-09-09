using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SavedGifsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -402498398; }


        public SavedGifsNotModified()
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
            return "messages.savedGifsNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedGifsNotModified();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedGifsNotModified castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}