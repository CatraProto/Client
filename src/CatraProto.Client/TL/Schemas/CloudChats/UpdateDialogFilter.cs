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
    public partial class UpdateDialogFilter : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Filter = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 654302845; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }


#nullable enable
        public UpdateDialogFilter(int id)
        {
            Id = id;
        }
#nullable disable
        internal UpdateDialogFilter()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkfilter = writer.WriteObject(Filter);
                if (checkfilter.IsError)
                {
                    return checkfilter;
                }
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
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
                if (tryfilter.IsError)
                {
                    return ReadResult<IObject>.Move(tryfilter);
                }

                Filter = tryfilter.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateDialogFilter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateDialogFilter();
            newClonedObject.Flags = Flags;
            newClonedObject.Id = Id;
            if (Filter is not null)
            {
                var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase?)Filter.Clone();
                if (cloneFilter is null)
                {
                    return null;
                }

                newClonedObject.Filter = cloneFilter;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateDialogFilter castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Filter is null && castedOther.Filter is not null || Filter is not null && castedOther.Filter is null)
            {
                return true;
            }

            if (Filter is not null && castedOther.Filter is not null && Filter.Compare(castedOther.Filter))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}