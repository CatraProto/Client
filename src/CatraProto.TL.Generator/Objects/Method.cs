using System.Text;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;

namespace CatraProto.TL.Generator.Objects
{
    internal class Method : Object
    {
        public bool ReturnsVector { get; set; }
        public MethodType MethodType { get; }

        public Method(MethodType methodType)
        {
            MethodType = methodType;
        }

        public override void WriteParameters(StringBuilder builder)
        {
            builder.AppendLine(Parameters.Exists(x => x.Name == "Type") ? $"{StringTools.TwoTabs}public System.Type IMethod<{MethodType}>.Type {{ get; init; }} = typeof({Namespace.FullNamespace});" : $"{StringTools.TwoTabs}public System.Type Type {{ get; init; }} = typeof({Namespace.FullNamespace});");
            builder.AppendLine(Parameters.Exists(x => x.Name == "IsVector") ? $"{StringTools.TwoTabs}public bool IMethod<{MethodType}>.IsVector {{ get; init; }} = {ReturnsVector.ToString().ToLower()};" : $"{StringTools.TwoTabs}public bool IsVector {{ get; init; }} = {ReturnsVector.ToString().ToLower()};");
            base.WriteParameters(builder);
        }

        public void WriteMethod(StringBuilder builder)
        {
            var args = new StringBuilder();
            string returnType;
            if (Type.IsBare)
            {
                returnType = ReturnsVector ? "IList<" + Type.Name + ">" : Type.Name;
            }
            else
            {
                returnType = ReturnsVector ? "IList<" + Type.Namespace.FullNamespace + ">" : Type.Namespace.FullNamespace;
            }

            for (var index = 0; index < Parameters.Count; index++)
            {
                var parameter = Parameters[index];
                parameter.Type.WriteMethodParameter(args, parameter);
                if (index < Parameters.Count - 1)
                {
                    args.Append(',');
                }
            }

            builder.AppendLine($"{StringTools.TwoTabs}public async Task<{returnType}> {Name}({args})\n{StringTools.TwoTabs}{{");
            builder.AppendLine($"{StringTools.ThreeTabs}var request = new {Namespace.FullNamespace}()\n{StringTools.ThreeTabs}{{");
            foreach (var parameter in Parameters)
            {
                builder.AppendLine($"{StringTools.FourTabs}{parameter.Name} = {parameter.InMethodName},");
            }

            builder.AppendLine($"{StringTools.ThreeTabs}}}");
            builder.AppendLine($"{StringTools.ThreeTabs}BLA BLA send Request");
            builder.AppendLine("}");
        }
    }
}