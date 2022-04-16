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
