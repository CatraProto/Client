using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	class FlagType : TypeBase
	{
		public FlagType()
		{
			NamingInfo = "flag";
			TypeInfo.IsBare = true;
		}

		public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter, string customTypeName = null, bool isAbstract = false)
		{
			stringBuilder.AppendLine($"\n[Newtonsoft.Json.JsonIgnore]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} int {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
		}


		public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
		{
			stringBuilder.AppendLine($"{StringTools.ThreeTabs}UpdateFlags();");
            base.WriteSerializer(stringBuilder, parameter);
		}

		public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = false)
		{
			throw new NotSupportedException();
		}
	}
}