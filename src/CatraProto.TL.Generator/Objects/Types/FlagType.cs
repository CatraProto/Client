using System;
using System.Collections.Generic;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    internal class FlagType : TypeBase
    {
        public FlagType()
        {
            Name = "flag";
            IsBare = true;
        }

        public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter,
            string customTypeName = null, bool isAbstract = false)
        {
            stringBuilder.AppendLine($"{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} int {parameter.Name} {{ get; set; }}");
        }

        public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.Name} = reader.Read<int>();");
        }

        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            stringBuilder.AppendLine($"{StringTools.ThreeTabs}UpdateFlags();");
            stringBuilder.AppendLine($"{StringTools.ThreeTabs}writer.Write({parameter.Name});");
        }

        public override List<Namespace> GetRequiredNamespaces(Parameter parameter)
        {
            var list = base.GetRequiredNamespaces(parameter);
            list.Add(new Namespace("System.FlagsAttribute", false));
            return list;
        }

        public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = false)
        {
            throw new NotSupportedException();
        }
    }
}