using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Nexxon.Models.Security
{
    public class AuthenticationModel : MainModel
    {
        #region Public members
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");

                if (!(_userName is null) && !(_userPassword is null) && _userName != string.Empty && _userPassword != string.Empty)
                {
                    IsLoginButtonEnabled = true;
                }
                else
                {
                    IsLoginButtonEnabled = false;
                }
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

                if (!(_userName is null) && !(_userPassword is null) && _userName != string.Empty && _userPassword != string.Empty)
                {
                    IsLoginButtonEnabled = true;
                }
                else
                {
                    IsLoginButtonEnabled = false;
                }
            }
        }

        private string _userProfile;
        public string UserProfile
        {
            get
            {
                return _userProfile;
            }
            set
            {
                _userProfile = value;
                OnPropertyChanged("UserProfile");
            }
        }

        private bool _isErrorMessageVisible;
        public bool IsErrorMessageVisible
        {
            get
            {
                return _isErrorMessageVisible;
            }
            set
            {
                _isErrorMessageVisible = value;
                OnPropertyChanged("IsErrorMessageVisible");
            }
        }

        private bool _isLoginButtonEnabled;
        public bool IsLoginButtonEnabled
        {
            get
            {
                return _isLoginButtonEnabled;
            }
            set
            {
                _isLoginButtonEnabled = value;
                OnPropertyChanged("IsLoginButtonEnabled");
            }
        }
        #endregion
    }
}
