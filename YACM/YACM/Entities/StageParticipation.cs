using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

    public class StageParticipation
    {
      
		public int ParticipantID { get; set; }
		public int EventNumber { get; set; }
		public DateTime StageDate { get; set; }
		public string StageStartLocation { get; set; }
		public string StageEndLocation { get; set; }
		public string Result { get; set; }

	}
}

