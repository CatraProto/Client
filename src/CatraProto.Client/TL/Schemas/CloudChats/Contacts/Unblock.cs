using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Unblock : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1096393392; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Id { get; set; }


#nullable enable
        public Unblock(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase id)
        {
            Id = id;

        }
#nullable disable

        internal Unblock()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "contacts.unblock";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new Unblock();
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }
            newClonedObject.Id = cloneId;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not Unblock castedOther)
            {
                return true;
            }
            if (Id.Compare(castedOther.Id))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}