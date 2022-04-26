using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
    public partial class FileMp4 : CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1278304028; }



        public FileMp4()
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
            return "storage.fileMp4";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FileMp4();
            return newClonedObject;

        }
#nullable disable
    }
}