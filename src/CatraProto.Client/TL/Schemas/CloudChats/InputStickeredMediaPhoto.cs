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
    public partial class InputStickeredMediaPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1251549527; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }


#nullable enable
        public InputStickeredMediaPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id)
        {
            Id = id;
        }
#nullable disable
        internal InputStickeredMediaPhoto()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputStickeredMediaPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickeredMediaPhoto();
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickeredMediaPhoto castedOther)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}