using System.Linq;
using System.Text;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Objects.Types;

namespace CatraProto.TL.Generator.Objects
{
    class Method : Object
    {
        public bool ReturnsVector { get; set; }
        public MethodCompletionType MethodCompletionType { get; }

        public Method(MethodCompletionType methodCompletionType)
        {
            MethodCompletionType = methodCompletionType;
        }

        public override void WriteParameters(StringBuilder builder)
        {
            var type = Type.GetTypeName(NamingType.FullNamespace, null, false, NameContext.TypeExtends);
            builder.AppendLine($"\n[Newtonsoft.Json.JsonIgnore]\n{StringTools.TwoTabs}System.Type IMethod.Type {{ get; init; }} = typeof({type});");
            builder.AppendLine($"\n[Newtonsoft.Json.JsonIgnore]\n{StringTools.TwoTabs}bool IMethod.IsVector {{ get; init; }} = {ReturnsVector.ToString().ToLower()};");
            base.WriteParameters(builder);
        }

        public void WriteMethod(StringBuilder builder)
        {
            var args = new StringBuilder();
            var returnType = Type.GetTypeName(NamingType.FullNamespace, null, false, NameContext.TypeExtends);
            if (ReturnsVector)
            {
                returnType = $"CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<{returnType}>";
            }

            var parametersOrdered = Parameters.Where(x => x.Type is not FlagType).Where(x => !x.HasFlag).Concat(Parameters.Where(x => x.HasFlag)).ToList();

            var nullPolicies = new StringBuilder();
            for (var index = 0; index < parametersOrdered.Count; index++)
            {
                var parameter = parametersOrdered[index];
                parameter.Type.WriteMethodParameter(args, parameter, true);
                if (index < parametersOrdered.Count - 1)
                {
                    args.Append(", ");
                }
            }

            var comma = args.Length == 0 ? "" : ",";
            builder.AppendLine($"public async Task<RpcMessage<{returnType}>> {NamingInfo.PascalCaseName}Async({args}{comma} CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)\n{StringTools.TwoTabs}{{");
            builder.AppendLine(nullPolicies.ToString());
            builder.AppendLine($"var rpcResponse = new RpcMessage<{returnType}>(");
            if (ReturnsVector)
            {
                builder.AppendLine($"new {returnType}()");
            }

            builder.AppendLine(");");

            builder.AppendLine($"messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: {(MethodCompletionType == MethodCompletionType.ReturnsUnencrypted ? "false" : "true")});");
            builder.AppendLine($"var methodBody = new {Namespace.FullNamespace}(){{");
            foreach (var parameter in parametersOrdered)
            {
                builder.AppendLine($"{parameter.NamingInfo.PascalCaseName} = {parameter.NamingInfo.CamelCaseName},");
            }

            builder.AppendLine("};");
            builder.AppendLine();
            builder.AppendLine($"_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);");
            builder.AppendLine("await taskCompletionSource!;");
            builder.AppendLine($"return rpcResponse;");
            builder.AppendLine("}");
        }
    }
}