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