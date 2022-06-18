using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueTypeBankStatement : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1995211763; }



        public SecureValueTypeBankStatement()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureValueTypeBankStatement";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueTypeBankStatement();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValueTypeBankStatement castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}