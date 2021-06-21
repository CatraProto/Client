using System;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.Objects.Types;
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
            var type = Type is RuntimeDefinedType ? "IObject" : Type.IsBare ? Type.Name : Type.Namespace.FullNamespace;
            builder.AppendLine($"{StringTools.TwoTabs}public System.Type " + (Parameters.Exists(x => x.Name == "Type") ? "IMethod." : "") + $"Type {{ get; init; }} = typeof({type});");
            builder.AppendLine($"{StringTools.TwoTabs}public bool " + (Parameters.Exists(x => x.Name == "IsVector") ? "IMethod." : "") + $"IsVector {{ get; init; }} = {ReturnsVector.ToString().ToLower()};");
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
            
            var parametersOrdered = Parameters
                .Where(x => x.Type is not FlagType)
                .Where(x => !x.HasFlag)
                .Concat(Parameters.Where(x => x.HasFlag))
                .ToList();

            for (var index = 0; index < parametersOrdered.Count; index++)
            {
                var parameter = parametersOrdered[index];
                parameter.Type.WriteMethodParameter(args, parameter);
                if (index < parametersOrdered.Count - 1)
                {
                    args.Append(", ");
                }
            }

            var comma = args.Length == 0 ? "" : ",";
            builder.AppendLine($"{StringTools.TwoTabs}public async Task<RpcMessage<{returnType}>> {Name}({args}{comma} CancellationToken cancellationToken = default)\n{StringTools.TwoTabs}{{");
            builder.AppendLine($"{StringTools.ThreeTabs}var rpcResponse = new RpcMessage<{returnType}>();");
            builder.AppendLine($"{StringTools.ThreeTabs}var methodBody = new {Namespace.FullNamespace}()\n{StringTools.ThreeTabs}{{");
            foreach (var parameter in parametersOrdered)
            {
                builder.AppendLine($"{StringTools.FourTabs}{parameter.Name} = {parameter.InMethodName},");
            }

            builder.AppendLine($"{StringTools.ThreeTabs}}};");
            builder.AppendLine();
            builder.AppendLine($"{StringTools.ThreeTabs}await await _messagesHandler.EnqueueMessage(new OutgoingMessage\n{StringTools.FourTabs}{{\n{StringTools.FiveTabs}Body = methodBody,\n{StringTools.FiveTabs}CancellationToken = cancellationToken,\n{StringTools.FiveTabs}IsEncrypted = {(MethodType == MethodType.ReturnsUnencrypted ? "false" : "true")}\n{StringTools.FourTabs}}}, rpcResponse);");
            builder.AppendLine($"{StringTools.ThreeTabs}return rpcResponse;");
            builder.AppendLine($"{StringTools.TwoTabs}}}");
        }
    }
}