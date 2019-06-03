using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

    [Serializable()]
    public class Team
    {
        #region Attributes
        private String _name;
        #endregion

        #region Getters/Setters
        public String Name
        {
            get { return _name; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("User Name field can’t be empty");
                    //return;
                }
                _name = value;
            }
        }
        #endregion

        #region ToString
        public override String ToString()
        {
            return "Team " + Name;
        }
        #endregion

        #region Constructors
        public Team() : base()
        {
        }

        public User(String name) : base()
        {
            Name = name;
        }
        #endregion

    }
}

