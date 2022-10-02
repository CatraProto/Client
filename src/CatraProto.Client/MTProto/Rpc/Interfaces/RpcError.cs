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

namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    public abstract class RpcError
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public abstract string ErrorDescription { get; }
        protected int MinimumLength { get; }

        protected RpcError(string errorMessage, int errorCode, int minimumLength = 0)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            MinimumLength = minimumLength;
        }

        protected bool CheckPrerequisites(string error)
        {
            return error.Length >= MinimumLength;
        }

        internal virtual RpcError? ParseError(TL.Schemas.MTProto.RpcError error)
        {
            return null;
        }

        public override string ToString()
        {
            return $"[{ErrorCode}][{ErrorMessage}][{ErrorDescription}]";
        }
    }
}