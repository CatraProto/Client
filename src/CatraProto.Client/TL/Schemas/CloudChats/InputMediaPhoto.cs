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
    public partial class InputMediaPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TtlSeconds = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1279654347; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }


#nullable enable
        public InputMediaPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id)
        {
            Id = id;
        }
#nullable disable
        internal InputMediaPhoto()
        {
        }

        public override void UpdateFlags()
        {
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TtlSeconds.Value);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryttlSeconds = reader.ReadInt32();
                if (tryttlSeconds.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlSeconds);
                }

                TtlSeconds = tryttlSeconds.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMediaPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaPhoto();
            newClonedObject.Flags = Flags;
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.TtlSeconds = TtlSeconds;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMediaPhoto castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            if (TtlSeconds != castedOther.TtlSeconds)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}