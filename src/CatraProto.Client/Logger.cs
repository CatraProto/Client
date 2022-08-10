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
using Serilog;
using Serilog.Core;
using Serilog.Expressions;
using Serilog.Templates;
using Serilog.Templates.Themes;

namespace CatraProto.Client
{
    public static class Logger
    {
        private static readonly string Template;

        static Logger()
        {
            var addContext = "[{Substring(SourceContext, LastIndexOf(SourceContext, '.') + 1)}]";
            var addConnection = "{#if Connection is not null} - {Connection}{#end}";
            var addFile = "{#if FileId is not null} - [FileId: {FileId}]{#end}";
            var addMessageItem = "{#if MessageItemTrackId is not null} - {MessageItemTrackId}{#end}";
            var addUpdateProcessor = "{#if UpdateProcessorId is not null} - [ChannelId: {UpdateProcessorId}]{#end}";

            Template = "({@t:HH:mm:ss} {@l:w4}) {Session} " + addContext + addFile + addConnection + addMessageItem + addUpdateProcessor + " =>" + " {@m} {@x}" + "\n";
        }

        public static ILogger CreateDefaultLogger(LoggingLevelSwitch? levelSwitch = null, TemplateTheme? theme = null)
        {
            theme ??= TemplateTheme.Code;
            levelSwitch ??= new LoggingLevelSwitch();
            return new LoggerConfiguration()
                .WriteTo
                .Console(GetExpressionTemplate(templateTheme: theme))
                .MinimumLevel
                .ControlledBy(levelSwitch)
                .CreateLogger();
        }

        public static ExpressionTemplate GetExpressionTemplate(IFormatProvider? formatProvider = null, NameResolver? nameResolver = null, TemplateTheme? templateTheme = null, bool applyThemeWhenOutputIsRedirected = false)
        {
            return new ExpressionTemplate(Template, formatProvider, nameResolver, templateTheme, applyThemeWhenOutputIsRedirected);
        }
    }
}