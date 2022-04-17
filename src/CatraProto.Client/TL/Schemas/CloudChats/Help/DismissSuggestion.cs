using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class DismissSuggestion : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -183649631; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("suggestion")]
        public string Suggestion { get; set; }


#nullable enable
        public DismissSuggestion(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string suggestion)
        {
            Peer = peer;
            Suggestion = suggestion;

        }
#nullable disable

        internal DismissSuggestion()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteString(Suggestion);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trysuggestion = reader.ReadString();
            if (trysuggestion.IsError)
            {
                return ReadResult<IObject>.Move(trysuggestion);
            }
            Suggestion = trysuggestion.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.dismissSuggestion";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}