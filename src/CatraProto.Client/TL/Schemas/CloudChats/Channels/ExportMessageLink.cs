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
    public partial class ExportMessageLink : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Grouped = 1 << 0,
            Thread = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -432034325; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("grouped")]
        public bool Grouped { get; set; }

        [Newtonsoft.Json.JsonProperty("thread")]
        public bool Thread { get; set; }

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }


#nullable enable
        public ExportMessageLink(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int id)
        {
            Channel = channel;
            Id = id;
        }
#nullable disable

        internal ExportMessageLink()
        {
        }

        public void UpdateFlags()
        {
            Flags = Grouped ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Thread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            writer.WriteInt32(Id);

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
            Grouped = FlagsHelper.IsFlagSet(Flags, 0);
            Thread = FlagsHelper.IsFlagSet(Flags, 1);
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.exportMessageLink";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ExportMessageLink();
            newClonedObject.Flags = Flags;
            newClonedObject.Grouped = Grouped;
            newClonedObject.Thread = Thread;
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.Id = Id;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ExportMessageLink castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Grouped != castedOther.Grouped)
            {
                return true;
            }

            if (Thread != castedOther.Thread)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}