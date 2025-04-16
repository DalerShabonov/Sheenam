using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests.Exceptions;
using System;
using System.Threading.Tasks;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            //this.loggingBroker.LogError(new Exception("something"));

            //if (guest is null)
            //{
            //    throw new GuestValidationException(new NullGuestException());
            //}
            return await this.storageBroker.InsertGuestAsync(guest);    
        }
    }
}
