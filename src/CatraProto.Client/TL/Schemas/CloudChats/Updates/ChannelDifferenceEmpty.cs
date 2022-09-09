using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class ChannelDifferenceEmpty : CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Final = 1 << 0,
            Timeout = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1041346555; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("final")]
        public sealed override bool Final { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("timeout")]
        public sealed override int? Timeout { get; set; }


#nullable enable
        public ChannelDifferenceEmpty(int pts)
        {
            Pts = pts;
        }
#nullable disable
        internal ChannelDifferenceEmpty()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Final ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Pts);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Timeout.Value);
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
            Final = FlagsHelper.IsFlagSet(Flags, 0);
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytimeout = reader.ReadInt32();
                if (trytimeout.IsError)
                {
                    return ReadResult<IObject>.Move(trytimeout);
                }

                Timeout = trytimeout.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updates.channelDifferenceEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelDifferenceEmpty();
            newClonedObject.Flags = Flags;
            newClonedObject.Final = Final;
            newClonedObject.Pts = Pts;
            newClonedObject.Timeout = Timeout;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelDifferenceEmpty castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Final != castedOther.Final)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (Timeout != castedOther.Timeout)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}