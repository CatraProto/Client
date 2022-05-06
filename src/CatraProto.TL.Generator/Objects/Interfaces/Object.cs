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
using CatraProto.TL.Generator.Objects.Types;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Interfaces
{
    public abstract class Object
    {
        public int Id { get; set; }
        public Namespace Namespace { get; set; }
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
        public TypeBase Type { get; set; }
        public NamingInfo NamingInfo { get; set; }

        public virtual string GetMethodsAccessibility()
        {
            if (Type is RuntimeDefinedType)
            {
                return "public";
            }

            return "public override";
        }

        public virtual void WriteFlagsUpdating(StringBuilder builder)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteFlagUpdate(builder, parameter);
            }
        }

        public virtual void WriteConstructorParameters(StringBuilder builder)
        {
            var prams = Parameters.Where(x => !x.HasFlag && x.Type is not FlagType).ToList();
            for (var i = 0; i < prams.Count; i++)
            {
                var parameter = prams[i];
                parameter.Type.WriteMethodParameter(builder, parameter, true);
                if (i < prams.Count - 1)
                {
                    builder.Append(',');
                }
            }
        }

        public virtual bool HasNotNullParameters()
        {
            return Parameters.Exists(x => !x.HasFlag && x.Type is not FlagType);
        }

        public virtual void WriteConstructorBody(StringBuilder builder)
        {
            foreach (var parameter in Parameters.Where(x => !x.HasFlag && x.Type is not FlagType))
            {
                builder.Append(parameter.NamingInfo.PascalCaseName);
                builder.Append(" = ");
                builder.Append(parameter.NamingInfo.CamelCaseName);
                builder.Append(';');
                builder.AppendLine();
            }
        }

        public virtual void WriteFlagsEnums(StringBuilder builder)
        {
            var getFlaggedParameters = Parameters.Where(x => x.HasFlag).ToList();
            var dictionary = new Dictionary<string, List<Parameter>>();

            foreach (var flaggedParameter in getFlaggedParameters)
            {
                if (dictionary.ContainsKey(flaggedParameter.Flag.Name))
                {
                    dictionary[flaggedParameter.Flag.Name].Add(flaggedParameter);
                }
                else
                {
                    var list = new List<Parameter> { flaggedParameter };
                    dictionary.Add(flaggedParameter.Flag.Name, list);
                }
            }

            var lastIterationNumber = 1;
            foreach (var flag in dictionary)
            {
                builder.AppendLine($"{StringTools.TwoTabs}[Flags]");
                builder.AppendLine($"{StringTools.TwoTabs}public enum {StringTools.PascalCase(flag.Key)}Enum \n{StringTools.TwoTabs}{{");
                for (var index = 0; index < flag.Value.Count; index++)
                {
                    var parameter = flag.Value[index];
                    builder.Append($"{StringTools.ThreeTabs}{parameter.NamingInfo.PascalCaseName} = 1 << {parameter.Flag.Bit}");
                    if (flag.Value.Count != index + 1)
                    {
                        builder.Append(',');
                    }

                    builder.AppendLine();
                }

                builder.Append($"{StringTools.TwoTabs}}}");
                if (dictionary.Count > lastIterationNumber)
                {
                    builder.AppendLine();
                    builder.AppendLine();
                }

                lastIterationNumber++;
            }
        }

        public virtual void WriteParameters(StringBuilder builder)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteParameter(builder, parameter);
            }

        }

        public virtual void WriteSerializer(StringBuilder builder)
        {
            if (Id != 0)
            {
                builder.AppendLine($"writer.WriteInt32(ConstructorId);");
            }

            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteSerializer(builder, parameter);
            }

            builder.AppendLine($"\nreturn new WriteResult();");
        }

        public virtual void WriteDeserializer(StringBuilder builder)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteDeserializer(builder, parameter);
            }

            builder.AppendLine($"return new ReadResult<IObject>(this);");
        }

        public virtual string GetObjectName(NamingType type)
        {
            switch (type)
            {
                case NamingType.CamelCase:
                    return NamingInfo.CamelCaseName;
                case NamingType.PascalCase:
                    return NamingInfo.PascalCaseName;
                case NamingType.Original:
                    return NamingInfo.OriginalName;
                case NamingType.FullNamespace:
                    return Namespace.FullNamespace;
            }

            return "INVALID NAME";
        }

        public void WriteCloner(StringBuilder cloner)
        {
            cloner.AppendLine($"var newClonedObject = new {NamingInfo.PascalCaseName}();");
            foreach(var parameter in Parameters)
            {
                var writeNull = (!parameter.Type.TypeInfo.IsBare || parameter.VectorInfo.IsVector) && parameter.HasFlag;
                if (writeNull)
                {
                    cloner.AppendLine($"if ({parameter.NamingInfo.PascalCaseName} is not null){{");
                }

                void GetClonedObj(Parameter parameter, string name)
                {
                    cloner.AppendLine($"var clone{name} = ({parameter.Type.GetTypeName(NamingType.FullNamespace, parameter, false)}?){name}.Clone();");
                    cloner.AppendLine($"if(clone{name} is null){{");
                    cloner.AppendLine("return null;");
                    cloner.AppendLine("}");
                }

                if (parameter.VectorInfo.IsVector)
                {
                    cloner.AppendLine($"newClonedObject.{parameter.NamingInfo.PascalCaseName} = new List<{parameter.Type.GetTypeName(NamingType.FullNamespace, parameter, false)}>();");
                    cloner.AppendLine($"foreach(var {parameter.NamingInfo.CamelCaseName} in {parameter.NamingInfo.PascalCaseName}){{");
                    if (parameter.Type.TypeInfo.IsBare)
                    {                    
                        cloner.AppendLine($"newClonedObject.{parameter.NamingInfo.PascalCaseName}.Add({parameter.NamingInfo.CamelCaseName});");
                    }
                    else
                    {
                        GetClonedObj(parameter, parameter.NamingInfo.CamelCaseName);
                        cloner.AppendLine($"newClonedObject.{parameter.NamingInfo.PascalCaseName}.Add(clone{parameter.NamingInfo.CamelCaseName});");
                    }
                    cloner.AppendLine("}");
                }
                else
                {
                    if (parameter.Type.TypeInfo.IsBare)
                    {
                        cloner.AppendLine($"newClonedObject.{parameter.NamingInfo.PascalCaseName} = {parameter.NamingInfo.PascalCaseName};");
                    }
                    else
                    {
                        GetClonedObj(parameter, parameter.NamingInfo.PascalCaseName);
                        cloner.AppendLine($"newClonedObject.{parameter.NamingInfo.PascalCaseName} = clone{parameter.NamingInfo.PascalCaseName};");
                    }
                }

                if (writeNull)
                {
                    cloner.AppendLine("}");
                }
            }
            cloner.AppendLine("return newClonedObject;");

        }
    }
}