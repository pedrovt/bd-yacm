using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

	[Serializable()]
	public class Event
	{
		private int _number;
		private String _name;
		private DateTime _beginningDate;
		private DateTime _endDate;
		private bool _visibility;
		private int _managerID;
		private List<int> enrollment = new List<int>();
		private List<int> dropout = new List<int>();

		public int Number {
			get { return _number; }
			set { _number = value; }
		}


		public String Name {
			get { return _name; }
			set {
				if (value == null | String.IsNullOrEmpty(value)) {
					throw new Exception("Event Name field can’t be empty");
					//return;
				}
				_name = value;
			}
		}

		public DateTime BeginningDate {
			get { return _beginningDate; }
			set { _beginningDate = value; }
		}

		public DateTime EndDate {
			get { return _endDate; }
			set { _endDate = value; }
		}

		public bool Visibility {
			get { return _visibility; }
			set { _visibility = value; }
		}

		public int ManagerID {
			get { return _managerID; }
			set { _managerID = value; }
		}

		public List<int> Enrollment { get; set; }

		public List<int> Dropout { get; set; }


		public override String ToString() {
			return "Event " + _number + "   " + _name;
		}

		public Event() : base() {
		}

		public Event(int number, String name, DateTime beginningDate, DateTime endDate, bool visilibty, int managerID) : base() {
			Number = number;
			Name = name;
			BeginningDate = beginningDate;
			EndDate = endDate;
			Visibility = visilibty;
			ManagerID = managerID;
		}

		public Event(int number, String name, DateTime beginningDate, DateTime endDate, bool visilibty, int managerID, List<int> enrollment) : this(number, name, beginningDate, endDate, visilibty, managerID) {
			Enrollment = enrollment;
		}
	}
}

