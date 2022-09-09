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
    public partial class UpdateChannelTooLong : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pts = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 277713951; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int? Pts { get; set; }


#nullable enable
        public UpdateChannelTooLong(long channelId)
        {
            ChannelId = channelId;
        }
#nullable disable
        internal UpdateChannelTooLong()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pts == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChannelId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(Pts.Value);
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
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }

            ChannelId = trychannelId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trypts = reader.ReadInt32();
                if (trypts.IsError)
                {
                    return ReadResult<IObject>.Move(trypts);
                }

                Pts = trypts.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChannelTooLong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelTooLong();
            newClonedObject.Flags = Flags;
            newClonedObject.ChannelId = ChannelId;
            newClonedObject.Pts = Pts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelTooLong castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}