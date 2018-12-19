using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexxon.Models.Security
{
    public class PasswordRecoveryModel : MainModel
    {
        private string _userEmail;
        public string UserEmail
        {
            get
            {
                return _userEmail;
            }
            set
            {
                _userEmail = value;
                OnPropertyChanged("UserEmail");
            }
        }

        private string _passwordEmail;
        public string PasswordEmail
        {
            get
            {
                return _passwordEmail;
            }
            set
            {
                _passwordEmail = value;
                OnPropertyChanged("PasswordEmail");
            }
        }

        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }
    }
}
