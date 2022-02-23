using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class KeyboardButtonUserProfile : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        public static int StaticConstructorId
        {
            get => 814112961;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


    #nullable enable
        public KeyboardButtonUserProfile(string text, long userId)
        {
            Text = text;
            UserId = userId;
        }
    #nullable disable
        internal KeyboardButtonUserProfile()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Text);
            writer.Write(UserId);
        }

        public override void Deserialize(Reader reader)
        {
            Text = reader.Read<string>();
            UserId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "keyboardButtonUserProfile";
        }
    }
}