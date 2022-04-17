using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class AdminLogResults : CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -309659827; }

        [Newtonsoft.Json.JsonProperty("events")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> Events { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public AdminLogResults(List<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> events, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Events = events;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal AdminLogResults()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkevents = writer.WriteVector(Events, false);
            if (checkevents.IsError)
            {
                return checkevents;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryevents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryevents.IsError)
            {
                return ReadResult<IObject>.Move(tryevents);
            }
            Events = tryevents.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channels.adminLogResults";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}