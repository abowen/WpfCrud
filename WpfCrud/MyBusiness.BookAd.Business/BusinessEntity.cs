using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MyBusiness.BookAd.Business
{
    [DataContract]
    public abstract class BusinessEntity
    {
        /// <summary>
        /// Validates the properties of the entity
        /// </summary>
        /// <returns>List of validation errors, or empty list if valid</returns>
        public abstract IEnumerable<string> GetValidationErrors();

        public bool IsValid
        {
            get
            {
                return !GetValidationErrors().Any();
            }
        }
    }
}
