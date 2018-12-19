using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Nexxon.Models.Cat_Mant;
using Nexxon.Models.Security;
using Nexxon.ViewModels.Cat_Mant;

namespace Nexxon.ViewModels.Security
{
    public class UsersViewModel
    {
        public void LoadUserRoles(ref string sMsjError, ref UsersModel usersModel)
        {
            #region Local variables

            string sNombreTabla, sNombreSP;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();

            #endregion

            //dbViewModel.GenerarDataTableParametros(ref dbModel);

            //DataRow dr1 = dbModel.dtParametros.NewRow();
            //dr1["Nombre"] = "@email";
            //dr1["TipoDato"] = "4";
            //dr1["Valor"] = authenticationModel.UserName;

            //DataRow dr2 = dbModel.dtParametros.NewRow();
            //dr2["Nombre"] = "@s_contrasena";
            //dr2["TipoDato"] = "4";
            //dr2["Valor"] = sEncryptedPass;

            //dbModel.dtParametros.Rows.Add(dr1);
            //dbModel.dtParametros.Rows.Add(dr2);

            sNombreTabla = (App.Current as App).TblProfiles.ToString();
            sNombreSP = (App.Current as App).SpListProfiles.ToString();

            dbViewModel.ExecuteFill(sNombreTabla, sNombreSP, ref dbModel);

            if (dbModel.sMsjError != string.Empty)
            {
                sMsjError = dbModel.sMsjError;
            }
            else
            {
                sMsjError = string.Empty;

                if (dbModel.DS.Tables[sNombreTabla].Rows.Count > 0)
                {
                    usersModel.DataTableProfiles = dbModel.DS.Tables[sNombreTabla];

                    usersModel.ProfilesList = new List<UsersModel>();

                    for (int i = 0; i < usersModel.DataTableProfiles.Rows.Count; i++)
                    {
                        UsersModel profile = new UsersModel();
                        profile.UserProfileId = Convert.ToInt32(usersModel.DataTableProfiles.Rows[i][0]);
                        profile.UserProfileName = usersModel.DataTableProfiles.Rows[i][1].ToString();

                        usersModel.ProfilesList.Add(profile);
                    }
                }
            }
        }

