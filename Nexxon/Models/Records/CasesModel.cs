using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexxon.Models.Records
{
    public class CasesModel : MainModel
    {
        private int _idCustomerCase;
        public int IdCustomerCase
        {
            get
            {
                return _idCustomerCase;
            }
            set
            {
                _idCustomerCase = value;
                OnPropertyChanged("IdCustomerCase");
            }
        }

        private Int16 _idCaseService;
        public Int16 IdCaseService
        {
            get
            {
                return _idCaseService;
            }
            set
            {
                _idCaseService = value;
                OnPropertyChanged("IdCaseService");
            }
        }

        private string _descriptionCaseService;
        public string DescriptionCaseService
        {
            get
            {
                return _descriptionCaseService;
            }
            set
            {
                _descriptionCaseService = value;
                OnPropertyChanged("DescriptionCaseService");
            }
        }

        private Int16 _idServiceArea;
        public Int16 IdServiceArea
        {
            get
            {
                return _idServiceArea;
            }
            set
            {
                _idServiceArea = value;
                OnPropertyChanged("IdServiceArea");
            }
        }

        private string _descriptionServiceArea;
        public string DescriptionServiceArea
        {
            get
            {
                return _descriptionServiceArea;
            }
            set
            {
                _descriptionServiceArea = value;
                OnPropertyChanged("DescriptionServiceArea");
            }
        }

        private int _idCustomerRecord;
        public int IdCustomerRecord
        {
            get
            {
                return _idCustomerRecord;
            }
            set
            {
                _idCustomerRecord = value;
                OnPropertyChanged("IdCustomerRecord");
            }
        }

        private string _internalCaseNumber;
        public string InternalCaseNumber
        {
            get
            {
                return _internalCaseNumber;
            }
            set
            {
                _internalCaseNumber = value;
                OnPropertyChanged("InternalCaseNumber");
            }
        }

        private string _caseTitle;
        public string CaseTitle
        {
            get
            {
                return _caseTitle;
            }
            set
            {
                _caseTitle = value;
                OnPropertyChanged("CaseTitle");
            }
        }

        private string _suedPartyName;
        public string SuedPartyName
        {
            get
            {
                return _suedPartyName;
            }
            set
            {
                _suedPartyName = value;
                OnPropertyChanged("SuedPartyName");
            }
        }

        private string _suedPartyIdNumber;
        public string SuedPartyIdNumber
        {
            get
            {
                return _suedPartyIdNumber;
            }
            set
            {
                _suedPartyIdNumber = value;
                OnPropertyChanged("SuedPartyIdNumber");
            }
        }

        private string _judicialCircuit;
        public string JudicialCircuit
        {
            get
            {
                return _judicialCircuit;
            }
            set
            {
                _judicialCircuit = value;
                OnPropertyChanged("JudicialCircuit");
            }
        }

        private string _judicialCircuitCaseNumber;
        public string JudicialCircuitCaseNumber
        {
            get
            {
                return _judicialCircuitCaseNumber;
            }
            set
            {
                _judicialCircuitCaseNumber = value;
                OnPropertyChanged("JudicialCircuitCaseNumber");
            }
        }

        private DateTime _caseStartDate;
        public DateTime CaseStartDate
        {
            get
            {
                return _caseStartDate;
            }
            set
            {
                _caseStartDate = value;
                OnPropertyChanged("CaseStartDate");
            }
        }

        private DateTime _caseEndDate;
        public DateTime CaseEndDate
        {
            get
            {
                return _caseEndDate;
            }
            set
            {
                _caseEndDate = value;
                OnPropertyChanged("CaseEndDate");
            }
        }

        private double _professionalFees;
        public double ProfessionalFees
        {
            get
            {
                return _professionalFees;
            }
            set
            {
                _professionalFees = value;
                OnPropertyChanged("ProfessionalFees");
            }
        }

        private Int16 _idCaseStatus;
        public Int16 IdCaseStatus
        {
            get
            {
                return _idCaseStatus;
            }
            set
            {
                _idCaseStatus = value;
                OnPropertyChanged("IdCaseStatus");
            }
        }

        private string _descriptionCaseStatus;
        public string DescriptionCaseStatus
        {
            get
            {
                return _descriptionCaseStatus;
            }
            set
            {
                _descriptionCaseStatus = value;
                OnPropertyChanged("DescriptionCaseStatus");
            }
        }

        private string _attachmentsRoute;
        public string AttachmentsRoute
        {
            get
            {
                return _attachmentsRoute;
            }
            set
            {
                _attachmentsRoute = value;
                OnPropertyChanged("AttachmentsRoute");
            }
        }

        private DataTable _dataTableServices;
        public DataTable DataTableServices
        {
            get
            {
                return _dataTableServices;
            }
            set
            {
                _dataTableServices = value;
                OnPropertyChanged("DataTableServices");
            }
        }

        private List<CasesModel> _servicesList;
        public List<CasesModel> ServicesList
        {
            get
            {
                return _servicesList;
            }
            set
            {
                _servicesList = value;
                OnPropertyChanged("ServicesList");
            }
        }

        private DataTable _dataTableStatus;
        public DataTable DataTableStatus
        {
            get
            {
                return _dataTableStatus;
            }
            set
            {
                _dataTableStatus = value;
                OnPropertyChanged("DataTableStatus");
            }
        }

        private List<CasesModel> _statusList;
        public List<CasesModel> StatusList
        {
            get
            {
                return _statusList;
            }
            set
            {
                _statusList = value;
                OnPropertyChanged("StatusList");
            }
        }

        private DataTable _dataTableCases;
        public DataTable DataTableCases
        {
            get
            {
                return _dataTableCases;
            }
            set
            {
                _dataTableCases = value;
                OnPropertyChanged("DataTableCases");
            }
        }

        private List<CasesModel> _casesList;
        public List<CasesModel> CasesList
        {
            get
            {
                return _casesList;
            }
            set
            {
                _casesList = value;
                OnPropertyChanged("CasesList");
            }
        }
    }
}
