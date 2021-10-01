using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace UserClasses
{
    public abstract class User 
    {
        #region Member variables/ get/set
        public string _UniqueID { protected set; get; }
        public string _FirstName { set; get; }
        public string _SurName { get; set; }
        public string _DOB { get; set; }
        public string _UserName { get; set; }
        public string _PasswordHash { get; set; }
        public string _UserType { get; set; }
        #endregion

        #region Methods

        #endregion

        protected User(string firstName, string surName, string dob, string password, string userType, string userName)
        {

            _UniqueID = Util.generateGuid().ToString();
            _FirstName = firstName;
            _SurName = surName;
            _DOB = dob;
            _PasswordHash = HashPassword(password);
            _UserType = userType;
            _UserName = userName;
        }
        /// <summary>
        /// Hash a password
        /// </summary>
        /// <param name="pass"></param>
        /// <returns>string:hashed password</returns>
        private string HashPassword(string pass)
        {
            Encryption e = new Encryption();
            string hash = e.Encrypt(pass);
            return hash;
        }
        /// <summary>
        /// Checks whether the attempted password is the correct password for the user
        /// </summary>
        /// <param name="authPassword"></param>
        /// <returns>bool:authed</returns>
        public bool VerifyPassword(string authPassword)
        {
            Encryption e = new Encryption();
            string authPasswordHash = e.Encrypt(authPassword);
            if (authPasswordHash != _PasswordHash)
            {
                return false;
            }

            return true;
        }
    }


}
