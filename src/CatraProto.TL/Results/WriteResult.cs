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
