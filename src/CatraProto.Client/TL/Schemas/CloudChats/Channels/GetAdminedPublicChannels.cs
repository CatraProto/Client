using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetAdminedPublicChannels : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ByLocation = 1 << 0,
            CheckLimit = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -122669393; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("by_location")]
        public bool ByLocation { get; set; }

        [Newtonsoft.Json.JsonProperty("check_limit")]
        public bool CheckLimit { get; set; }


        public GetAdminedPublicChannels()
        {
        }

        public void UpdateFlags()
        {
            Flags = ByLocation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = CheckLimit ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            ByLocation = FlagsHelper.IsFlagSet(Flags, 0);
            CheckLimit = FlagsHelper.IsFlagSet(Flags, 1);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.getAdminedPublicChannels";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAdminedPublicChannels();
            newClonedObject.Flags = Flags;
            newClonedObject.ByLocation = ByLocation;
            newClonedObject.CheckLimit = CheckLimit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAdminedPublicChannels castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ByLocation != castedOther.ByLocation)
            {
                return true;
            }

            if (CheckLimit != castedOther.CheckLimit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}