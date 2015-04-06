using System;

namespace Shrew.Web.Models.Exceptions
{
    public class SuggestionException : ApplicationException
    {
        public SuggestionException(string message)
            : base(message)
        {

        }
    }
}