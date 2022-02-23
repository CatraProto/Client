using System;
using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	class StringType : TypeBase
	{
		public StringType()
		{
			TypeInfo.IsBare = true;
			NamingInfo = "string";
		}

		public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter, string customTypeName = null, bool isAbstract = false)
		{
			var type = GetTypeName(NamingType.CamelCase, parameter, true);
			stringBuilder.AppendLine($"\n[Newtonsoft.Json.JsonProperty(\"{parameter.NamingInfo.OriginalName}\")]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {type} {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
		}

		public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
		{
			WriteFlagStart(stringBuilder, out var spacing, parameter);
			stringBuilder.AppendLine($"{spacing}writer.Write({parameter.NamingInfo.PascalCaseName});");
			WriteFlagEnd(stringBuilder, spacing, parameter);
		}

		public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = false)
		{
			throw new NotSupportedException();
		}
	}
}