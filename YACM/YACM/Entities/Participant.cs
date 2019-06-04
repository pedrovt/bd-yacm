using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YACM
{
    public class Participant : User
    {

		public int Dorsal { get; set; }
		public string TeamName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		
	}
}
