using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blob.Core.Domain.Users
{
    public class Address : BaseEntity, ICloneable
    {

        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Company { get; set; }
        
        public int? CountryId { get; set; }
        
        public int? StateId { get; set; }
        
        public string City { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string FaxNumber { get; set; }
        
        public DateTime CreatedOnUtc { get; set; }
        
        public virtual Country Country { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            var addr = new Address()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Company = this.Company,
                Country = this.Country,
                CountryId = this.CountryId,
                StateId = this.StateId,
                City = this.City,            
                PhoneNumber = this.PhoneNumber,
                FaxNumber = this.FaxNumber,
                CreatedOnUtc = this.CreatedOnUtc,
            };
            return addr;
        }

        #endregion
    }
}
