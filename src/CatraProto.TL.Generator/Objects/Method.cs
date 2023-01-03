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
using CatraProto.TL.Generator.CodeGeneration;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Objects.Types;

namespace CatraProto.TL.Generator.Objects
{
    class Method : TLObject
    {
        public static readonly List<string> HiddenMethods = new List<string>()
        {
            // Overridden for general better usage
            "help.getConfig",
            "users.getUsers",
            "users.getFullUser",
            "messages.getChats",
            "messages.getFullChat",
            "channels.getChannels",
            "channels.getFullChannel",

            // Hidden because of better library APIs
            "messages.uploadMedia",
            "auth.signIn",
            "auth.signUp",
            "auth.resendCode",
            "auth.sendCode",
            "auth.checkPassword",
            "auth.logOut",
            "auth.importBotAuthorization",

            // Hidden because of internal usage
            "auth.bindTempAuthkey",

            // Overridden for better file support
            "messages.editInlineBotMessage",
            "messages.editMessage",
            "messages.sendMedia",
            "messages.sendMultiMedia",
            "messages.uploadImportedMedia",
            "payments.exportInvoice",
            "payments.requestRecurringPayment"
        };

        public bool ReturnsVector { get; set; }
        public MethodCompletionType MethodCompletionType { get; }
        public bool IsOptimized { get; set; }
        public bool IsHidden { get; set; }

        public Method(MethodCompletionType methodCompletionType)
        {
            MethodCompletionType = methodCompletionType;
        }

        public override void WriteParameters(StringBuilder builder)
        {
            var type = Type.GetTypeName(NamingType.FullNamespace, null, false, false, NameContext.TypeExtends);
            builder.AppendLine(
                $"\n[Newtonsoft.Json.JsonIgnore]\n{StringTools.TwoTabs}ParserTypes IMethod.Type {{ get; init; }} = ParserTypes.{Tools.GetEnumValue(Type)};");
            base.WriteParameters(builder);
        }

        public void WriteMethod(StringBuilder builder, bool writeSimplified)
        {
            var args = new StringBuilder();
            var returnType = Type.GetTypeName(NamingType.FullNamespace, null, false, false, NameContext.TypeExtends);
            if (ReturnsVector)
            {
                returnType = $"CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<{returnType}>";
            }

            var parametersOrdered = Parameters.Where(x => x.Type is not FlagType).Where(x => !x.HasFlag)
                .Concat(Parameters.Where(x => x.HasFlag)).ToList();

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
            var isInternal = HiddenMethods.Contains(NamingInfo.OriginalNamespacedName) || IsHidden;
            var acc = isInternal ? "internal" : "public";
            var name = isInternal ? "Internal" + NamingInfo.PascalCaseName : NamingInfo.PascalCaseName;
            builder.AppendLine(
                $"{acc} async Task<RpcResponse<{returnType}>> {name}Async({args}{comma} CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)\n{StringTools.TwoTabs}{{");
            builder.AppendLine(nullPolicies.ToString());
            foreach (var parameter in parametersOrdered)
            {
                parameter.Type.WriteMethodBeforeCall(builder, parameter, returnType);
            }

            builder.AppendLine($"var rpcResponse = new RpcResponse<{returnType}>(");
            if (ReturnsVector)
            {
                builder.AppendLine($"new {returnType}()");
            }

            builder.AppendLine(");");
            builder.AppendLine(
                $"messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();");
            builder.AppendLine(
                $"messageSendingOptions.IsEncrypted = {(MethodCompletionType == MethodCompletionType.ReturnsUnencrypted ? "false" : "true")};");

            builder.AppendLine($"var methodBody = new {Namespace.FullNamespace}(){{");
            foreach (var parameter in parametersOrdered)
            {
                builder.AppendLine(
                    $"{parameter.NamingInfo.PascalCaseName} = {parameter.Type.GetFinalParameterName(parameter).CamelCaseName},");
            }

            builder.AppendLine("};");
            builder.AppendLine();
            builder.AppendLine(
                $"_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);");
            builder.AppendLine("await taskCompletionSource!;");
            builder.AppendLine($"return rpcResponse;");
            builder.AppendLine("}");
        }
    }
}