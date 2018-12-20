using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Nexxon.Models.Cat_Mant;
using Nexxon.Models.Records;
using Nexxon.ViewModels.Cat_Mant;

namespace Nexxon.ViewModels.Records
{
    public class RecordsViewModel
    {
        public void CreateNewCustomerRecord(ref string sMessage, ref RecordsModel recordsModel)
        {
            #region Local variables

            string sNombreSP, sResult = string.Empty;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();

            #endregion
            if (recordsModel.CustomerEmail is null || !IsCustomerEmailGood(recordsModel.CustomerEmail))
            {
                sMessage = "Por favor verifique que el correo electrónico se haya ingresado en el formato correcto";
            }
            else if (recordsModel.CustomerName == string.Empty || recordsModel.CustomerName is null ||
                     recordsModel.CustomerLastName == string.Empty || recordsModel.CustomerLastName is null)
            {
                sMessage = "Por favor ingrese el nombre y apellido(s) del cliente";
            }
            else if (recordsModel.CustomerIdType == "Nacional" && !IsIdNumberGood(recordsModel.CustomerIdNumber))
            {
                sMessage = "Por favor verifique que el número de identificación se haya ingresado en el formato correcto";
            }
            else if (recordsModel.CustomerAddress == string.Empty || recordsModel.CustomerAddress is null ||
                     recordsModel.CustomerProvince == string.Empty || recordsModel.CustomerProvince is null ||
                     recordsModel.CustomerCanton == string.Empty || recordsModel.CustomerCanton is null ||
                     recordsModel.CustomerDistrict == string.Empty || recordsModel.CustomerDistrict is null)
            {
                sMessage = "Por favor ingrese una dirección de residencia";
            }
            else if (recordsModel.CustomerPhoneNumberOne == string.Empty || recordsModel.CustomerPhoneNumberOne is null || !(IsPhoneNumberGood(recordsModel.CustomerPhoneNumberOne)))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else if (recordsModel.CustomerPhoneNumberTwo != string.Empty && !(recordsModel.CustomerPhoneNumberTwo is null) && !IsPhoneNumberGood(recordsModel.CustomerPhoneNumberTwo))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else
            {
                if (recordsModel.CustomerPhoneNumberTwo is null)
                {
                    recordsModel.CustomerPhoneNumberTwo = "";
                }

                #region Create SP parameters
                dbViewModel.GenerarDataTableParametros(ref dbModel);

                DataRow dr1 = dbModel.dtParametros.NewRow();
                dr1["Nombre"] = "@id_buf";
                dr1["TipoDato"] = "9";
                dr1["Valor"] = recordsModel.IdBuffet;

                DataRow dr2 = dbModel.dtParametros.NewRow();
                dr2["Nombre"] = "@nombre";
                dr2["TipoDato"] = "4";
                dr2["Valor"] = recordsModel.CustomerName;

                DataRow dr3 = dbModel.dtParametros.NewRow();
                dr3["Nombre"] = "@apellidos";
                dr3["TipoDato"] = "4";
                dr3["Valor"] = recordsModel.CustomerLastName;

                DataRow dr4 = dbModel.dtParametros.NewRow();
                dr4["Nombre"] = "@ced";
                dr4["TipoDato"] = "4";
                dr4["Valor"] = recordsModel.CustomerIdNumber;

                DataRow dr5 = dbModel.dtParametros.NewRow();
                dr5["Nombre"] = "@direccion";
                dr5["TipoDato"] = "4";
                dr5["Valor"] = recordsModel.CustomerAddress;

                DataRow dr6 = dbModel.dtParametros.NewRow();
                dr6["Nombre"] = "@provincia";
                dr6["TipoDato"] = "4";
                dr6["Valor"] = recordsModel.CustomerProvince;

                DataRow dr7 = dbModel.dtParametros.NewRow();
                dr7["Nombre"] = "@canton";
                dr7["TipoDato"] = "4";
                dr7["Valor"] = recordsModel.CustomerCanton;

                DataRow dr8 = dbModel.dtParametros.NewRow();
                dr8["Nombre"] = "@distrito";
                dr8["TipoDato"] = "4";
                dr8["Valor"] = recordsModel.CustomerDistrict;

                DataRow dr9 = dbModel.dtParametros.NewRow();
                dr9["Nombre"] = "@email";
                dr9["TipoDato"] = "4";
                dr9["Valor"] = recordsModel.CustomerEmail;

                DataRow dr10 = dbModel.dtParametros.NewRow();
                dr10["Nombre"] = "@tel1";
                dr10["TipoDato"] = "4";
                dr10["Valor"] = recordsModel.CustomerPhoneNumberOne;

                DataRow dr11 = dbModel.dtParametros.NewRow();
                dr11["Nombre"] = "@tel2";
                dr11["TipoDato"] = "4";
                dr11["Valor"] = recordsModel.CustomerPhoneNumberTwo;


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

                #endregion

                #region Execute SP
                sNombreSP = (App.Current as App).SpCreateCustomerRecord.ToString();

                dbViewModel.ExecuteScalar(sNombreSP, ref dbModel, ref sResult);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMessage = dbModel.sMsjError;
                }
                else
                {
                    recordsModel.RecordId = Convert.ToInt32(sResult);
                }
                #endregion
            }
        }

