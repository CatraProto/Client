using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
    public partial class FileJpeg : CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 8322574; }



        public FileJpeg()
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
            return "storage.fileJpeg";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FileJpeg();
            return newClonedObject;

        }
#nullable disable
    }
}