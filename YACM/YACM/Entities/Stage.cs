using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

    [Serializable()]
    public class Stage
    {
        #region Attributes
        private DateTime _date;
        private String _startLocation;
        private String _endLocation;
        private int _eventID;
        private int _distance;
        #endregion

        #region Getters/Setters
        public DateTime Date { get; set; }
        public String StartLocation { get; set; }
        public String EndLocation { get; set; }
        public int EventID { get; set; }
        public int Distance { get; set; }
        #endregion

        #region ToString
        public override String ToString()
        {
            return "[Stage]\n" + StartLocation + " - " + EndLocation + "\n" + Date + "\n" + Distance + "Km\n";
        }
        #endregion

        #region Constructors
        public Stage() : base()
        {
        }

        public Stage(DateTime date, String startLocation, String endLocation, int distance) : base()
        {
            Date = date;
            StartLocation = startLocation;
            EndLocation = endLocation;
            Distance = distance;
        }
        #endregion

    }
}

