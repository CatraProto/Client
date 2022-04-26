using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgsAllInfo : CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1933520591; }

        [Newtonsoft.Json.JsonProperty("msg_ids")]
        public sealed override List<long> MsgIds { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public sealed override byte[] Info { get; set; }


#nullable enable
        public MsgsAllInfo(List<long> msgIds, byte[] info)
        {
            MsgIds = msgIds;
            Info = info;

        }
#nullable disable
        internal MsgsAllInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(MsgIds, false);

            writer.WriteBytes(Info);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgIds = reader.ReadVector<long>(ParserTypes.Int64);
            if (trymsgIds.IsError)
            {
                return ReadResult<IObject>.Move(trymsgIds);
            }
            MsgIds = trymsgIds.Value;
            var tryinfo = reader.ReadBytes();
            if (tryinfo.IsError)
            {
                return ReadResult<IObject>.Move(tryinfo);
            }
            Info = tryinfo.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msgs_all_info";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgsAllInfo();
            foreach (var msgIds in MsgIds)
            {
                newClonedObject.MsgIds.Add(msgIds);
            }
            newClonedObject.Info = Info;
            return newClonedObject;

        }
#nullable disable
    }
}