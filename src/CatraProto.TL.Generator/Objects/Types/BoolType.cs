using System;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    internal class Bool : TypeBase
    {
        private string _initialTypeName;

        public Bool(string startingTypeName)
        {
            _initialTypeName = startingTypeName;
            IsBare = true;
            Name = "bool";
        }

        public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter,
            string customTypeName = null, bool allowOverride = false)
        {
            var type = parameter.IsVector ? $"IList<{Name}>" : Name;
            if (parameter.HasFlag && _initialTypeName == "Bool")
            {
                type += '?';
            }
            
            stringBuilder.AppendLine(
                $"{StringTools.TwoTabs}{GetParameterAccessibility(parameter, allowOverride)} {type} {parameter.Name} {{ get; set; }}");
        }

        public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            if (_initialTypeName == "true")
            {
                stringBuilder.AppendLine(
                    $"{StringTools.ThreeTabs}{parameter.Name} = FlagsHelper.IsFlagSet({parameter.Flag.Name}, {parameter.Flag.Bit});");
                return;
            }

            stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.Name} = reader.Read<bool>();");
        }

        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            if (parameter.HasFlag)
                //If the parameter is a flag, there's no need to "serialize" because the flag has already been set by UpdateFlags();
                return;

            stringBuilder.AppendLine($"{StringTools.ThreeTabs}writer.Write({parameter.Name});");
        }

        public override void WriteFlagUpdate(StringBuilder stringBuilder, Parameter parameter)
        {
            if(!parameter.HasFlag) return;
            if (_initialTypeName == "true")
            {
                stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.Flag.Name} = {parameter.Name} ? FlagsHelper.SetFlag({parameter.Flag.Name}, {parameter.Flag.Bit}) : FlagsHelper.UnsetFlag({parameter.Flag.Name}, {parameter.Flag.Bit});");
                return;
            }
            
            base.WriteFlagUpdate(stringBuilder, parameter);
        }

        public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = false)
        {
            throw new NotSupportedException("Bool doesn't need a base type");
        }
    }
}