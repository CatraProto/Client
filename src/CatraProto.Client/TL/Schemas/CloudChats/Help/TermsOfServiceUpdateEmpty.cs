using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfServiceUpdateEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
    {
        public static int StaticConstructorId
        {
            get => -483352705;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }


    #nullable enable
        public TermsOfServiceUpdateEmpty(int expires)
        {
            Expires = expires;
        }
    #nullable disable
        internal TermsOfServiceUpdateEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Expires);
        }

        public override void Deserialize(Reader reader)
        {
            Expires = reader.Read<int>();
        }

        public override string ToString()
        {
            return "help.termsOfServiceUpdateEmpty";
        }
    }
}