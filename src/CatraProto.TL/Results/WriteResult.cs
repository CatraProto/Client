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

namespace CatraProto.TL.Results
{
    public struct WriteResult
    {
        public bool IsError { get => _error is not null; }
        private readonly string? _error;
        private readonly ParserErrors? _parserError;

        public WriteResult(string? error = null, ParserErrors? parserError = null)
        {
            if (error is not null && parserError is null || error is null && parserError is not null)
            {
                throw new InvalidOperationException("Both error and parserError must either be null or not null");
            }

            _error = error;
            _parserError = parserError;
        }

        public (string Error, ParserErrors parserError) GetError()
        {
            if (!IsError)
            {
                throw new InvalidOperationException("Write operation did not result in an error");
            }

            return (_error!, _parserError!.Value);
        }
    }
}
