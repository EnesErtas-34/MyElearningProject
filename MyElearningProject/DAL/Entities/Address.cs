using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
	public class Address
	{
		public int AddressID { get; set; }
		public string AddressOfice { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}