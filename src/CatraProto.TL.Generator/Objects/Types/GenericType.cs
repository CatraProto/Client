using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	class GenericType : TypeBase
	{
		public GenericType(string ns)
		{
			Namespace = new Namespace(ns);
			Name = Namespace.Class;
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