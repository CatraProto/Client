using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetTermsOfServiceUpdate : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase>
	{


        public static int ConstructorId { get; } = 749019089;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}