        public void SearchAllCustomerRecords(ref RecordsModel recordsModel, ref string sMsjError)
        {
            if (recordsModel.CustomerSearchCriteria == string.Empty || recordsModel.CustomerSearchCriteria is null)
            {
                sMsjError = "Por favor ingrese un nombre o número de identificación para realizar la busqueda";
            }
            else
            {
                #region Local variables

                string sNombreTabla, sNombreSP;

                DbModel dbModel = new DbModel();
                DbViewModel dbViewModel = new DbViewModel();

                #endregion

                dbViewModel.GenerarDataTableParametros(ref dbModel);

                DataRow dr1 = dbModel.dtParametros.NewRow();
                dr1["Nombre"] = "@nombreIdentificacion";
                dr1["TipoDato"] = "4";
                dr1["Valor"] = recordsModel.CustomerSearchCriteria;

                dbModel.dtParametros.Rows.Add(dr1);

                sNombreTabla = (App.Current as App).TblCustomerRecords.ToString();
                sNombreSP = (App.Current as App).SpSearchAllRecords.ToString();

                dbViewModel.ExecuteFill(sNombreTabla, sNombreSP, ref dbModel);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMsjError = dbModel.sMsjError;
                }
                else
                {
                    recordsModel.RecordsList = new List<RecordsModel>();
                    sMsjError = string.Empty;

                    if (dbModel.DS.Tables[sNombreTabla].Rows.Count > 0)
                    {
                        for (int i = 0; i < dbModel.DS.Tables[sNombreTabla].Rows.Count; i++)
                        {
                            RecordsModel recordNumber = new RecordsModel();
                            recordNumber.RecordId = Convert.ToInt32(dbModel.DS.Tables[sNombreTabla].Rows[i][0].ToString());

                            recordsModel.RecordsList.Add(recordNumber);
                        }
                    }
                }
            }
        }

        public void SearchSpecificCustomerRecords(ref RecordsModel recordsModel, ref string sMsjError)
        {
            #region Local variables

            string sNombreTabla, sNombreSP;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();

            #endregion

            dbViewModel.GenerarDataTableParametros(ref dbModel);

            DataRow dr1 = dbModel.dtParametros.NewRow();
            dr1["Nombre"] = "@numeroExpediente";
            dr1["TipoDato"] = "1";
            dr1["Valor"] = recordsModel.RecordId;

            dbModel.dtParametros.Rows.Add(dr1);

            sNombreTabla = (App.Current as App).TblCustomerRecords.ToString();
            sNombreSP = (App.Current as App).SpSearchSpecificRecord.ToString();

            dbViewModel.ExecuteFill(sNombreTabla, sNombreSP, ref dbModel);

            if (dbModel.sMsjError != string.Empty)
            {
                sMsjError = dbModel.sMsjError;
            }
            else
            {
                if (dbModel.DS.Tables[sNombreTabla].Rows.Count == 0)
                {
                    sMsjError = "No se encontró ningún expediente con el número brindado";
                }
                else
                {
                    recordsModel.RecordId = Convert.ToInt32(dbModel.DS.Tables[sNombreTabla].Rows[0]["ID_EXPEDIENTE"]);
                    recordsModel.CustomerName = dbModel.DS.Tables[sNombreTabla].Rows[0]["NOMBRE"].ToString();
                    recordsModel.CustomerLastName = dbModel.DS.Tables[sNombreTabla].Rows[0]["APELLIDOS"].ToString();
                    recordsModel.CustomerIdNumber = dbModel.DS.Tables[sNombreTabla].Rows[0]["CEDULA"].ToString();
                    recordsModel.CustomerAddress = dbModel.DS.Tables[sNombreTabla].Rows[0]["DIRECCION"].ToString();
                    recordsModel.CustomerProvince = dbModel.DS.Tables[sNombreTabla].Rows[0]["PROVINCIA"].ToString();
                    recordsModel.CustomerCanton = dbModel.DS.Tables[sNombreTabla].Rows[0]["CANTON"].ToString();
                    recordsModel.CustomerDistrict = dbModel.DS.Tables[sNombreTabla].Rows[0]["DISTRITO"].ToString();
                    recordsModel.CustomerEmail = dbModel.DS.Tables[sNombreTabla].Rows[0]["EMAIL"].ToString();
                    recordsModel.CustomerPhoneNumberOne = dbModel.DS.Tables[sNombreTabla].Rows[0]["TELEFONO_1"].ToString();
                    recordsModel.CustomerPhoneNumberTwo = dbModel.DS.Tables[sNombreTabla].Rows[0]["TELEFONO_2"].ToString();
                }
            }
        }

        public void EditCustomerRecord(ref string sMessage, ref RecordsModel recordsModel)
        {
            if (!IsCustomerEmailGood(recordsModel.CustomerEmail))
            {
                sMessage = "Por favor verifique que el correo electrónico se haya ingresado en el formato correcto";
            }
            else if (recordsModel.CustomerAddress == string.Empty || recordsModel.CustomerAddress is null ||
                     recordsModel.CustomerProvince == string.Empty || recordsModel.CustomerProvince is null ||
                     recordsModel.CustomerCanton == string.Empty || recordsModel.CustomerCanton is null ||
                     recordsModel.CustomerDistrict == string.Empty || recordsModel.CustomerDistrict is null)
            {
                sMessage = "Por favor ingrese una dirección de residencia";
            }
            else if (recordsModel.CustomerPhoneNumberOne == string.Empty || recordsModel.CustomerPhoneNumberOne is null || !(IsPhoneNumberGood(recordsModel.CustomerPhoneNumberOne)))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else if (recordsModel.CustomerPhoneNumberTwo != string.Empty && !(recordsModel.CustomerPhoneNumberTwo is null) && !IsPhoneNumberGood(recordsModel.CustomerPhoneNumberTwo))
            {
                sMessage = "Por favor verifique que el número telefónico se haya ingresado en el formato correcto";
            }
            else
            {
                #region Variables Locales

                string SpName;

                DbModel dbModel = new DbModel();
                DbViewModel dbViewModel = new DbViewModel();

                #endregion

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

                dr["Nombre"] = "@id";
                dr["TipoDato"] = "1";
                dr["Valor"] = recordsModel.RecordId;

                dr1["Nombre"] = "@id_buf";
                dr1["TipoDato"] = "1";
                dr1["Valor"] = recordsModel.IdBuffet;

                dr2["Nombre"] = "@nombre";
                dr2["TipoDato"] = "4";
                dr2["Valor"] = recordsModel.CustomerName;

                dr3["Nombre"] = "@apellidos";
                dr3["TipoDato"] = "4";
                dr3["Valor"] = recordsModel.CustomerLastName;

                dr4["Nombre"] = "@ced";
                dr4["TipoDato"] = "4";
                dr4["Valor"] = recordsModel.CustomerIdNumber;

                dr5["Nombre"] = "@direccion";
                dr5["TipoDato"] = "4";
                dr5["Valor"] = recordsModel.CustomerAddress;

                dr6["Nombre"] = "@provincia";
                dr6["TipoDato"] = "4";
                dr6["Valor"] = recordsModel.CustomerProvince;

                dr7["Nombre"] = "@canton";
                dr7["TipoDato"] = "4";
                dr7["Valor"] = recordsModel.CustomerCanton;

                dr8["Nombre"] = "@distrito";
                dr8["TipoDato"] = "4";
                dr8["Valor"] = recordsModel.CustomerDistrict;

                dr9["Nombre"] = "@email";
                dr9["TipoDato"] = "4";
                dr9["Valor"] = recordsModel.CustomerEmail;

                dr10["Nombre"] = "@tel1";
                dr10["TipoDato"] = "4";
                dr10["Valor"] = recordsModel.CustomerPhoneNumberOne;

                dr11["Nombre"] = "@tel2";
                dr11["TipoDato"] = "4";
                dr11["Valor"] = recordsModel.CustomerPhoneNumberTwo;

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

                SpName = (App.Current as App).SpEditCustomerRecord.ToString();

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

        private bool IsCustomerEmailGood(string UserEmail)
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

            rx = new Regex(@"^.+[\@].+\.[a-z][a-z][a-z]$", RegexOptions.Compiled);
            matches = rx.Matches(UserEmail);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        private bool IsIdNumberGood(string IdNumber)
        {
            MatchCollection matches;
            Regex rx = new Regex(@"^[0-9]{1}\-[0-9]{4}\-[0-9]{4}$", RegexOptions.Compiled);

            matches = rx.Matches(IdNumber);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        private bool IsPhoneNumberGood(string PhoneNumber)
        {
            MatchCollection matches;
            Regex rx = new Regex(@"^[0-9]{4}\-[0-9]{4}$", RegexOptions.Compiled);

            matches = rx.Matches(PhoneNumber);

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }
    }
}
