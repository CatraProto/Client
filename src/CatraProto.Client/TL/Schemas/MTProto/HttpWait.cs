using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class HttpWait : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1835453025; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("max_delay")]
        public int MaxDelay { get; set; }

        [Newtonsoft.Json.JsonProperty("wait_after")]
        public int WaitAfter { get; set; }

        [Newtonsoft.Json.JsonProperty("max_wait")]
        public int MaxWait { get; set; }


#nullable enable
        public HttpWait(int maxDelay, int waitAfter, int maxWait)
        {
            MaxDelay = maxDelay;
            WaitAfter = waitAfter;
            MaxWait = maxWait;
        }
#nullable disable

        internal HttpWait()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MaxDelay);
            writer.WriteInt32(WaitAfter);
            writer.WriteInt32(MaxWait);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymaxDelay = reader.ReadInt32();
            if (trymaxDelay.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDelay);
            }

            MaxDelay = trymaxDelay.Value;
            var trywaitAfter = reader.ReadInt32();
            if (trywaitAfter.IsError)
            {
                return ReadResult<IObject>.Move(trywaitAfter);
            }

            WaitAfter = trywaitAfter.Value;
            var trymaxWait = reader.ReadInt32();
            if (trymaxWait.IsError)
            {
                return ReadResult<IObject>.Move(trymaxWait);
            }

            MaxWait = trymaxWait.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "http_wait";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new HttpWait();
            newClonedObject.MaxDelay = MaxDelay;
            newClonedObject.WaitAfter = WaitAfter;
            newClonedObject.MaxWait = MaxWait;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not HttpWait castedOther)
            {
                return true;
            }

            if (MaxDelay != castedOther.MaxDelay)
            {
                return true;
            }

            if (WaitAfter != castedOther.WaitAfter)
            {
                return true;
            }

            if (MaxWait != castedOther.MaxWait)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}