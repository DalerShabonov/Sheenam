using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExeptionOnAddIfGuestIsNullAndLogItAsync()
        {
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();
                
            var expectedGuestvalidationException = 
                new GuestValidationException(nullGuestException);

            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);

            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());
        }
    }
}
