﻿namespace Ocelot.Middleware
{
    using Errors;

    public class UnauthenticatedError : Error
    {
        public UnauthenticatedError(string message)
            : base(message, OcelotErrorCode.UnauthenticatedError, 401)
        {
        }
    }
}
