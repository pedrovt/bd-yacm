using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

    [Serializable()]
    public class Prize
    {
        #region Attributes
        private int _id;
        private int _sponsorID;
        private int _eventNumber;
        private int _receiverID;
        private double _value;
        #endregion

        #region Getters/Setters
        public int ID { get; set; }
        public int SponsorID { get; set; }
        public int EventNumber { get; set; }
        public int ReceiverID { get; set; }
        public double Value { get; set; }
        #endregion

        #region ToString
        public override String ToString()
        {
            return "[Prize] "+ID+"\nSponsor ID: "+SponsorID+"\nReceiver ID: "+ReceiverID+"\nValue: "+Value+"\n";
        }
        #endregion

        #region Constructors
        public Prize() : base()
        {
        }
        public Prize(int id, int sponsorID, int eventID, int receiverID, double value) : base()
        {
            ID          = id;
            SponsorID   = sponsorID;
            EventNumber = eventID;
            ReceiverID  = receiverID;
            Value       = value;
            Description = "TBA";
        }
        #endregion

    }
}

