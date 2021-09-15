using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class UserInfo : UserInfoBase
    {
        public static int StaticConstructorId
        {
            get => 32192344;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("entities")] public IList<MessageEntityBase> Entities { get; set; }

        [JsonProperty("author")] public string Author { get; set; }

        [JsonProperty("date")] public int Date { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Message);
            writer.Write(Entities);
            writer.Write(Author);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<string>();
            Entities = reader.ReadVector<MessageEntityBase>();
            Author = reader.Read<string>();
            Date = reader.Read<int>();
        }

        public override string ToString()
        {
            return "help.userInfo";
        }
    }
}