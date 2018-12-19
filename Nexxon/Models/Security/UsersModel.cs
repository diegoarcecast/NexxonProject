using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Nexxon.Models.Security
{
    public class UsersModel : MainModel
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

        private string _newPasswordEmail;
        public string NewPasswordEmail
        {
            get
            {
                return _newPasswordEmail;
            }
            set
            {
                _newPasswordEmail = value;
                OnPropertyChanged("NewPasswordEmail");
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

        private string _userNewPassword;
        public string UserNewPassword
        {
            get
            {
                return _userNewPassword;
            }
            set
            {
                _userNewPassword = value;
                OnPropertyChanged("UserNewPassword");

                if (!(_userNewPassword is null) && !(_userConfirmNewPassword is null) && _userNewPassword != string.Empty && _userConfirmNewPassword != string.Empty)
                {
                    IsChangePassButtonEnabled = true;
                }
                else
                {
                    IsChangePassButtonEnabled = false;
                }
            }
        }

        private string _userConfirmNewPassword;
        public string UserConfirmNewPassword
        {
            get
            {
                return _userConfirmNewPassword;
            }
            set
            {
                _userConfirmNewPassword = value;
                OnPropertyChanged("UserConfirmNewPassword");

                if (!(_userNewPassword is null) && !(_userConfirmNewPassword is null) && _userNewPassword != string.Empty && _userConfirmNewPassword != string.Empty)
                {
                    IsChangePassButtonEnabled = true;
                }
                else
                {
                    IsChangePassButtonEnabled = false;
                }
            }
        }

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
            }
        }

        private string _userLastName;
        public string UserLastName
        {
            get
            {
                return _userLastName;
            }
            set
            {
                _userLastName = value;
                OnPropertyChanged("UserLastName");
            }
        }

        private string _userIdNumber;
        public string UserIdNumber
        {
            get
            {
                return _userIdNumber;
            }
            set
            {
                _userIdNumber = value;
                OnPropertyChanged("UserIdNumber");
            }
        }

        private string _userIdType;
        public string UserIdType
        {
            get
            {
                return _userIdType;
            }
            set
            {
                _userIdType = value;
                OnPropertyChanged("UserIdType");
            }
        }

        private string _userAddress;
        public string UserAddress
        {
            get
            {
                return _userAddress;
            }
            set
            {
                _userAddress = value;
                OnPropertyChanged("UserAddress");
            }
        }

        private string _userProvince;
        public string UserProvince
        {
            get
            {
                return _userProvince;
            }
            set
            {
                _userProvince = value;
                OnPropertyChanged("UserProvince");
            }
        }

        private string _userCanton;
        public string UserCanton
        {
            get
            {
                return _userCanton;
            }
            set
            {
                _userCanton = value;
                OnPropertyChanged("UserCanton");
            }
        }

        private string _userDistrict;
        public string UserDistrict
        {
            get
            {
                return _userDistrict;
            }
            set
            {
                _userDistrict = value;
                OnPropertyChanged("UserDistrict");
            }
        }

        private string _userPhoneNumberOne;
        public string UserPhoneNumberOne
        {
            get
            {
                return _userPhoneNumberOne;
            }
            set
            {
                _userPhoneNumberOne = value;
                OnPropertyChanged("UserPhoneNumberOne");
            }
        }

        private string _userPhoneNumberTwo;
        public string UserPhoneNumberTwo
        {
            get
            {
                return _userPhoneNumberTwo;
            }
            set
            {
                _userPhoneNumberTwo = value;
                OnPropertyChanged("UserPhoneNumberTwo");
            }
        }

        private Int32 _userProfileId;
        public Int32 UserProfileId
        {
            get
            {
                return _userProfileId;
            }
            set
            {
                _userProfileId = value;
                OnPropertyChanged("UserProfileId");
            }
        }

        private string _userProfileName;
        public string UserProfileName
        {
            get
            {
                return _userProfileName;
            }
            set
            {
                _userProfileName = value;
                OnPropertyChanged("UserProfileName");
            }
        }

        private bool _isChangePassButtonEnabled;
        public bool IsChangePassButtonEnabled
        {
            get
            {
                return _isChangePassButtonEnabled;
            }
            set
            {
                _isChangePassButtonEnabled = value;
                OnPropertyChanged("IsChangePassButtonEnabled");
            }
        }

        private DataTable _dataTableProfiles;
        public DataTable DataTableProfiles
        {
            get
            {
                return _dataTableProfiles;
            }
            set
            {
                _dataTableProfiles = value;
                OnPropertyChanged("DataTableProfiles");
            }
        }

        private List<UsersModel> _profilesList;
        public List<UsersModel> ProfilesList
        {
            get
            {
                return _profilesList;
            }
            set
            {
                _profilesList = value;
                OnPropertyChanged("ProfilesList");
            }
        }
    }
}
