using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Nexxon.Models.Security;
using Windows.UI.Xaml;

namespace Nexxon.ViewModels.Security
{
    public class AuthorizationViewModel
    {
        public void RecordsPermissions(ref AutorizationModel obj_AutorizationModel)
        {
            if (obj_AutorizationModel._sPrifle == "Asistente")
            {
                obj_AutorizationModel._buttonCheckCase.Visibility = Visibility.Collapsed;
                obj_AutorizationModel._buttonCreateCase.Visibility = Visibility.Collapsed;
            }
        }

        public void CreateCasePermissions(ref AutorizationModel obj_AutorizationModel)
        {
            if (obj_AutorizationModel._sPrifle == "Notario")
            {
                obj_AutorizationModel._radioButtonJudicialCase.Visibility = Visibility.Collapsed;
            }
        }

        public void ViewAgendaPermissions(ref AutorizationModel obj_AutorizationModel)
        {
            if (obj_AutorizationModel._sPrifle == "Administrador" || obj_AutorizationModel._sPrifle == "Administrador")
            {
                obj_AutorizationModel._cbxAgendaUsers.Visibility = Visibility.Visible;
            }
            else
            {
                obj_AutorizationModel._cbxAgendaUsers.Visibility = Visibility.Collapsed;
            }
        }

        public void PaymentsPermissions(ref AutorizationModel obj_AutorizationModel)
        {
            if (obj_AutorizationModel._sPrifle == "Administrador")
            {
                obj_AutorizationModel._buttonDeletePayment.Visibility = Visibility.Visible;
            }
            else
            {
                obj_AutorizationModel._buttonDeletePayment.Visibility = Visibility.Collapsed;
            }
        }

        public void AdministrationPermissions(ref AutorizationModel obj_AutorizationModel)
        {
            if (obj_AutorizationModel._sPrifle == "Administrador")
            {
                obj_AutorizationModel._pivotItemAddUser.Visibility = Visibility.Visible;
                obj_AutorizationModel._pivotItemModifyUser.Visibility = Visibility.Visible;
            }
            else
            {
                obj_AutorizationModel._pivotItemAddUser.Visibility = Visibility.Collapsed;
                obj_AutorizationModel._pivotItemAddUser.Header = "";

                obj_AutorizationModel._pivotItemModifyUser.Visibility = Visibility.Collapsed;
                obj_AutorizationModel._pivotItemModifyUser.Header = "";

                obj_AutorizationModel._textBoxEmailChangePassword.IsEnabled = false;
            }
        }
    }
}
