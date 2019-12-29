using System;
using System.Runtime.Serialization;

namespace CounoGame.Shared.Mvvm.DataTemplates
{
    internal sealed class MultipleViewDefinitionException : Exception
    {
        public MultipleViewDefinitionException(string message) : base(message)
        {
        }

        public MultipleViewDefinitionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}