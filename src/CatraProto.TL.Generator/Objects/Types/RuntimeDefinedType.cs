using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	public class RuntimeDefinedType : TypeBase
	{
		public RuntimeDefinedType()
		{
			IsBare = true;
			Name = "IObject";
		}

		public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
		{
			WriteFlagStart(stringBuilder, out var spacing, parameter);
			stringBuilder.AppendLine(parameter.IsVector
				? $"{spacing}{parameter.Name} = reader.ReadVector<{parameter.Type.Name}>();"
				: $"{spacing}{parameter.Name} = reader.Read<{parameter.Type.Name}>();");
			WriteFlagEnd(stringBuilder, spacing, parameter);
		}

		public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
		{
			WriteFlagStart(stringBuilder, out var spacing, parameter);
			stringBuilder.AppendLine($"{spacing}writer.Write({parameter.Name});");
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
	}
}