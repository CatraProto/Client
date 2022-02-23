using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class FutureSalts : CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase
    {
        public static int StaticConstructorId
        {
            get => -1370486635;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public sealed override long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("now")] public sealed override int Now { get; set; }

        [Newtonsoft.Json.JsonProperty("salts")]
        public sealed override IList<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }


    #nullable enable
        public FutureSalts(long reqMsgId, int now, IList<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> salts)
        {
            ReqMsgId = reqMsgId;
            Now = now;
            Salts = salts;
        }
    #nullable disable
        internal FutureSalts()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ReqMsgId);
            writer.Write(Now);
            writer.Write(Salts);
        }

        public override void Deserialize(Reader reader)
        {
            ReqMsgId = reader.Read<long>();
            Now = reader.Read<int>();
            Salts = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<CatraProto.Client.TL.Schemas.MTProto.FutureSalt>(CatraProto.Client.TL.Schemas.MergedProvider.Singleton), true);
        }

        public override string ToString()
        {
            return "future_salts";
        }
    }
}