        /// <summary>
        /// This method is used to create a new user in the data base
        /// </summary>
        /// <param name="sMsjError"></param>
        /// <param name="usersModel"></param>
        public void CreateNewUser(ref string sMessage, ref UsersModel usersModel)
        {
            #region Local variables

            string sNombreSP, sEncryptedEmailPass = usersModel.PasswordEmail, sEncryptedUserPass = "", sResultado = string.Empty;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();
            EncryptionViewModel encryptionViewModel = new EncryptionViewModel();

            #endregion
            if (!IsEmailGood(usersModel.UserEmail))
            {
                sMessage = "Por favor verifique que el correo electrónico se haya ingresado en el formato correcto";
            }
            else if (usersModel.PasswordEmail == string.Empty || usersModel.PasswordEmail is null)
            {
                sMessage = "Por favor ingrese la contraseña del correo electrónico";
            }
            else if (usersModel.UserIdType == "Nacional" && !IsIdNumberGood(usersModel.UserIdNumber))
            {
                sMessage = "Por favor verifique que el número de identificación se haya ingresado en el formato correcto";
            }
            else if (usersModel.UserAddress == string.Empty || usersModel.UserAddress is null ||
                     usersModel.UserProvince == string.Empty || usersModel.UserProvince is null ||
                     usersModel.UserCanton == string.Empty || usersModel.UserCanton is null ||
                     usersModel.UserDistrict == string.Empty || usersModel.UserDistrict is null)
            {
                sMessage = "Por favor ingrese una dirección de residencia";
            }
            else if (usersModel.UserPhoneNumberOne == string.Empty || usersModel.UserPhoneNumberOne is null || !(IsPhoneNumberGood(usersModel.UserPhoneNumberOne)))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else if (usersModel.UserPhoneNumberTwo != string.Empty && !(usersModel.UserPhoneNumberTwo is null) && !IsPhoneNumberGood(usersModel.UserPhoneNumberTwo))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else if (usersModel.UserProfileId == 0)
            {
                sMessage = "Por favor seleccione un perfil para el usuario";
            }
            else
            {
                GenerateRandomString(ref sEncryptedUserPass);
                usersModel.UserPassword = sEncryptedUserPass;
                sEncryptedEmailPass = usersModel.PasswordEmail;

                encryptionViewModel.EncryptString(ref sEncryptedEmailPass);
                encryptionViewModel.EncryptString(ref sEncryptedUserPass);

                if (usersModel.UserPhoneNumberTwo is null)
                {
                    usersModel.UserPhoneNumberTwo = "";
                }

                #region Create SP parameters
                dbViewModel.GenerarDataTableParametros(ref dbModel);

                DataRow dr1 = dbModel.dtParametros.NewRow();
                dr1["Nombre"] = "@id_per";
                dr1["TipoDato"] = "9";
                dr1["Valor"] = usersModel.UserProfileId;

                DataRow dr2 = dbModel.dtParametros.NewRow();
                dr2["Nombre"] = "@email";
                dr2["TipoDato"] = "4";
                dr2["Valor"] = usersModel.UserEmail;

                DataRow dr3 = dbModel.dtParametros.NewRow();
                dr3["Nombre"] = "@e_contrasena";
                dr3["TipoDato"] = "4";
                dr3["Valor"] = sEncryptedEmailPass;

                DataRow dr4 = dbModel.dtParametros.NewRow();
                dr4["Nombre"] = "@s_contrasena";
                dr4["TipoDato"] = "4";
                dr4["Valor"] = sEncryptedUserPass;

                DataRow dr5 = dbModel.dtParametros.NewRow();
                dr5["Nombre"] = "@nombre";
                dr5["TipoDato"] = "4";
                dr5["Valor"] = usersModel.UserName;

                DataRow dr6 = dbModel.dtParametros.NewRow();
                dr6["Nombre"] = "@apellidos";
                dr6["TipoDato"] = "4";
                dr6["Valor"] = usersModel.UserLastName;

                DataRow dr7 = dbModel.dtParametros.NewRow();
                dr7["Nombre"] = "@ced";
                dr7["TipoDato"] = "4";
                dr7["Valor"] = usersModel.UserIdNumber;

                DataRow dr8 = dbModel.dtParametros.NewRow();
                dr8["Nombre"] = "@tel1";
                dr8["TipoDato"] = "4";
                dr8["Valor"] = usersModel.UserPhoneNumberOne;

                DataRow dr9 = dbModel.dtParametros.NewRow();
                dr9["Nombre"] = "@tel2";
                dr9["TipoDato"] = "4";
                dr9["Valor"] = usersModel.UserPhoneNumberTwo;

                DataRow dr10 = dbModel.dtParametros.NewRow();
                dr10["Nombre"] = "@dir";
                dr10["TipoDato"] = "4";
                dr10["Valor"] = usersModel.UserAddress;

                DataRow dr11 = dbModel.dtParametros.NewRow();
                dr11["Nombre"] = "@provincia";
                dr11["TipoDato"] = "4";
                dr11["Valor"] = usersModel.UserProvince;

                DataRow dr12 = dbModel.dtParametros.NewRow();
                dr12["Nombre"] = "@canton";
                dr12["TipoDato"] = "4";
                dr12["Valor"] = usersModel.UserCanton;

                DataRow dr13 = dbModel.dtParametros.NewRow();
                dr13["Nombre"] = "@distrito";
                dr13["TipoDato"] = "4";
                dr13["Valor"] = usersModel.UserDistrict;


                dbModel.dtParametros.Rows.Add(dr1);
                dbModel.dtParametros.Rows.Add(dr2);
                dbModel.dtParametros.Rows.Add(dr3);
                dbModel.dtParametros.Rows.Add(dr4);
                dbModel.dtParametros.Rows.Add(dr5);
                dbModel.dtParametros.Rows.Add(dr6);
                dbModel.dtParametros.Rows.Add(dr7);
                dbModel.dtParametros.Rows.Add(dr8);
                dbModel.dtParametros.Rows.Add(dr9);
                dbModel.dtParametros.Rows.Add(dr10);
                dbModel.dtParametros.Rows.Add(dr11);
                dbModel.dtParametros.Rows.Add(dr12);
                dbModel.dtParametros.Rows.Add(dr13);
                #endregion

                #region Execute SP
                sNombreSP = (App.Current as App).SpCreateUser.ToString();

                dbViewModel.ExecuteNonQuery(sNombreSP, ref dbModel);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMessage = dbModel.sMsjError;
                }
                #endregion
            }
        }

