using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

	[Serializable()]
	public class Equipment
	{
		public int ID { get; set; }
		public int EventID { get; set; }
		public int ParticipantID { get; set; }
		public String Category { get; set; }
		public String Description { get; set; }

		public override String ToString() {
			return "Equipment " + ID;
		}

		public Equipment() : base() {
		}

		public Equipment(int id, int eventID, int participantID, String category, String description) : base() {
			ID = id;
			EventID = eventID;
			ParticipantID = participantID;
			Category = category;
			Description = description;
		}
	}
}

