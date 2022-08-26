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

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Settings;

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
        private readonly List<TLObject> _objects;
        private static Dictionary<string, int> s_knownContexts = new Dictionary<string, int>();

        private static readonly List<string> s_keepContext = new List<string>
        {
            "CatraProto.Client.TL.Schemas.CloudChats.Message",
            "CatraProto.Client.TL.Schemas.CloudChats.MessageService",
            "CatraProto.Client.TL.Schemas.CloudChats.ChatFull",
            "CatraProto.Client.TL.Schemas.CloudChats.ChannelFull",
            "CatraProto.Client.TL.Schemas.CloudChats.UserFull",
            "CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdate",
            "CatraProto.Client.TL.Schemas.CloudChats.WebPage",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSet",
            "CatraProto.Client.TL.Schemas.CloudChats.WallPaper",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifs",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickers",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickers",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickers",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultArchive",
            "CatraProto.Client.TL.Schemas.CloudChats.Game",
            "CatraProto.Client.TL.Schemas.CloudChats.Theme",
            "CatraProto.Client.TL.Schemas.CloudChats.AvailableReaction",
            "CatraProto.Client.TL.Schemas.AttachMenuBots",
            "CatraProto.Client.TL.Schemas.AttachMenuBotsBot",
            "CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtones",
            "CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtoneConverted",
            "CatraProto.Client.TL.Schemas.CloudChats.Help.PremiumPromo",
            "CatraProto.Client.TL.Schemas.CloudChats.UpdateServiceNotification",
            "CatraProto.Client.TL.Schemas.CloudChats.UpdateShortSentMessage",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResults",
            
            // methods
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.UpdateProfilePhoto",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.UploadProfilePhoto",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckChatInvite",
            "CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminLog",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickers",
            "CatraProto.Client.TL.Schemas.CloudChats.Help.GetRecentMeUrls",
            "CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSponsoredMessages",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.GetUserPhotos",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchStickerSets"
        };

        public UpdateExtractorsWriter(List<TLObject> objects)
        {
            _objects = objects;
        }

        public async Task WriteAsync()
        {
            var template = await File.ReadAllTextAsync(Configuration.UpdateToolsTemplatePath);
            var replaced = template
                .Replace("^PtsConditions^", GetPtsConditions())
                .Replace("^QtsConditions^", GetQtsConditions())
                .Replace("^PeerConditions^", GetPeerConditions())
                .Replace("^VectorChatsConditions^", GetChatsConditions())
                .Replace("^FileConditions^", await GetDocumentsWalker());
            Directory.CreateDirectory(Configuration.UpdatesToolsWritePath[0..^1]);
            await File.WriteAllTextAsync(Configuration.UpdatesToolsWritePath, replaced);
        }

        // Recursively finds every path to every namespace defined in the namespaces List
        private async Task FindAndGenWhereContext(List<string> namespaces, List<string> alreadyHandled, StringBuilder builder, bool first = false)
        {
            var objects = _objects.Where(x => x.Parameters.FirstOrDefault(x => x.Type.Namespace is not null && namespaces.Contains(x.Type.Namespace.FullNamespace)) is not null);
            var alsoSearch = new List<string>();
            foreach (var obj in objects)
            {
                if (!s_knownContexts.TryGetValue(obj.Namespace.FullNamespace, out var hash) || hash != obj.Id)
                {
                    Console.WriteLine($"NEW CONTEXT OR HASH CHANGED! {obj.Namespace.FullNamespace}");
                    Console.WriteLine(obj.TLDeclaration);
                    Console.WriteLine("Do you want to add this context to the list of known contexts?");
                    var ans = Console.ReadLine();
                    if (ans.Length > 0 && ans.ToLower()[0] == 'y')
                    {
                        Console.WriteLine("Added!");
                        s_knownContexts[obj.Namespace.FullNamespace] = obj.Id;
                    }
                }

                foreach(var method in _objects.Where(x => x is Method && x.Type.Namespace is not null && x.Type.Namespace == obj.Namespace))
                {
                    if (!s_knownContexts.TryGetValue(method.Namespace.FullNamespace, out hash) || hash != method.Id)
                    {
                        Console.WriteLine($"NEW METHOD RETURN CONTEXT! {method.Namespace.FullNamespace}");
                        Console.WriteLine(method.TLDeclaration);
                        Console.WriteLine("Do you want to add this context to the list of known contexts?");
                        var ans = Console.ReadLine();
                        if (ans.Length > 0 && ans.ToLower()[0] == 'y')
                        {
                            Console.WriteLine("Added!");
                            s_knownContexts[method.Namespace.FullNamespace] = method.Id;
                        }
                    }
                }

                await File.WriteAllTextAsync("knownContexts.json", JsonSerializer.Serialize(s_knownContexts, typeof(Dictionary<string, int>)));
                alsoSearch.Add(obj.Type.Namespace.FullNamespace);
                var getFixedName = obj.Namespace.FullNamespace.Replace(".", "");
                getFixedName = getFixedName[0].ToString().ToLower() + getFixedName[1..];
                var wroteAlready = false;
                var find = obj.Parameters
                    .Where(x => x.Type.Namespace is not null && namespaces.Contains(x.Type.Namespace.FullNamespace))
                    .ToList();
                var i = 0;
                foreach (var param in find)
                {
                    if (alreadyHandled.Contains(obj.Namespace.FullNamespace))
                    {
                        continue;
                    }

                    if (!wroteAlready)
                    {
                        builder.AppendLine($"case {obj.Namespace.FullNamespace} {getFixedName}:");
                        wroteAlready = true;
                    }

                    alreadyHandled.Add(obj.Namespace.FullNamespace);
                    if (param.HasFlag)
                    {
                        builder.AppendLine($"if ({getFixedName}.{param.NamingInfo.PascalCaseName} is null){{");
                        builder.AppendLine("break;");
                        builder.AppendLine("}");
                    }

                    var propName = getFixedName + "." + param.NamingInfo.PascalCaseName;
                    var treeName = "tree";
                    if (param.VectorInfo.IsVector)
                    {
                        builder.AppendLine($"foreach (var item in {getFixedName}.{param.NamingInfo.PascalCaseName}){{");
                        builder.AppendLine($"var newTree = new List<IObject>(tree);");
                        propName = "item";
                        treeName = "newTree";
                    }
                    else if (find.Count > 1)
                    {
                        treeName = propName.Split('.')[0] + "Tree" + i;
                        builder.AppendLine($"var {treeName} = new List<IObject>(tree);");
                    }

                    builder.AppendLine($"{treeName}.Add({propName});");
                    if (s_keepContext.Contains(obj.Namespace.FullNamespace))
                    {
                        builder.AppendLine($"OnFileReceived({propName}, {getFixedName}, true, {treeName});");
                    }
                    else
                    {
                        builder.AppendLine($"OnFileReceived({propName}, preserveContext ? context : {getFixedName}, preserveContext, {treeName});");
                    }

                    if (param.VectorInfo.IsVector)
                    {
                        builder.AppendLine("}");
                    }
                    i++;
                }

                if (wroteAlready)
                {
                    builder.AppendLine("break;");
                }
            }

            if (alsoSearch.Count > 0)
            {
                await FindAndGenWhereContext(alsoSearch, alreadyHandled, builder);
            }
        }

        private async Task<string> GetDocumentsWalker()
        {
            var strinbBud = new StringBuilder();
            s_knownContexts = (Dictionary<string, int>)JsonSerializer.Deserialize(await File.ReadAllTextAsync("knownContexts.json"), typeof(Dictionary<string, int>));
            await FindAndGenWhereContext(new List<string> { "CatraProto.Client.TL.Schemas.CloudChats.Document", "CatraProto.Client.TL.Schemas.CloudChats.Photo" }, new List<string>(), strinbBud, true);

            strinbBud.AppendLine("case CatraProto.Client.TL.Schemas.CloudChats.Photo:");
            strinbBud.AppendLine("case CatraProto.Client.TL.Schemas.CloudChats.Document:");
            strinbBud.AppendLine("callback(socketObject, context, tree);");
            strinbBud.AppendLine("break;");
            return strinbBud.ToString();
        }

        private string GetChatsConditions()
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in _objects.Where(x => x.Type.Namespace is not null && x is not Method))
            {
                Parameter chats = obj.Parameters.Find(x => x.Type.Namespace is not null && x.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.Chat");
                Parameter users = obj.Parameters.Find(x => x.Type.Namespace is not null && x.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.User");
                if (chats is null && users is null)
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

        private void RecursiveFindPeer(TLObject obj, StringBuilder stringBuilder)
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

        private void WriteParameterPeer(TLObject obj, MatchType matchType, Parameter parameter, StringBuilder stringBuilder)
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

        private (Parameter, MatchType)? FindPeer(TLObject obj)
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