        public void ChangeUserPassword(ref string sMsjError, ref UsersModel usersModel)
        {
            if (!IsPasswordGood(usersModel.UserNewPassword))
            {
                sMsjError = "Por favor verifique que la contraseña posea el formato correcto.\nLa contraseña debe estar compuesta por una combinación de letras mayúsculas, minúsculas y núumeros\nNo se aceptan caracteres especiales";
            }
            else
            {
                #region Variables Locales

                string SpName;
                string encryptedUserPassword;

                DbModel dbModel = new DbModel();
                DbViewModel dbViewModel = new DbViewModel();
                EncryptionViewModel encryptionViewModel = new EncryptionViewModel();

                #endregion
                encryptedUserPassword = usersModel.UserNewPassword;
                encryptionViewModel.EncryptString(ref encryptedUserPassword);

                dbViewModel.GenerarDataTableParametros(ref dbModel);

                DataRow dr = dbModel.dtParametros.NewRow();
                DataRow dr1 = dbModel.dtParametros.NewRow();

                dr["Nombre"] = "@email";
                dr["TipoDato"] = "4";
                dr["Valor"] = usersModel.UserEmail;

                dr1["Nombre"] = "@s_contrasena";
                dr1["TipoDato"] = "4";
                dr1["Valor"] = encryptedUserPassword;

                dbModel.dtParametros.Rows.Add(dr);
                dbModel.dtParametros.Rows.Add(dr1);

                SpName = (App.Current as App).SpChangeUserPassword.ToString();

                dbViewModel.ExecuteNonQuery(SpName, ref dbModel);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMsjError = dbModel.sMsjError;
                }
                else
                {
                    sMsjError = string.Empty;
                }
            }
        }

        public void EditUser(ref string sMessage, ref UsersModel usersModel)
        {
            if (!IsEmailGood(usersModel.UserEmail))
            {
                sMessage = "Por favor verifique que la contraseña posea el formato correcto.\nLa contraseña debe estar compuesta por una combinación de letras mayúsculas, minúsculas y núumeros\nNo se aceptan caracteres especiales";
            }
            else if (usersModel.UserAddress == string.Empty || usersModel.UserAddress is null ||
                     usersModel.UserProvince == string.Empty || usersModel.UserProvince is null ||
                     usersModel.UserCanton == string.Empty || usersModel.UserCanton is null ||
                     usersModel.UserDistrict == string.Empty || usersModel.UserDistrict is null)
            {
                sMessage = "Por favor ingrese una dirección de residencia";
            }
            else if (usersModel.UserPhoneNumberOne == string.Empty || usersModel.UserPhoneNumberOne is null || !(IsPhoneNumberGood(usersModel.UserPhoneNumberOne)))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else if (usersModel.UserPhoneNumberTwo != string.Empty && !(usersModel.UserPhoneNumberTwo is null) && !IsPhoneNumberGood(usersModel.UserPhoneNumberTwo))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else if (usersModel.UserProfileId == 0)
            {
                sMessage = "Por favor seleccione un perfil para el usuario";
            }
            else
            {
                #region Variables Locales

                string SpName;

                DbModel dbModel = new DbModel();
                DbViewModel dbViewModel = new DbViewModel();

                #endregion
                if (usersModel.NewPasswordEmail == string.Empty || usersModel.NewPasswordEmail is null)
                {
                    usersModel.NewPasswordEmail = usersModel.PasswordEmail;
                }
                else
                {
                    EncryptionViewModel encryptionViewModel = new EncryptionViewModel();
                    string encryptPass = usersModel.NewPasswordEmail;
                    encryptionViewModel.EncryptString(ref encryptPass);
                    usersModel.NewPasswordEmail = encryptPass;
                }

                dbViewModel.GenerarDataTableParametros(ref dbModel);

                DataRow dr = dbModel.dtParametros.NewRow();
                DataRow dr1 = dbModel.dtParametros.NewRow();
                DataRow dr2 = dbModel.dtParametros.NewRow();
                DataRow dr3 = dbModel.dtParametros.NewRow();
                DataRow dr4 = dbModel.dtParametros.NewRow();
                DataRow dr5 = dbModel.dtParametros.NewRow();
                DataRow dr6 = dbModel.dtParametros.NewRow();
                DataRow dr7 = dbModel.dtParametros.NewRow();
                DataRow dr8 = dbModel.dtParametros.NewRow();
                DataRow dr9 = dbModel.dtParametros.NewRow();
                DataRow dr10 = dbModel.dtParametros.NewRow();
                DataRow dr11 = dbModel.dtParametros.NewRow();

                dr["Nombre"] = "@id_per";
                dr["TipoDato"] = "9";
                dr["Valor"] = usersModel.UserProfileId;

                dr1["Nombre"] = "@email";
                dr1["TipoDato"] = "4";
                dr1["Valor"] = usersModel.UserEmail;

                dr2["Nombre"] = "@e_contrasena";
                dr2["TipoDato"] = "4";
                dr2["Valor"] = usersModel.PasswordEmail;

                dr3["Nombre"] = "@nombre";
                dr3["TipoDato"] = "4";
                dr3["Valor"] = usersModel.UserName;

                dr4["Nombre"] = "@apellidos";
                dr4["TipoDato"] = "4";
                dr4["Valor"] = usersModel.UserLastName;

                dr5["Nombre"] = "@ced";
                dr5["TipoDato"] = "4";
                dr5["Valor"] = usersModel.UserIdNumber;

                dr6["Nombre"] = "@tel1";
                dr6["TipoDato"] = "4";
                dr6["Valor"] = usersModel.UserPhoneNumberOne;

                dr7["Nombre"] = "@tel2";
                dr7["TipoDato"] = "4";
                dr7["Valor"] = usersModel.UserPhoneNumberTwo;

                dr8["Nombre"] = "@dir";
                dr8["TipoDato"] = "4";
                dr8["Valor"] = usersModel.UserAddress;

                dr9["Nombre"] = "@provincia";
                dr9["TipoDato"] = "4";
                dr9["Valor"] = usersModel.UserProvince;

                dr10["Nombre"] = "@canton";
                dr10["TipoDato"] = "4";
                dr10["Valor"] = usersModel.UserCanton;

                dr11["Nombre"] = "@distrito";
                dr11["TipoDato"] = "4";
                dr11["Valor"] = usersModel.UserDistrict;

                dbModel.dtParametros.Rows.Add(dr);
                dbModel.dtParametros.Rows.Add(dr1);
                dbModel.dtParametros.Rows.Add(dr2);
                dbModel.dtParametros.Rows.Add(dr3);
                dbModel.dtParametros.Rows.Add(dr4);
                dbModel.dtParametros.Rows.Add(dr5);
                dbModel.dtParametros.Rows.Add(dr6);
                dbModel.dtParametros.Rows.Add(dr7);
                dbModel.dtParametros.Rows.Add(dr8);
                dbModel.dtParametros.Rows.Add(dr9);
                dbModel.dtParametros.Rows.Add(dr10);
                dbModel.dtParametros.Rows.Add(dr11);

                SpName = (App.Current as App).SpEditUser.ToString();

                dbViewModel.ExecuteNonQuery(SpName, ref dbModel);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMessage = dbModel.sMsjError;
                }
                else
                {
                    sMessage = string.Empty;
                }
            }
        }

        public void SearchUser(ref UsersModel usersModel, ref string sMsjError)
        {
            #region Local variables

            string sNombreTabla, sNombreSP, sEncryptedPass = usersModel.UserPassword;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();
            EncryptionViewModel encryptionViewModel = new EncryptionViewModel();

            #endregion

            dbViewModel.GenerarDataTableParametros(ref dbModel);

            DataRow dr1 = dbModel.dtParametros.NewRow();
            dr1["Nombre"] = "@email";
            dr1["TipoDato"] = "4";
            dr1["Valor"] = usersModel.UserEmail;

            dbModel.dtParametros.Rows.Add(dr1);

            sNombreTabla = (App.Current as App).TblUsers.ToString();
            sNombreSP = (App.Current as App).SpSearchUser.ToString();

            dbViewModel.ExecuteFill(sNombreTabla, sNombreSP, ref dbModel);

            if (dbModel.sMsjError != string.Empty)
            {
                sMsjError = dbModel.sMsjError;
            }
            else
            {
                if (dbModel.DS.Tables[sNombreTabla].Rows.Count == 0)
                {
                    sMsjError = "No se encontró ningún usuario con el correo brindado";
                }
                else
                {
                    usersModel.UserProfileId = Convert.ToInt32(dbModel.DS.Tables[sNombreTabla].Rows[0]["ID_PERFIL"]);
                    usersModel.UserProfileName = dbModel.DS.Tables[sNombreTabla].Rows[0]["NOMBRE_PERFIL"].ToString();
                    usersModel.UserEmail = dbModel.DS.Tables[sNombreTabla].Rows[0]["EMAIL"].ToString();
                    usersModel.PasswordEmail = dbModel.DS.Tables[sNombreTabla].Rows[0]["EMAIL_CONTRASENA"].ToString();
                    usersModel.UserName = dbModel.DS.Tables[sNombreTabla].Rows[0]["NOMBRE"].ToString();
                    usersModel.UserLastName = dbModel.DS.Tables[sNombreTabla].Rows[0]["APELLIDOS"].ToString();
                    usersModel.UserIdNumber = dbModel.DS.Tables[sNombreTabla].Rows[0]["CEDULA"].ToString();
                    usersModel.UserPhoneNumberOne = dbModel.DS.Tables[sNombreTabla].Rows[0]["TELEFONO_1"].ToString();
                    usersModel.UserPhoneNumberTwo = dbModel.DS.Tables[sNombreTabla].Rows[0]["TELEFONO_2"].ToString();
                    usersModel.UserAddress = dbModel.DS.Tables[sNombreTabla].Rows[0]["DIRECCION"].ToString();
                    usersModel.UserProvince = dbModel.DS.Tables[sNombreTabla].Rows[0]["PROVINCIA"].ToString();
                    usersModel.UserCanton = dbModel.DS.Tables[sNombreTabla].Rows[0]["CANTON"].ToString();
                    usersModel.UserDistrict = dbModel.DS.Tables[sNombreTabla].Rows[0]["DISTRITO"].ToString();
                }
            }
        }

        private bool IsEmailGood(string UserEmail)
        {
            MatchCollection matches;
            Regex rx = new Regex(@"[\@]", RegexOptions.Compiled);

            matches = rx.Matches(UserEmail);

            if (matches.Count != 1)
            {
                return false;
            }

            rx = new Regex(@"\s+", RegexOptions.Compiled);
            matches = rx.Matches(UserEmail);

            if (matches.Count != 0)
            {
                return false;
            }

            rx = new Regex(@".+gmail\.com$|.+hotmail\.com$", RegexOptions.Compiled);
            matches = rx.Matches(UserEmail);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        private bool IsPhoneNumberGood(string UserPhoneNumber)
        {
            MatchCollection matches;
            Regex rx = new Regex(@"^[0-9]{4}\-[0-9]{4}$", RegexOptions.Compiled);

            matches = rx.Matches(UserPhoneNumber);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        private bool IsIdNumberGood(string UserIdNumber)
        {
            MatchCollection matches;
            Regex rx = new Regex(@"^[0-9]{1}\-[0-9]{4}\-[0-9]{4}$", RegexOptions.Compiled);

            matches = rx.Matches(UserIdNumber);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        private bool IsPasswordGood(string UserPassword)
        {
            MatchCollection matches;

            Regex rx = new Regex(@"\s", RegexOptions.Compiled);

            matches = rx.Matches(UserPassword);

            if (matches.Count != 0)
            {
                return false;
            }

            rx = new Regex(@"[A-Za-z0-9]{8,}", RegexOptions.Compiled);

            matches = rx.Matches(UserPassword);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        private void GenerateRandomString(ref string Password)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];
                Int16 length = 10;

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            Password = res.ToString();
        }
    }
}
