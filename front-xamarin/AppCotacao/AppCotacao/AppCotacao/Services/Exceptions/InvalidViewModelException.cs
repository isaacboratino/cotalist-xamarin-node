using System;

namespace AppCotacao.Services.Exceptions
{
    public class InvalidViewModelException : Exception
    {
        public InvalidViewModelException(string message)
        : base(message) { }
    }
}
