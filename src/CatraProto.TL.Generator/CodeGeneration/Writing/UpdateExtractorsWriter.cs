using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Settings;
using Microsoft.VisualBasic;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
    enum MatchType
    {
        User,
        Peer,
        Channel,
        Chat
    }

    class UpdateExtractorsWriter
    {
        private readonly List<Object> _objects;

        public UpdateExtractorsWriter(List<Object> objects)
        {
            _objects = objects;
        }

        public async Task WriteAsync()
        {
            var template = await File.ReadAllTextAsync(Configuration.UpdateToolsTemplatePath);
            var replaced = template.Replace("^PtsConditions^", GetPtsConditions()).Replace("^QtsConditions^", GetQtsConditions()).Replace("^PeerConditions^", GetPeerConditions()).Replace("^VectorChatsConditions^", GetChatsConditions());
            Directory.CreateDirectory(Configuration.UpdatesToolsWritePath[0..^1]);
            await File.WriteAllTextAsync(Configuration.UpdatesToolsWritePath, replaced);
        }

        private string GetChatsConditions()
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in _objects.Where(x => x.Type.Namespace is not null && x is not Method))
            {
                Parameter chats = obj.Parameters.Find(x => x.Type.Namespace is not null && x.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.Chat");
                Parameter users = obj.Parameters.Find(x => x.Type.Namespace is not null && x.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.User");
                if(chats is null && users is null)
                {
                    continue;
                }


                stringBuilder.Append("case ");
                stringBuilder.Append(obj.Namespace.FullNamespace);
                stringBuilder.Append(' ');
                stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                stringBuilder.Append(":\n");
                void WriteParameter(string varName, string typeName, Parameter parameter)
                {
                    if (parameter is not null)
                    {
                        stringBuilder.Append($"{varName} = ");
                        if (parameter.VectorInfo.IsVector)
                        {
                            stringBuilder.AppendLine(obj.NamingInfo.CamelCaseName + "." + parameter.NamingInfo.PascalCaseName + ";");
                        }
                        else
                        {
                            stringBuilder.AppendLine($"new System.Collections.Generic.List<{typeName}>(1){{ " + obj.NamingInfo.CamelCaseName + "." + parameter.NamingInfo.PascalCaseName + "};");
                        }
                    }
                }

                WriteParameter("chatsVector", "CatraProto.Client.TL.Schemas.CloudChats.ChatBase", chats);
                WriteParameter("usersVector", "CatraProto.Client.TL.Schemas.CloudChats.UserBase", users);

                stringBuilder.AppendLine("break;");
            }

            return stringBuilder.ToString();
        }

        private string GetQtsConditions()
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in _objects.Where(x => x.Type.Namespace is not null && x.Type.Namespace.Class == "Update" && x.Parameters.Exists(objParam => objParam.NamingInfo.OriginalName == "qts")))
            {
                stringBuilder.Append("case ");
                stringBuilder.Append(obj.Namespace.FullNamespace);
                stringBuilder.Append(' ');
                stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                stringBuilder.Append(":\n");
                stringBuilder.Append("qts = ");
                stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                stringBuilder.AppendLine(".Qts;");
                stringBuilder.AppendLine("return true;");
            }

            return stringBuilder.ToString();
        }

        private string GetPtsConditions()
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in _objects.Where(x => x.Type.Namespace is not null && x.Type.Namespace.Class == "Update" && x.Parameters.Exists(objParam => objParam.NamingInfo.OriginalName == "pts")))
            {
                stringBuilder.Append("case ");
                stringBuilder.Append(obj.Namespace.FullNamespace);
                stringBuilder.Append(' ');
                stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                stringBuilder.Append(":\n");
                stringBuilder.Append("pts = ");
                stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                stringBuilder.AppendLine(".Pts;");
                if (obj.Parameters.Exists(objParam => objParam.NamingInfo.OriginalName == "pts_count"))
                {
                    stringBuilder.Append("ptsCount = ");
                    stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                    stringBuilder.AppendLine(".PtsCount;");
                }
                else
                {
                    stringBuilder.Append("ptsCount = 0;");
                }

                stringBuilder.AppendLine("return true;");
            }

            return stringBuilder.ToString();
        }

        private string GetPeerConditions()
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in _objects.Where(x => x.Type.Namespace?.Class is "Update"))
            {
                RecursiveFindPeer(obj, stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private void RecursiveFindPeer(Object obj, StringBuilder stringBuilder)
        {
            var peer = FindPeer(obj);
            if (peer is not null)
            {
                WriteParameterPeer(obj, peer.Value.Item2, peer.Value.Item1, stringBuilder);
                return;
            }

            foreach (var parameter in obj.Parameters.Where(x => !x.VectorInfo.IsVector))
            {
                var innerBuilder = new StringBuilder();
                foreach (var referencedObject in parameter.Type.ReferencedObjects)
                {
                    var findPeer = FindPeer(referencedObject);
                    if (findPeer is not null)
                    {
                        WriteParameterPeer(referencedObject, findPeer.Value.Item2, findPeer.Value.Item1, innerBuilder);
                    }
                }

                if (innerBuilder.Length > 0)
                {
                    stringBuilder.AppendLine("case ");
                    stringBuilder.Append(obj.Namespace.FullNamespace);
                    stringBuilder.Append(' ');
                    stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                    stringBuilder.Append(':');
                    stringBuilder.AppendLine("switch(");
                    stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                    stringBuilder.Append('.');
                    stringBuilder.Append(parameter.NamingInfo.PascalCaseName);
                    stringBuilder.Append(")\n{");
                    stringBuilder.Append(innerBuilder);
                    stringBuilder.Append("}\nbreak;");
                }
            }
        }

        private void WriteParameterPeer(Object obj, MatchType matchType, Parameter parameter, StringBuilder stringBuilder)
        {
            stringBuilder.Append("case ");
            stringBuilder.Append(obj.Namespace.FullNamespace);
            stringBuilder.Append(' ');
            stringBuilder.Append(obj.NamingInfo.CamelCaseName);
            stringBuilder.Append(":\n");
            if (parameter.HasFlag)
            {
                stringBuilder.Append("if(");
                stringBuilder.Append(obj.NamingInfo.CamelCaseName);
                stringBuilder.Append('.');
                stringBuilder.Append(parameter.NamingInfo.PascalCaseName);
                stringBuilder.Append(" is null)\n{break;}");
            }

            switch (matchType)
            {
                case MatchType.Chat:
                    stringBuilder.Append("peerId = CatraProto.Client.MTProto.PeerId.AsGroup(");
                    break;
                case MatchType.Channel:
                    stringBuilder.Append("peerId = CatraProto.Client.MTProto.PeerId.AsChannel(");
                    break;
                case MatchType.User:
                    stringBuilder.Append("peerId = CatraProto.Client.MTProto.PeerId.AsUser(");
                    break;
                case MatchType.Peer:
                    stringBuilder.Append("peerId = CatraProto.Client.MTProto.PeerId.FromPeer(");
                    break;
            }

            stringBuilder.Append(obj.NamingInfo.CamelCaseName);
            stringBuilder.Append('.');
            stringBuilder.Append(parameter.NamingInfo.PascalCaseName);
            stringBuilder.Append(");");
            stringBuilder.AppendLine("return true;");
        }

        private (Parameter, MatchType)? FindPeer(Object obj)
        {
            
            var findUserId = obj.Parameters.Find(x => x.NamingInfo.OriginalName == "user_id" && x.Type.NamingInfo.OriginalName == "long");
            if (findUserId is not null)
            {
                return (findUserId, MatchType.User);
            }
            
            var findChatId = obj.Parameters.Find(x => x.NamingInfo.OriginalName == "chat_id" && x.Type.NamingInfo.OriginalName == "long");
            if (findChatId is not null)
            {
                return (findChatId, MatchType.Chat);
            }

            var findChannelId = obj.Parameters.Find(x => x.NamingInfo.OriginalName == "channel_id" && x.Type.NamingInfo.OriginalName == "long");
            if (findChannelId is not null)
            {
                return (findChannelId, MatchType.Channel);
            }

            var findPeer = obj.Parameters.Find(x => (x.NamingInfo.OriginalName == "peer" || x.NamingInfo.OriginalName == "peer_id") && x.Type.NamingInfo.OriginalName == "Peer");
            if (findPeer is not null)
            {
                return (findPeer, MatchType.Peer);
            }

            return null;
        }
    }
}