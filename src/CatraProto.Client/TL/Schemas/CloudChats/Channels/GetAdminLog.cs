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
    public partial class GetAdminLog : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            EventsFilter = 1 << 0,
            Admins = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 870184064; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public string Q { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("events_filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase EventsFilter { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("admins")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Admins { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public long MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("min_id")]
        public long MinId { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetAdminLog(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string q, long maxId, long minId, int limit)
        {
            Channel = channel;
            Q = q;
            MaxId = maxId;
            MinId = minId;
            Limit = limit;
        }
#nullable disable

        internal GetAdminLog()
        {
        }

        public void UpdateFlags()
        {
            Flags = EventsFilter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Admins == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
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

            writer.WriteString(Q);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkeventsFilter = writer.WriteObject(EventsFilter);
                if (checkeventsFilter.IsError)
                {
                    return checkeventsFilter;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkadmins = writer.WriteVector(Admins, false);
                if (checkadmins.IsError)
                {
                    return checkadmins;
                }
            }

            writer.WriteInt64(MaxId);
            writer.WriteInt64(MinId);
            writer.WriteInt32(Limit);

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
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var tryq = reader.ReadString();
            if (tryq.IsError)
            {
                return ReadResult<IObject>.Move(tryq);
            }

            Q = tryq.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryeventsFilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase>();
                if (tryeventsFilter.IsError)
                {
                    return ReadResult<IObject>.Move(tryeventsFilter);
                }

                EventsFilter = tryeventsFilter.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryadmins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryadmins.IsError)
                {
                    return ReadResult<IObject>.Move(tryadmins);
                }

                Admins = tryadmins.Value;
            }

            var trymaxId = reader.ReadInt64();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            var tryminId = reader.ReadInt64();
            if (tryminId.IsError)
            {
                return ReadResult<IObject>.Move(tryminId);
            }

            MinId = tryminId.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.getAdminLog";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAdminLog();
            newClonedObject.Flags = Flags;
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.Q = Q;
            if (EventsFilter is not null)
            {
                var cloneEventsFilter = (CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase?)EventsFilter.Clone();
                if (cloneEventsFilter is null)
                {
                    return null;
                }

                newClonedObject.EventsFilter = cloneEventsFilter;
            }

            if (Admins is not null)
            {
                newClonedObject.Admins = new List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
                foreach (var admins in Admins)
                {
                    var cloneadmins = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)admins.Clone();
                    if (cloneadmins is null)
                    {
                        return null;
                    }

                    newClonedObject.Admins.Add(cloneadmins);
                }
            }

            newClonedObject.MaxId = MaxId;
            newClonedObject.MinId = MinId;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAdminLog castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (Q != castedOther.Q)
            {
                return true;
            }

            if (EventsFilter is null && castedOther.EventsFilter is not null || EventsFilter is not null && castedOther.EventsFilter is null)
            {
                return true;
            }

            if (EventsFilter is not null && castedOther.EventsFilter is not null && EventsFilter.Compare(castedOther.EventsFilter))
            {
                return true;
            }

            if (Admins is null && castedOther.Admins is not null || Admins is not null && castedOther.Admins is null)
            {
                return true;
            }

            if (Admins is not null && castedOther.Admins is not null)
            {
                var adminssize = castedOther.Admins.Count;
                if (adminssize != Admins.Count)
                {
                    return true;
                }

                for (var i = 0; i < adminssize; i++)
                {
                    if (castedOther.Admins[i].Compare(Admins[i]))
                    {
                        return true;
                    }
                }
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            if (MinId != castedOther.MinId)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}