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
    public partial class UpdateGroupCallConnection : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Presentation = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 192428418; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("presentation")]
        public bool Presentation { get; set; }

        [Newtonsoft.Json.JsonProperty("params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


#nullable enable
        public UpdateGroupCallConnection(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
        {
            Params = pparams;
        }
#nullable disable
        internal UpdateGroupCallConnection()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Presentation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpparams = writer.WriteObject(Params);
            if (checkpparams.IsError)
            {
                return checkpparams;
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
            Presentation = FlagsHelper.IsFlagSet(Flags, 0);
            var trypparams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trypparams.IsError)
            {
                return ReadResult<IObject>.Move(trypparams);
            }

            Params = trypparams.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateGroupCallConnection";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateGroupCallConnection();
            newClonedObject.Flags = Flags;
            newClonedObject.Presentation = Presentation;
            var cloneParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Params.Clone();
            if (cloneParams is null)
            {
                return null;
            }

            newClonedObject.Params = cloneParams;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateGroupCallConnection castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Presentation != castedOther.Presentation)
            {
                return true;
            }

            if (Params.Compare(castedOther.Params))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}