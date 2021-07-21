using System;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;

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
            var type = Type.GetTypeName(NamingType.FullNamespace, null ,false, NameContext.TypeExtends);
            builder.AppendLine($"\n[JsonIgnore]\n{StringTools.TwoTabs}System.Type IMethod.Type {{ get; init; }} = typeof({type});");
            builder.AppendLine($"\n[JsonIgnore]\n{StringTools.TwoTabs}bool IMethod.IsVector {{ get; init; }} = {ReturnsVector.ToString().ToLower()};");
            base.WriteParameters(builder);
        }

        public void WriteMethod(StringBuilder builder)
        {
            var args = new StringBuilder();
            var returnType = Type.GetTypeName(NamingType.FullNamespace, new Parameter() { VectorInfo = new VectorInfo() { IsVector = ReturnsVector } }, true, NameContext.TypeExtends);


            var parametersOrdered = Parameters
                .Where(x => x.Type is not FlagType)
                .Where(x => !x.HasFlag)
                .Concat(Parameters.Where(x => x.HasFlag))
                .ToList();

            var nullPolicies = new StringBuilder();
            for (var index = 0; index < parametersOrdered.Count; index++)
            {
                var parameter = parametersOrdered[index];
                parameter.Type.WriteMethodParameter(args, parameter);
                parameter.Type.WriteNullPolicy(nullPolicies, parameter);
                if (index < parametersOrdered.Count - 1)
                {
                    args.Append(", ");
                }
            }

            var comma = args.Length == 0 ? "" : ",";
            builder.AppendLine(
                $"{StringTools.TwoTabs}public async Task<RpcMessage<{returnType}>> {NamingInfo.PascalCaseName}Async({args}{comma} CancellationToken cancellationToken = default)\n{StringTools.TwoTabs}{{");
            builder.AppendLine($"{StringTools.ThreeTabs}{nullPolicies}");
            builder.AppendLine($"{StringTools.ThreeTabs}var rpcResponse = new RpcMessage<{returnType}>();");
            builder.AppendLine($"{StringTools.ThreeTabs}var methodBody = new {Namespace.FullNamespace}()\n{StringTools.ThreeTabs}{{");
            foreach (var parameter in parametersOrdered)
            {
                builder.AppendLine($"{StringTools.FourTabs}{parameter.NamingInfo.PascalCaseName} = {parameter.NamingInfo.CamelCaseName},");
            }

            builder.AppendLine($"{StringTools.ThreeTabs}}};");
            builder.AppendLine();
            builder.AppendLine(
                $"{StringTools.ThreeTabs}await await _messagesHandler.EnqueueMessage(new OutgoingMessage\n{StringTools.FourTabs}{{\n{StringTools.FiveTabs}Body = methodBody,\n{StringTools.FiveTabs}CancellationToken = cancellationToken,\n{StringTools.FiveTabs}IsEncrypted = {(MethodCompletionType == MethodCompletionType.ReturnsUnencrypted ? "false" : "true")}\n{StringTools.FourTabs}}}, rpcResponse);");
            builder.AppendLine($"{StringTools.ThreeTabs}return rpcResponse;");
            builder.AppendLine($"{StringTools.TwoTabs}}}");
        }
    }
}