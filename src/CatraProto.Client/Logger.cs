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

using Serilog;
using Serilog.Core;
using Serilog.Templates;

namespace CatraProto.Client
{
    public static class Logger
    {
        public static ILogger CreateDefaultLogger(LoggingLevelSwitch? levelSwitch = null)
        {
            var addContext = "[{Substring(SourceContext, LastIndexOf(SourceContext, '.') + 1)}]";
            var addConnection = "{#if Connection is not null}[{Connection}]{#end}";
            var aa = new ExpressionTemplate(
                "[{@t:HH:mm:ss} {@l:u3}][{Session}]"
                + addContext
                + addConnection
                + " {@m}\n{@x}",

                theme: Serilog.Templates.Themes.TemplateTheme.Literate
            );
            levelSwitch ??= new LoggingLevelSwitch();
            return new LoggerConfiguration().WriteTo
                .Console(aa).MinimumLevel
                .ControlledBy(levelSwitch).CreateLogger();
        }
    }
}