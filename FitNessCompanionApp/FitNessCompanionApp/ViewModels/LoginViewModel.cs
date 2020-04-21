using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.ViewModels
{
    class LoginViewModel
    {
        #region Properties
        public string PasswordHint
        {
            get
            {
                return "Insert upper-case and lower-case letters, numbers and _";
            }
        }
        #endregion

        #region Methods
        internal bool CheckLoginCredentials(string username, string password)
        {
            return true;
        }

        internal bool CheckSignUpCredentials(string name, string email, string username, string password, string confirmPassword)
        {
            if (!password.Equals(confirmPassword))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
