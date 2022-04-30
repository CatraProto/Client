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
    public struct ReadResult<T>
    {
        public bool IsError { get => _error is not null; }
        public T Value { get => GetValue(); }
        private string? _error;
        private ParserErrors? _parserError;
        private T? _parsedObject;

        public ReadResult(T obj)
        {
            _parsedObject = obj;
            _error = null;
            _parserError = null;
        }

        public ReadResult(string error, ParserErrors parserError)
        {
            _parsedObject = default;
            _error = error;
            _parserError = parserError;
        }

        internal static ReadResult<T> GetFakeResult()
        {
            var obj = new ReadResult<T>
            {
                _parsedObject = default,
                _error = null,
                _parserError = null,
            };
            return obj;
        }

        private T GetValue()
        {
            if (IsError)
            {
                throw new InvalidOperationException($"Cannot get parsed object because error \"{_error}\":{_parserError} occurred while parsing");
            }

            return _parsedObject!;
        }


        public (string Error, ParserErrors ParserError) GetError()
        {
            if (!IsError && !_parserError.HasValue)
            {
                throw new InvalidOperationException($"Cannot get error because the object was parsed successfully or this is a dummy result object");
            }

            return (_error!, _parserError!.Value);
        }

        public static ReadResult<T> Move<TO>(ReadResult<TO> other)
        {
            if (!other.IsError && other._parsedObject is null)
            {
                return ReadResult<T>.GetFakeResult();
            }

            if (other.IsError)
            {
                return new ReadResult<T>(other._error!, other._parserError!.Value);
            }
            else
            {
                if (other.Value is not T newValue)
                {
                    return new ReadResult<T>($"Expected type {typeof(T)} but {other.Value!.GetType()} was deserialized", ParserErrors.InvalidType);
                }

                return new ReadResult<T>(newValue);
            }

        }
    }
}
