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

        public void authenticateUser(ref AuthenticationModel authenticationModel, ref string sMsjError)
        {
            #region Variables Locales

            string sNombreTabla, sNombreSP, sEncryptedPass = authenticationModel.UserPassword;

            DbModel obj_DbModel = new DbModel();
            DbViewModel obj_DbViewModel = new DbViewModel();

            #endregion

            encryptPassword(ref sEncryptedPass);

            obj_DbViewModel.generarDataTableParametros(ref obj_DbModel);

            DataRow dr1 = obj_DbModel.dtParametros.NewRow();
            dr1["Nombre"] = "@email";
            dr1["TipoDato"] = "4";
            dr1["Valor"] = authenticationModel.UserName;

            DataRow dr2 = obj_DbModel.dtParametros.NewRow();
            dr2["Nombre"] = "@s_contrasena";
            dr2["TipoDato"] = "4";
            dr2["Valor"] = sEncryptedPass;

            obj_DbModel.dtParametros.Rows.Add(dr1);
            obj_DbModel.dtParametros.Rows.Add(dr2);

            sNombreTabla = (App.Current as App).TblAuthentication.ToString(); /*ConfigurationManager.AppSettings["NombTablaCarreras"].ToString();*/
            sNombreSP = (App.Current as App).SpAuthentication.ToString(); /*ConfigurationManager.AppSettings["SPFiltrarCarreras"].ToString();*/

            obj_DbViewModel.executeFill(sNombreTabla, sNombreSP, ref obj_DbModel/*, obj_DAL_Genericos*/);

            if (obj_DbModel.sMsjError != string.Empty)
            {
                sMsjError = obj_DbModel.sMsjError;
                authenticationModel.UserProfile = String.Empty;
            }
            else
            {
                sMsjError = string.Empty;

                if (obj_DbModel.DS.Tables[sNombreTabla].Rows.Count > 0)
                {
                    authenticationModel.UserProfile = obj_DbModel.DS.Tables[sNombreTabla].Rows[0][0].ToString();
                }
                else
                {
                    authenticationModel.UserProfile = string.Empty;
                    authenticationModel.IsErrorMessageVisible = true;
                }
            }
        }

        private void encryptPassword(ref string sPass)
        {
            byte[] key; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] array = UTF8Encoding.UTF8.GetBytes(sPass); //Arreglo donde guardaremos la cadena descifrada.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(TOKEN));
            md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = key;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(array, 0, array.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();

            sPass = Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }

        public void OnFirstLoad(ref AuthenticationModel authenticationModel)
        {
            authenticationModel.IsErrorMessageVisible = false;
        }
    }
}
