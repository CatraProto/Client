using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	public class RuntimeDefinedType : TypeBase
	{
		public RuntimeDefinedType()
		{
			TypeInfo.IsBare = true;
			NamingInfo = "IObject";
		}

		public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
		{
			WriteFlagStart(stringBuilder, out var spacing, parameter);
			stringBuilder.AppendLine(parameter.VectorInfo.IsVector
				? $"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.ReadVector<{GetTypeName(NamingType.FullNamespace, parameter, false)}>();"
				: $"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.Read<{GetTypeName(NamingType.FullNamespace, parameter, false)}>();"
			);
			WriteFlagEnd(stringBuilder, spacing, parameter);
		}

		public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
		{
			WriteFlagStart(stringBuilder, out var spacing, parameter);
			stringBuilder.AppendLine($"{spacing}writer.Write({parameter.NamingInfo.PascalCaseName});");
			WriteFlagEnd(stringBuilder, spacing, parameter);
		}

		public override void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false)
		{
			var writtenObjs = new List<Parameter>();
			foreach (var referencedObject in ReferencedObjects.Where(x => x is not Method))
			{
				foreach (var referencedObjectParameter in referencedObject.Parameters)
				{
					if (!writtenObjs.Contains(referencedObjectParameter) && referencedObjectParameter.IsCommon)
					{
						writtenObjs.Add(referencedObjectParameter);
						referencedObjectParameter.Type.WriteParameter(stringBuilder, referencedObjectParameter, isAbstract: isAbstract);
					}
				}
			}
		}

		public override string GetTypeName(NamingType type, Parameter parameter, bool includeVector, NameContext nameContext = NameContext.Deserialization)
		{
			if (includeVector && parameter.VectorInfo.IsVector)
			{
				return "IList<IObject>";
			}

			return "IObject";
		}
	}
}