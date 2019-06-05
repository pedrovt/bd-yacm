using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

	public enum UserType
	{
		Manager, Participant, Sponsor
	}

    [Serializable()]
    public class User
    {
        #region Attributes
        private String _email;
        private String _name;
        private String _password;
		private UserType _type;
        #endregion

        #region Getters/Setters
        public int ID { get; set; }

        public String Email
        {
            get { return _email; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("User Email field can’t be empty");
                    //return;
                }
                if (!value.Contains("@"))
                {
                    throw new Exception("Invalid Email");
                    //return;
                }
                _email = value;
            }
        }

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

        public String Password
        {
            get { return _password; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("User Password field can’t be empty");
                    //return;
                }
                _password = value;
            }
        }

		public UserType Type {
			get { return _type; }
			set { _type = value;  }
		}
        #endregion

        #region ToString
        public override String ToString()
        {
            return "[User]\n" + Name + " (id: " + ID + ")\n" + Email + "\n";
        }
        #endregion

        #region Constructors
        public User() : base()
        {
        }

        public User(int id, String email, String name, String password) : base()
        {
            ID = id;
            Email = email;
            Name = name;
            Password = password;
        }
        #endregion

    }
}

