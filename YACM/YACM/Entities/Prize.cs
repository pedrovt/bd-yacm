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
        private String _description;
        #endregion

        #region Getters/Setters
        public int ID { get; set; }
        public int SponsorID { get; set; }
        public int EventNumber { get; set; }
        public int ReceiverID { get; set; }
        public String Description
        {
            get { return _description; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("User Name field can’t be empty");
                    //return;
                }
                _description = value;
            }
        }
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
        public Prize(int id, int sponsorID, int eventID, int receiverID, double value, string description) : this(id, sponsorID, eventID, receiverID, value)
        {
            Description = description;
        }
        #endregion

    }
}

