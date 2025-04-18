using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class AlreadyExistsGuestException : Xeption
    {
        public AlreadyExistsGuestException(Exception innerException)
            : base(message: "Guest already exists",
                  innerException)

        { }
    }
}
