using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexxon.Models.Records
{
    public class RecordsModel : MainModel
    {
        private int _recordId;
        public int RecordId
        {
            get
            {
                return _recordId;
            }
            set
            {
                _recordId = value;
                OnPropertyChanged("RecordId");
            }
        }

        private Int16 _idBuffet = 1;
        public Int16 IdBuffet
        {
            get
            {
                return _idBuffet;
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private string _customerLastName;
        public string CustomerLastName
        {
            get
            {
                return _customerLastName;
            }
            set
            {
                _customerLastName = value;
                OnPropertyChanged("CustomerLastName");
            }
        }

        private string _customerIdType;
        public string CustomerIdType
        {
            get
            {
                return _customerIdType;
            }
            set
            {
                _customerIdType = value;
                OnPropertyChanged("CustomerIdType");
            }
        }

        private string _customerIdNumber;
        public string CustomerIdNumber
        {
            get
            {
                return _customerIdNumber;
            }
            set
            {
                _customerIdNumber = value;
                OnPropertyChanged("CustomerIdNumber");
            }
        }

        private string _customerAddress;
        public string CustomerAddress
        {
            get
            {
                return _customerAddress;
            }
            set
            {
                _customerAddress = value;
                OnPropertyChanged("CustomerAddress");
            }
        }

        private string _customerProvince;
        public string CustomerProvince
        {
            get
            {
                return _customerProvince;
            }
            set
            {
                _customerProvince = value;
                OnPropertyChanged("CustomerProvince");
            }
        }

        private string _customerCanton;
        public string CustomerCanton
        {
            get
            {
                return _customerCanton;
            }
            set
            {
                _customerCanton = value;
                OnPropertyChanged("CustomerCanton");
            }
        }

        private string _customerDistrict;
        public string CustomerDistrict
        {
            get
            {
                return _customerDistrict;
            }
            set
            {
                _customerDistrict = value;
                OnPropertyChanged("CustomerDistrict");
            }
        }

        private string _customerEmail;
        public string CustomerEmail
        {
            get
            {
                return _customerEmail;
            }
            set
            {
                _customerEmail = value;
                OnPropertyChanged("CustomerEmail");
            }
        }

        private string _customerPhoneNumberOne;
        public string CustomerPhoneNumberOne
        {
            get
            {
                return _customerPhoneNumberOne;
            }
            set
            {
                _customerPhoneNumberOne = value;
                OnPropertyChanged("CustomerPhoneNumberOne");
            }
        }

        private string _customerPhoneNumberTwo;
        public string CustomerPhoneNumberTwo
        {
            get
            {
                return _customerPhoneNumberTwo;
            }
            set
            {
                _customerPhoneNumberTwo = value;
                OnPropertyChanged("CustomerPhoneNumberTwo");
            }
        }

        private string _customerSearchCriteria;
        public string CustomerSearchCriteria
        {
            get
            {
                return _customerSearchCriteria;
            }
            set
            {
                _customerSearchCriteria = value;
                OnPropertyChanged("CustomerSearchCriteria");
            }
        }

        private List<RecordsModel> _recordsList;
        public List<RecordsModel> RecordsList
        {
            get
            {
                return _recordsList;
            }
            set
            {
                _recordsList = value;
                OnPropertyChanged("RecordsList");
            }
        }

        private bool _isEditRecordBtnEnabled;
        public bool IsEditRecordBtnEnabled
        {
            get
            {
                return _isEditRecordBtnEnabled;
            }
            set
            {
                _isEditRecordBtnEnabled = value;
                OnPropertyChanged("IsEditRecordBtnEnabled");
            }
        }
    }
}
