using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
	public class AboutFeature
	{
		public int AboutFeatureID { get; set; }
		public string icon { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}