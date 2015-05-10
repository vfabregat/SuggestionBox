using System;

namespace Shrew.Core.Exceptions
{
    public class SuggestionException : ApplicationException
    {
        public SuggestionException(string message)
            : base(message)
        {

        }
    }
}