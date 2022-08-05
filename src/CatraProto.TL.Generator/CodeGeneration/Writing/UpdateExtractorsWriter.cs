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
        private static readonly List<string> s_knownContexts = new List<string>
        {
            "CatraProto.Client.TL.Schemas.CloudChats.ChannelFull",
            "CatraProto.Client.TL.Schemas.CloudChats.MessageMediaPhoto",
            "CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatEditPhoto",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.ApiPhotos",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosSlice",
            "CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangePhoto",
            "CatraProto.Client.TL.Schemas.CloudChats.MessageMediaDocument",
            "CatraProto.Client.TL.Schemas.CloudChats.BotInlineMediaResult",
            "CatraProto.Client.TL.Schemas.CloudChats.StickerSetMultiCovered",
            "CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeTheme",
            "CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtoneConverted",
            "CatraProto.Client.TL.Schemas.CloudChats.WallPaper",
            "CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdate",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.Stickers",
            "CatraProto.Client.TL.Schemas.CloudChats.WebPage",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSet",
            "CatraProto.Client.TL.Schemas.CloudChats.BotInfo",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifs",
            "CatraProto.Client.TL.Schemas.CloudChats.BotInlineResult",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickers",
            "CatraProto.Client.TL.Schemas.CloudChats.StickerSetCovered",
            "CatraProto.Client.TL.Schemas.CloudChats.StickerSetCovered",
            "CatraProto.Client.TL.Schemas.CloudChats.Game",
            "CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickers",
            "CatraProto.Client.TL.Schemas.CloudChats.Page",
            "CatraProto.Client.TL.Schemas.CloudChats.Theme",
            "CatraProto.Client.TL.Schemas.CloudChats.WebPageAttribute",
            "CatraProto.Client.TL.Schemas.CloudChats.AvailableReaction",
            "CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIcon",
            "CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtones",
            "CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtone",
            "CatraProto.Client.TL.Schemas.CloudChats.Help.PremiumPromo",
            "CatraProto.Client.TL.Schemas.CloudChats.ChatFull",
            "CatraProto.Client.TL.Schemas.CloudChats.ChatFull",
            "CatraProto.Client.TL.Schemas.CloudChats.MessageMedia",
            "CatraProto.Client.TL.Schemas.CloudChats.MessageAction",
            "CatraProto.Client.TL.Schemas.CloudChats.UserFull",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.Photos",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.Photos",
            "CatraProto.Client.TL.Schemas.CloudChats.Photos.Photo",
            "CatraProto.Client.TL.Schemas.CloudChats.WebPage",
            "CatraProto.Client.TL.Schemas.CloudChats.ChatInvite",
            "CatraProto.Client.TL.Schemas.CloudChats.BotInfo",
            "CatraProto.Client.TL.Schemas.CloudChats.BotInlineResult",
            "CatraProto.Client.TL.Schemas.CloudChats.Game",
            "CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventAction",
            "CatraProto.Client.TL.Schemas.CloudChats.Page",
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
                .Replace("^FileConditions^", GetDocumentsWalker());
            Directory.CreateDirectory(Configuration.UpdatesToolsWritePath[0..^1]);
            await File.WriteAllTextAsync(Configuration.UpdatesToolsWritePath, replaced);
        }

        // Recursively finds every path to every namespace defined in the namespaces List
        private void FindAndGenWhereContext(List<string> namespaces, List<string> alreadyHandled, StringBuilder builder, bool first = false)
        {
            var objects = _objects.Where(x => x.Parameters.FirstOrDefault(x => x.Type.Namespace is not null && namespaces.Contains(x.Type.Namespace.FullNamespace)) is not null);
            var alsoSearch = new List<string>();
            foreach (var obj in objects)
            {
                if (first && !s_knownContexts.Contains(obj.Namespace.FullNamespace))
                {
                    Console.WriteLine($"NEW CONTEXT! {obj.Namespace.FullNamespace}");
                }

                alsoSearch.Add(obj.Type.Namespace.FullNamespace);
                var getFixedName = obj.Type.Namespace.FullNamespace.Replace(".", "");
                getFixedName = getFixedName[0].ToString().ToLower() + getFixedName[1..];
                var wroteAlready = false;
                foreach(var param in obj.Parameters.Where(x => x.Type.Namespace is not null && namespaces.Contains(x.Type.Namespace.FullNamespace)))
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
                    if (param.VectorInfo.IsVector)
                    {
                        builder.AppendLine($"foreach (var item in {getFixedName}.{param.NamingInfo.PascalCaseName}){{");
                        propName = "item";
                    }

                    if (obj.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.Message")
                    {
                        builder.AppendLine($"OnFileReceived({propName}, {getFixedName}, true);");
                    }
                    else
                    {
                        builder.AppendLine($"OnFileReceived({propName}, preserveContext ? context : {getFixedName}, preserveContext);");
                    }

                    if (param.VectorInfo.IsVector)
                    {
                        builder.AppendLine("}");
                    }
                }

                if (wroteAlready)
                {
                    builder.AppendLine("break;");
                }
            }

            if (alsoSearch.Count > 0)
            {
                FindAndGenWhereContext(alsoSearch, alreadyHandled, builder);
            }
        }

        private string GetDocumentsWalker()
        {
            var strinbBud = new StringBuilder();
            FindAndGenWhereContext(new List<string> { "CatraProto.Client.TL.Schemas.CloudChats.Document", "CatraProto.Client.TL.Schemas.CloudChats.Photo" }, new List<string>(), strinbBud, true);

            strinbBud.AppendLine("case CatraProto.Client.TL.Schemas.CloudChats.Photo:");
            strinbBud.AppendLine("case CatraProto.Client.TL.Schemas.CloudChats.Document:");
            strinbBud.AppendLine("CatraProto.Client.ApiManagers.Files.FileLocation.UpdateId(socketObject, context);");
            strinbBud.AppendLine("break;");
            /*
            var stringBuilder = new StringBuilder();
            var whereDocuments = _objects
                .Where(x => x is Constructor && x.Parameters.FirstOrDefault(x => x.Type.Namespace is not null && (x.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.Document" || x.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.CloudChats.Photo")) is not null)
                .ToList();
            foreach (var docConObject in whereDocuments)
            {
                if (!s_knownContexts.Contains(docConObject.Namespace.FullNamespace))
                {
                    System.Console.WriteLine($"NEW CONTEXT! {docConObject.Namespace.FullNamespace}");
                }

                foreach (var item in docConObject.Parameters)
                {
                    System.Console.WriteLine($"Is in parameter {item.NamingInfo.OriginalName}");
                }
            }

            var reverseFind = whereDocuments;
            while (true)
            {
                foreach (var item in reverseFind)
                {
                    item.Type.ReferencedParameters.ForEach(x => System.Console.WriteLine(x.NamingInfo.OriginalName));
                }
                
                break;
            }*/
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