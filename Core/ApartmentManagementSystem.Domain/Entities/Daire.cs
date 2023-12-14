using ApartmentManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Domain.Entities
{
    public class Daire : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        DateTime IModifiedOn.ModifiedOn { get; set; }
        DateTime IDeletedOn.DeletedOn { get; set; }
        public int floorNo { get; set; }

        public string daireNo { get; set; }
        public AppUser user { get; set; }

        public List<Subscription> subscriptions { get; set; }




    }
}
