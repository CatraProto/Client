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
using System.Reflection.PortableExecutable;
using System.Text;
using CatraProto.TL.Generator.CodeGeneration;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    public class RuntimeDefinedType : TypeBase
    {
        public RuntimeDefinedType()
        {
            Namespace = new Namespace("CatraProto.TL.Interfaces.IObject", false);
            TypeInfo.IsBare = true;
            NamingInfo = "IObject";
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

        public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            if(parameter.NamingInfo.OriginalName == "result")
            {
                stringBuilder.AppendLine($"var try{parameter.NamingInfo.CamelCaseName} = reader.ReadObject();");
                stringBuilder.AppendLine($"if(try{parameter.NamingInfo.CamelCaseName}.IsError){{\nreturn ReadResult<IObject>.Move(try{parameter.NamingInfo.CamelCaseName});\n}}");
                stringBuilder.AppendLine($"{parameter.NamingInfo.PascalCaseName} = try{parameter.NamingInfo.CamelCaseName}.Value;");
            }
            else
            {
                base.WriteDeserializer(stringBuilder, parameter);
            }
        }

        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            if (parameter.NamingInfo.OriginalName == "result")
            {
                stringBuilder.AppendLine($"var check{parameter.NamingInfo.CamelCaseName} = writer.Write({parameter.NamingInfo.PascalCaseName});");
                stringBuilder.AppendLine($"if(check{parameter.NamingInfo.CamelCaseName}.IsError){{\n return check{parameter.NamingInfo.CamelCaseName}; \n}}");
            }
            else
            {
                base.WriteSerializer(stringBuilder, parameter);
            }
        }


        public override string GetTypeName(NamingType type, Parameter parameter, bool includeVector, bool forceBase = false, NameContext nameContext = NameContext.Deserialization)
        {
            if (parameter is not null && parameter.NamingInfo.OriginalName == "result")
            {
                return "object";
            }

            if (includeVector && parameter.VectorInfo.IsVector)
            {
                return "IList<IObject>";
            }

            return "IObject";
        }
    }
}