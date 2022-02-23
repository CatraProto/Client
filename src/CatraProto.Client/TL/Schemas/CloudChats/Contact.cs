using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Contact : CatraProto.Client.TL.Schemas.CloudChats.ContactBase
    {
        public static int StaticConstructorId
        {
            get => 341499403;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("mutual")]
        public sealed override bool Mutual { get; set; }


    #nullable enable
        public Contact(long userId, bool mutual)
        {
            UserId = userId;
            Mutual = mutual;
        }
    #nullable disable
        internal Contact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(Mutual);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
            Mutual = reader.Read<bool>();
        }

        public override string ToString()
        {
            return "contact";
        }
    }
}