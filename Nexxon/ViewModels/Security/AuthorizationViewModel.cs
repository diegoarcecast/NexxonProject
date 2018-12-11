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
        public void RecordsPagePermissions(ref AutorizationModel authorizationModel)
        {
            if (authorizationModel.UserProfile == "Asistente")
            {
                authorizationModel.IsBtnCheckCaseVisible = false;
                authorizationModel.IsBtnCreateCaseVisible = false;
            }
            else
            {
                authorizationModel.IsBtnCheckCaseVisible = true;
                authorizationModel.IsBtnCreateCaseVisible = true;
            }
        }

        public void CreateCasePermissions(ref AutorizationModel authorizationModel)
        {
            if (authorizationModel.UserProfile == "Administrador" || authorizationModel.UserProfile == "Abogado")
            {
                authorizationModel.IsRadioBtnJudicialCaseVisible = true;
            }
            else
            {
                authorizationModel.IsRadioBtnJudicialCaseVisible = false;
            }

        }

        public void ViewAgendaPermissions(ref AutorizationModel authorizationModel)
        {
            if (authorizationModel.UserProfile == "Administrador" || authorizationModel.UserProfile == "Asistente")
            {
                authorizationModel.IsCbxSelectUserVisible = true;
            }
            else
            {
                authorizationModel.IsCbxSelectUserVisible = false;
            }
        }

        public void PaymentsPermissions(ref AutorizationModel authorizationModel)
        {
            if (authorizationModel.UserProfile == "Administrador")
            {
                authorizationModel.IsBtnDeletePaymentVisible = true;
            }
            else
            {
                authorizationModel.IsBtnDeletePaymentVisible = false;
            }
        }

        public void AdministrationPermissions(ref AutorizationModel authorizationModel)
        {
            if (authorizationModel.UserProfile == "Administrador")
            {
                authorizationModel.IsTextBoxEmailChangePasswordEnable = true;
                authorizationModel.IsBtnSearchUserVisible = true;

                authorizationModel.IsPivotItemModifyUserVisible = true;
                authorizationModel.PivotItemModifyUserHeader = "Editar usuarios";

                authorizationModel.IsPivotItemAddUserVisible = true;
                authorizationModel.PivotItemAddUserHeader = "Agregar usuarios";
            }
            else
            {
                authorizationModel.IsTextBoxEmailChangePasswordEnable = false;
                authorizationModel.IsBtnSearchUserVisible = false;

                authorizationModel.IsPivotItemModifyUserVisible = false;
                authorizationModel.PivotItemModifyUserHeader = "";

                authorizationModel.IsPivotItemAddUserVisible = false;
                authorizationModel.PivotItemAddUserHeader = "";
            }
        }
    }
}
