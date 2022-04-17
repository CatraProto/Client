using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HistoryImport : CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 375566091; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }


#nullable enable
        public HistoryImport(long id)
        {
            Id = id;

        }
#nullable disable
        internal HistoryImport()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.historyImport";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}