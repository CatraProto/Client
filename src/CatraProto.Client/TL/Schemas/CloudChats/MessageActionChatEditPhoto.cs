using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatEditPhoto : MessageActionBase
	{


        public static int ConstructorId { get; } = 2144015272;
		public PhotoBase Photo { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photo);

		}

		public override void Deserialize(Reader reader)
		{
			Photo = reader.Read<PhotoBase>();

		}
	}
}