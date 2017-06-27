using SABISCollaborate.SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Model
{
    /// <summary>
    /// Represents a User Profile
    /// </summary>
    public class UserProfile
    {
        #region Fields
        private string _nickName;
        private string _firstName;
        private string _lastName;
        #endregion

        #region Properties
        public int Id { get; private set; }

        public string Nickname
        {
            get { return this._nickName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Nickname");
                }
                this._nickName = value;
            }
        }

        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FirstName");
                }
                this._firstName = value;
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("LastName");
                }
                this._lastName = value;
            }
        }

        public string Quote { get; set; }

        public string Status { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public DateTime BirthDate { get; set; }

        protected int? EmploymentInfoId { get; set; }

        public EmploymentInfo EmploymentInfo { get; set; }

        public string PictureId { get; set; }
        #endregion

        #region Constructors
        private UserProfile() { }

        public UserProfile(string nickname, string firstName, string lastName, DateTime birthDate) : this()
        {
            this.Nickname = nickname;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;

            this.Gender = Gender.Unspecified;
            this.MaritalStatus = MaritalStatus.Unspecified;

            this.EmploymentInfoId = null;
            this.EmploymentInfo = null;
        }
        #endregion
    }
}
