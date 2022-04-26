using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatesCombined : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1918567619; }

        [Newtonsoft.Json.JsonProperty("updates")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> Updates { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq_start")]
        public int SeqStart { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")]
        public int Seq { get; set; }


#nullable enable
        public UpdatesCombined(List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> updates, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, int date, int seqStart, int seq)
        {
            Updates = updates;
            Users = users;
            Chats = chats;
            Date = date;
            SeqStart = seqStart;
            Seq = seq;

        }
#nullable disable
        internal UpdatesCombined()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkupdates = writer.WriteVector(Updates, false);
            if (checkupdates.IsError)
            {
                return checkupdates;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }
            writer.WriteInt32(Date);
            writer.WriteInt32(SeqStart);
            writer.WriteInt32(Seq);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryupdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryupdates.IsError)
            {
                return ReadResult<IObject>.Move(tryupdates);
            }
            Updates = tryupdates.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryseqStart = reader.ReadInt32();
            if (tryseqStart.IsError)
            {
                return ReadResult<IObject>.Move(tryseqStart);
            }
            SeqStart = tryseqStart.Value;
            var tryseq = reader.ReadInt32();
            if (tryseq.IsError)
            {
                return ReadResult<IObject>.Move(tryseq);
            }
            Seq = tryseq.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatesCombined";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatesCombined();
            foreach (var updates in Updates)
            {
                var cloneupdates = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)updates.Clone();
                if (cloneupdates is null)
                {
                    return null;
                }
                newClonedObject.Updates.Add(cloneupdates);
            }
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }
                newClonedObject.Chats.Add(clonechats);
            }
            newClonedObject.Date = Date;
            newClonedObject.SeqStart = SeqStart;
            newClonedObject.Seq = Seq;
            return newClonedObject;

        }
#nullable disable
    }
}