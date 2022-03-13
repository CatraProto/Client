using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdateDialogFilter : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Filter = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 450142282; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("filter")]
		public CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

        
        #nullable enable
 public UpdateDialogFilter (int id)
{
 Id = id;
 
}
#nullable disable
                
        internal UpdateDialogFilter() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Filter);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.updateDialogFilter";
		}
	}
}