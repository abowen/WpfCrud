using System;
using FluentValidation;
using MyBusiness.BookAd.Business.Entities;

namespace MyBusiness.BookAd.Business.Validation
{
    public class AdvertisementValidator : AbstractValidator<Advertisement>
    {
        public AdvertisementValidator()
        {
            RuleFor(entity => entity.ClientName).NotNull().WithMessage(ClientLengthErrorMessage);
            RuleFor(entity => entity.ClientName).Length(2, 100).WithMessage(ClientLengthErrorMessage);
            RuleFor(entity => entity.DurationSeconds).GreaterThan(0).WithMessage(DurationSecondsGreaterThanErrorMessage);
            RuleFor(entity => entity.BookingDateTimeUtc).GreaterThan(DateTime.UtcNow).WithMessage(BookingDateGreaterThanNowErrorMessage);
        }

        // These values could be read from a Resource file or Database to allow for globalization
        public static readonly string ClientLengthErrorMessage = "Client must be between 2 and 100 characters.";
        public static readonly string DurationSecondsGreaterThanErrorMessage = "Advertisement must go for at least one second.";
        public static readonly string BookingDateGreaterThanNowErrorMessage = "Booking Date cannot be in the past.";
    }
}
