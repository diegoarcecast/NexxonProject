using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Nexxon.Models.Security
{
    public class AutorizationModel : MainModel
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

        private string _userPrifle;
        public string UserProfile
        {
            get
            {
                return _userPrifle;
            }
            set
            {
                _userPrifle = value;
                OnPropertyChanged("UserProfile");
            }
        }

        #region Records
        private bool _isBtnCheckCaseVisible;
        public bool IsBtnCheckCaseVisible
        {
            get
            {
                return _isBtnCheckCaseVisible;
            }
            set
            {
                _isBtnCheckCaseVisible = value;
                OnPropertyChanged("IsBtnCheckCaseVisible");
            }
        }

        private bool _isBtnCreateCaseVisible;
        public bool IsBtnCreateCaseVisible
        {
            get
            {
                return _isBtnCreateCaseVisible;
            }
            set
            {
                _isBtnCreateCaseVisible = value;
                OnPropertyChanged("IsBtnCreateCaseVisible");
            }
        }
        #endregion

        #region Cases
        private bool _isRadioBtnJudicialCaseVisible;
        public bool IsRadioBtnJudicialCaseVisible
        {
            get
            {
                return _isRadioBtnJudicialCaseVisible;
            }
            set
            {
                _isRadioBtnJudicialCaseVisible = value;
                OnPropertyChanged("IsRadioBtnJudicialCaseVisible");
            }
        }
        #endregion

        #region Agenda
        private bool _isCbxSelectUserVisible;
        public bool IsCbxSelectUserVisible
        {
            get
            {
                return _isCbxSelectUserVisible;
            }
            set
            {
                _isCbxSelectUserVisible = value;
                OnPropertyChanged("IsCbxSelectUserVisible");
            }
        }
        #endregion

        #region Payments
        private bool _isBtnDeletePaymentVisible;
        public bool IsBtnDeletePaymentVisible
        {
            get
            {
                return _isBtnDeletePaymentVisible;
            }
            set
            {
                _isBtnDeletePaymentVisible = value;
                OnPropertyChanged("IsBtnDeletePaymentVisible");
            }
        }
        #endregion

        #region Administration
        private bool _isPivotItemModifyUserVisible;
        public bool IsPivotItemModifyUserVisible
        {
            get
            {
                return _isPivotItemModifyUserVisible;
            }
            set
            {
                _isPivotItemModifyUserVisible = value;
                OnPropertyChanged("IsPivotItemModifyUserVisible");
            }
        }

        private string _pivotItemModifyUserHeader;
        public string PivotItemModifyUserHeader
        {
            get
            {
                return _pivotItemModifyUserHeader;
            }
            set
            {
                _pivotItemModifyUserHeader = value;
                OnPropertyChanged("PivotItemModifyUserHeader");
            }
        }

        private bool _isPivotItemAddUserVisible;
        public bool IsPivotItemAddUserVisible
        {
            get
            {
                return _isPivotItemAddUserVisible;
            }
            set
            {
                _isPivotItemAddUserVisible = value;
                OnPropertyChanged("IsPivotItemAddUserVisible");
            }
        }

        private string _pivotItemAddUserHeader;
        public string PivotItemAddUserHeader
        {
            get
            {
                return _pivotItemAddUserHeader;
            }
            set
            {
                _pivotItemAddUserHeader = value;
                OnPropertyChanged("PivotItemAddUserHeader");
            }
        }

        private bool _isTextBoxEmailChangePasswordEnable;
        public bool IsTextBoxEmailChangePasswordEnable
        {
            get
            {
                return _isTextBoxEmailChangePasswordEnable;
            }
            set
            {
                _isTextBoxEmailChangePasswordEnable = value;
                OnPropertyChanged("IsTextBoxEmailChangePasswordEnable");
            }
        }

        private bool _isBtnSearchUserVisible;
        public bool IsBtnSearchUserVisible
        {
            get
            {
                return _isBtnSearchUserVisible;
            }
            set
            {
                _isBtnSearchUserVisible = value;
                OnPropertyChanged("IsBtnSearchUserVisible");
            }
        }
        #endregion
    }
}
