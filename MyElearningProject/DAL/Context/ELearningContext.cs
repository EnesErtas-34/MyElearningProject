using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Context
{
	public class ELearningContext:DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}