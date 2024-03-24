using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
	public class DefaultFeature
	{
		public int DefaultFeatureID { get; set; }
		public string Title { get; set; }
		public string Title2 { get; set; }
		public string Description { get; set; }
		public string Description2 { get; set; }
		public string ImageURL { get; set; }
		public string ImageURL2 { get; set; }
	}
}