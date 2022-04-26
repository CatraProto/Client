using System;
using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	class BoolType : TypeBase
	{
		public string InitialTypeName { get; }

		public BoolType(string startingTypeName)
		{
			InitialTypeName = startingTypeName;
			TypeInfo.IsBare = true;
			NamingInfo = "bool";
		}
		
		public override void WriteMethodParameter(StringBuilder stringBuilder, Parameter parameter, bool nullableContext = false)
		{
			var writtenType = parameter.Type.GetTypeName(NamingType.FullNamespace, parameter, true);
			var after = "";

			if (InitialTypeName == "true")
			{
				after += " = false";
			}
			else if (InitialTypeName != "true" && parameter.HasFlag)
			{
				writtenType += "?";
				after = " = null";
			}

			stringBuilder.Append(writtenType + " " + parameter.NamingInfo.CamelCaseName + after);
		}

		public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter, string customTypeName = null, bool allowOverride = false)
		{
			var type = GetTypeName(NamingType.FullNamespace, parameter,true);
			if (parameter.HasFlag && InitialTypeName == "Bool")
			{
				type += '?';
			}

			stringBuilder.AppendLine($"\n[Newtonsoft.Json.JsonProperty(\"{parameter.NamingInfo.OriginalName}\")]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, allowOverride)} {type} {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
		}

		public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
		{
			if (InitialTypeName == "true")
			{
				stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.NamingInfo.PascalCaseName} = FlagsHelper.IsFlagSet({parameter.Flag.Name}, {parameter.Flag.Bit});");
				return;
			}


            base.WriteDeserializer(stringBuilder, parameter);
		}

		public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
		{
			if (parameter.HasFlag && InitialTypeName == "true")
				//If the parameter is a flag, there's no need to serialize because the flag has already been set by UpdateFlags();
			{
				return;
			}

            WriteFlagStart(stringBuilder, out var spacing, parameter);
			stringBuilder.AppendLine($"var check{parameter.NamingInfo.CamelCaseName} = {StringTools.ThreeTabs}writer.WriteBool({parameter.NamingInfo.PascalCaseName}{(parameter.HasFlag ? ".Value" : "")});");
            stringBuilder.AppendLine($"if(check{parameter.NamingInfo.CamelCaseName}.IsError){{\n return check{parameter.NamingInfo.CamelCaseName}; \n}}");
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public override void WriteFlagUpdate(StringBuilder stringBuilder, Parameter parameter)
		{
			if (!parameter.HasFlag)
			{
				return;
			}

			if (InitialTypeName == "true")
			{
				stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.Flag.Name} = {parameter.NamingInfo.PascalCaseName} ? FlagsHelper.SetFlag({parameter.Flag.Name}, {parameter.Flag.Bit}) : FlagsHelper.UnsetFlag({parameter.Flag.Name}, {parameter.Flag.Bit});");
				return;
			}

			base.WriteFlagUpdate(stringBuilder, parameter);
		}

		public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = false)
		{
			throw new NotSupportedException("Bool doesn't need a base type");
		}

		public override bool Equals(object obj)
		{
			if (obj is BoolType type)
			{
				return InitialTypeName == type.InitialTypeName;
			}

			return base.Equals(obj);
		}

		protected bool Equals(BoolType other)
		{
			return base.Equals(other);
		}

		public override int GetHashCode()
		{
			return InitialTypeName != null ? InitialTypeName.GetHashCode() : 0;
		}
	}
}