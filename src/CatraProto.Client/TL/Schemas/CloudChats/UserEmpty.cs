using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UserEmpty : CatraProto.Client.TL.Schemas.CloudChats.UserBase
    {
        public static int StaticConstructorId
        {
            get => -742634630;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }


    #nullable enable
        public UserEmpty(long id)
        {
            Id = id;
        }
    #nullable disable
        internal UserEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
        }

        public override string ToString()
        {
            return "userEmpty";
        }
    }
}