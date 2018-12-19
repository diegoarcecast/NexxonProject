using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Nexxon.Models.Cat_Mant;
using Nexxon.Models.Security;
using Nexxon.ViewModels.Cat_Mant;

namespace Nexxon.ViewModels.Security
{
    public class AuthenticationViewModel
    {
        private const string TOKEN = "nexxon";

        public void AuthenticateUser(ref AuthenticationModel authenticationModel, ref string sMsjError)
        {
            #region Local variables

            string sNombreTabla, sNombreSP, sEncryptedPass = authenticationModel.UserPassword;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();
            EncryptionViewModel encryptionViewModel = new EncryptionViewModel();

            #endregion

            encryptionViewModel.EncryptString(ref sEncryptedPass);

            dbViewModel.GenerarDataTableParametros(ref dbModel);

            DataRow dr1 = dbModel.dtParametros.NewRow();
            dr1["Nombre"] = "@email";
            dr1["TipoDato"] = "4";
            dr1["Valor"] = authenticationModel.UserName;

            DataRow dr2 = dbModel.dtParametros.NewRow();
            dr2["Nombre"] = "@s_contrasena";
            dr2["TipoDato"] = "4";
            dr2["Valor"] = sEncryptedPass;

            dbModel.dtParametros.Rows.Add(dr1);
            dbModel.dtParametros.Rows.Add(dr2);

            sNombreTabla = (App.Current as App).TblAuthentication.ToString();
            sNombreSP = (App.Current as App).SpAuthentication.ToString();

            dbViewModel.ExecuteFill(sNombreTabla, sNombreSP, ref dbModel);

            if (dbModel.sMsjError != string.Empty)
            {
                sMsjError = dbModel.sMsjError;
                authenticationModel.UserProfile = String.Empty;
            }
            else
            {
                sMsjError = string.Empty;

                if (dbModel.DS.Tables[sNombreTabla].Rows.Count > 0)
                {
                    authenticationModel.UserProfile = dbModel.DS.Tables[sNombreTabla].Rows[0][0].ToString();

                    if (authenticationModel.UserProfile == "Invalid Credentials")
                    {
                        authenticationModel.IsErrorMessageVisible = true;
                        authenticationModel.UserProfile = "";
                    }
                }
                else
                {
                    authenticationModel.UserProfile = string.Empty;
                    authenticationModel.IsErrorMessageVisible = true;
                }
            }
        }

        public void OnFirstLoad(ref AuthenticationModel authenticationModel)
        {
            authenticationModel.IsErrorMessageVisible = false;
        }
    }
}
