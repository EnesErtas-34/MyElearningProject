using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
	public class Instructor
	{
		public int InstructorID { get; set; }
		public string Name { get; set; }

		[StringLength(30)]
		public string Surname { get; set; }
		public string ImageUrl { get; set; }
	}
}