/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	class GenericType : TypeBase
	{
		public GenericType(string ns, TypeInfo typeInfo)
		{
			Namespace = new Namespace(ns);
			TypeInfo = typeInfo;
			NamingInfo = ns.Split('.')[^1];
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