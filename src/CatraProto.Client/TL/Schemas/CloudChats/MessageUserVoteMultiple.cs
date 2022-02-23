using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageUserVoteMultiple : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
    {
        public static int StaticConstructorId
        {
            get => -1973033641;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("options")]
        public IList<byte[]> Options { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }


    #nullable enable
        public MessageUserVoteMultiple(long userId, IList<byte[]> options, int date)
        {
            UserId = userId;
            Options = options;
            Date = date;
        }
    #nullable disable
        internal MessageUserVoteMultiple()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(Options);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
            Options = reader.ReadVector<byte[]>();
            Date = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messageUserVoteMultiple";
        }
    }
}