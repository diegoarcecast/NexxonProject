using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Nexxon.Models.Security
{
    public class AutorizationModel
    {
        public string _sPrifle { get; set; }

        #region Records
        private Button ButtonCheckCase;
        public Button _buttonCheckCase
        {
            get => ButtonCheckCase;
            set => ButtonCheckCase = value;
        }

        private Button ButtonCreateCase;
        public Button _buttonCreateCase
        {
            get => ButtonCreateCase;
            set => ButtonCreateCase = value;
        }
        #endregion

        #region Cases
        private RadioButton RadioButtonJudicialCase;
        public RadioButton _radioButtonJudicialCase
        {
            get => RadioButtonJudicialCase;
            set => RadioButtonJudicialCase = value;
        }
        #endregion

        #region Agenda
        private ComboBox CbxAgendaUsers;
        public ComboBox _cbxAgendaUsers
        {
            get => CbxAgendaUsers;
            set => CbxAgendaUsers = value;
        }
        #endregion

        #region Payments
        private Button ButtonDeletePayment;
        public Button _buttonDeletePayment
        {
            get => ButtonDeletePayment;
            set => ButtonDeletePayment = value;
        }
        #endregion

        #region Administration
        private PivotItem PivotItemModifyUser;
        public PivotItem _pivotItemModifyUser
        {
            get => PivotItemModifyUser;
            set => PivotItemModifyUser = value;
        }

        private PivotItem PivotItemAddUser;
        public PivotItem _pivotItemAddUser
        {
            get => PivotItemAddUser;
            set => PivotItemAddUser = value;
        }

        private TextBox TextBoxEmailChangePassword;
        public TextBox _textBoxEmailChangePassword
        {
            get => TextBoxEmailChangePassword;
            set => TextBoxEmailChangePassword = value;
        }
        #endregion
    }
}
