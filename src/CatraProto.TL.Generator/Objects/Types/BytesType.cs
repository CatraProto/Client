using System;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    internal class BytesType : TypeBase
    {
        public BytesType()
        {
            Name = "byte[]";
            IsBare = true;
        }
        
        public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter,
            string customTypeName = null, bool isAbstract = false)
        {
            var type = parameter.IsVector ? $"IList<{Name}>" : Name;
            stringBuilder.AppendLine(
                $"{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {type} {parameter.Name} {{ get; set; }}");
        }
        
        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            stringBuilder.AppendLine($"{spacing}writer.Write({parameter.Name});");
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }
        
        public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = true)
        {
            throw new NotSupportedException("Byte[] doesn't need a base type");
        }
    }
}