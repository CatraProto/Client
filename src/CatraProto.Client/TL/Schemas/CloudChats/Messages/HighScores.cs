using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HighScores : HighScoresBase
    {
        public static int StaticConstructorId
        {
            get => -1707344487;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("scores")] public override IList<HighScoreBase> Scores { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Scores);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Scores = reader.ReadVector<HighScoreBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "messages.highScores";
        }
    }
}