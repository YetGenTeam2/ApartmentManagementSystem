using ApartmentManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Domain.Entities
{
    public class Subscription : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } // aidatın oluşturulma tarihi
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        DateTime IModifiedOn.ModifiedOn { get; set; }
        DateTime IDeletedOn.DeletedOn { get; set; }

        public decimal price { get; set; } 

        public bool isPaid { get ; set; }

        public DateTime paidTime { get; set; } // aidatın kullanıcı tarafından ödenme tarihi 

        public Daire daire { get; set; }


    }
}
