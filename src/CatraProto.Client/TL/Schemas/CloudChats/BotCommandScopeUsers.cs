using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotCommandScopeUsers : CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1011811544; }



        public BotCommandScopeUsers()
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
            return "botCommandScopeUsers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotCommandScopeUsers();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not BotCommandScopeUsers castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}