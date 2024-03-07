using System;
using System.Collections.Generic;

#nullable disable

namespace ClubFund.Data
{
    public partial class Member
    {
        public Member()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Image { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
