using System;

namespace Bambora.NA.SDK.Exceptions;

public class BamboraException : Exception
{
    public BamboraException()
    {
    }

    public BamboraException(string message)
        : base(message)
    {
    }

    public BamboraException(string message, Exception inner)
        : base(message, inner)
    {
    }
}