using System;
using System.Collections.Generic;

#nullable disable

namespace ClubFund.Data
{
    public partial class Payment
    {
        public int Id { get; set; }
        public bool? IsIncoming { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public string Description { get; set; }
        public int? MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
