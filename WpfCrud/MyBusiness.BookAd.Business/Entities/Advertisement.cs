using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using MyBusiness.BookAd.Business.Validation;

namespace MyBusiness.BookAd.Business.Entities
{
    [DataContract]
    [DebuggerDisplay("Advertisement: {AdvertisementId} Date: {BookingDateTimeUtc} Client: {ClientName}")]
    public class Advertisement : BusinessEntity, IComparable
    {
        private AdvertisementValidator _validator;

        public Advertisement()
        {
            BookingDateTimeUtc = DateTime.UtcNow;
        }

        [DataMember]
        public int AdvertisementId { get; set; }

        [DataMember]
        public DateTime BookingDateTimeUtc { get; set; }

        [DataMember]
        public int DurationSeconds { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        public override IEnumerable<string> GetValidationErrors()
        {
            if (_validator == null)
            {
                _validator = new AdvertisementValidator();
            }
            var result = _validator.Validate(this);
            return result.Errors.Select(e => e.ErrorMessage).ToArray();
        }

        /// <summary>
        /// Advertisement is ordered by the BookingDateTimeUtc
        /// </summary>
        /// <param name="obj">Advertisement to compare against</param>
        /// <returns>1 if compared Advertisement is more recent. 0 if the same. -1 if older</returns>
        public int CompareTo(object obj)
        {
            var entity = (Advertisement)obj;
            if (entity.BookingDateTimeUtc < BookingDateTimeUtc)
            {
                return 1;
            }
            if (entity.BookingDateTimeUtc > BookingDateTimeUtc)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Outputs the details of Advertisement in a tabular format
        /// </summary>
        /// <returns>Tabled string format</returns>
        public override string ToString()
        {
            return string.Format("ID: {0,5} DT: {1,20} SEC: {2,4} CN: {3,30}",
                AdvertisementId,
                BookingDateTimeUtc,
                DurationSeconds,
                ClientName);
        }
    }
}
