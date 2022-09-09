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
    public partial class InputAppEvent : CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 488313413; }

        [Newtonsoft.Json.JsonProperty("time")] public sealed override double Time { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public sealed override long Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Data { get; set; }


#nullable enable
        public InputAppEvent(double time, string type, long peer, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase data)
        {
            Time = time;
            Type = type;
            Peer = peer;
            Data = data;
        }
#nullable disable
        internal InputAppEvent()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteDouble(Time);

            writer.WriteString(Type);
            writer.WriteInt64(Peer);
            var checkdata = writer.WriteObject(Data);
            if (checkdata.IsError)
            {
                return checkdata;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytime = reader.ReadDouble();
            if (trytime.IsError)
            {
                return ReadResult<IObject>.Move(trytime);
            }

            Time = trytime.Value;
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var trypeer = reader.ReadInt64();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trydata = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputAppEvent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputAppEvent();
            newClonedObject.Time = Time;
            newClonedObject.Type = Type;
            newClonedObject.Peer = Peer;
            var cloneData = (CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase?)Data.Clone();
            if (cloneData is null)
            {
                return null;
            }

            newClonedObject.Data = cloneData;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputAppEvent castedOther)
            {
                return true;
            }

            if (Time != castedOther.Time)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            if (Peer != castedOther.Peer)
            {
                return true;
            }

            if (Data.Compare(castedOther.Data))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}