using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types.InternalTypes
{
    public class InputChannelOrUserAuto : TypeBase
    {
        private bool _isChannel;

        public InputChannelOrUserAuto(string type)
        {
            Namespace = new Namespace("long", false);
            NamingInfo = "long";
            TypeInfo.IsBare = true;
            TypeInfo.ForceNoBase = true;
            _isChannel = type == "InputChannel";
        }

        public override NamingInfo GetFinalParameterName(Parameter parameter)
        {
            return $"{parameter.NamingInfo.CamelCaseName}Resolved";
        }

        public override void WriteMethodBeforeCall(StringBuilder builder, Parameter parameter, string returnType)
        {
            string toResolveAccess;
            if (parameter.HasFlag)
            {
                toResolveAccess = parameter.VectorInfo.IsVector ? $"{parameter.NamingInfo.CamelCaseName}ToResolveOut" : $"{parameter.NamingInfo.CamelCaseName}.Value";
            }
            else
            {
                toResolveAccess = parameter.VectorInfo.IsVector ? $"{parameter.NamingInfo.CamelCaseName}ToResolveOut" : $"{parameter.NamingInfo.CamelCaseName}";
            }

            void WriteResolve(string toResolveName)
            {
                builder.AppendLine($"var {parameter.NamingInfo.CamelCaseName}ToResolve = _client.DatabaseManager.PeerDatabase.{GetResolver()}({toResolveName});");
                builder.AppendLine($"if({parameter.NamingInfo.CamelCaseName}ToResolve is null) {{");
                builder.AppendLine($"return RpcResponse<{returnType}>.FromError(new PeerNotFoundError({toResolveName}, CatraProto.Client.MTProto.PeerType.{GetPeerTypeError()}));");
                builder.AppendLine("}");
            }

            if (parameter.HasFlag)
            {
                builder.AppendLine(parameter.VectorInfo.IsVector ? $"var {parameter.NamingInfo.CamelCaseName}Resolved = new List<CatraProto.Client.TL.Schemas.CloudChats.{GetPeerType()}>();" : $"CatraProto.Client.TL.Schemas.CloudChats.{GetPeerType()}? {parameter.NamingInfo.CamelCaseName}Resolved = null;");
                builder.AppendLine($"if({parameter.NamingInfo.CamelCaseName} is not null){{");
            }
            else
            {
                if (parameter.VectorInfo.IsVector)
                {
                    builder.AppendLine($"var {parameter.NamingInfo.CamelCaseName}Resolved = new List<CatraProto.Client.TL.Schemas.CloudChats.{GetPeerType()}>();");
                }
            }

            if (parameter.VectorInfo.IsVector)
            {
                builder.AppendLine($"for (var i = 0; i < {parameter.NamingInfo.CamelCaseName}.Count; i++){{");
                builder.AppendLine($"var {parameter.NamingInfo.CamelCaseName}ToResolveOut = {parameter.NamingInfo.CamelCaseName}[i];");
                WriteResolve($"{parameter.NamingInfo.CamelCaseName}ToResolveOut");
                builder.AppendLine($"{parameter.NamingInfo.CamelCaseName}Resolved.Add({parameter.NamingInfo.CamelCaseName}ToResolve);");
                builder.AppendLine("}");
            }
            else
            {
                WriteResolve(toResolveAccess);
                if (!parameter.HasFlag)
                {
                    builder.Append("var ");
                }

                builder.AppendLine($"{parameter.NamingInfo.CamelCaseName}Resolved = {parameter.NamingInfo.CamelCaseName}ToResolve;");
            }

            if (parameter.HasFlag)
            {
                builder.AppendLine("}");
            }
        }

        private string GetResolver()
        {
            return _isChannel ? "ResolveChannel" : "ResolveUser";
        }

        private string GetPeerType()
        {
            return _isChannel ? "InputChannelBase" : "InputUserBase";
        }

        private string GetPeerTypeError()
        {
            return _isChannel ? "Channel" : "User";
        }

        public override void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false)
        {
            throw new System.NotImplementedException();
        }
    }
}