using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubFund.Models
{
	public class MemberListVM
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public byte[] Image { get; set; }
		public bool IsActive { get; set; }
	}
}
