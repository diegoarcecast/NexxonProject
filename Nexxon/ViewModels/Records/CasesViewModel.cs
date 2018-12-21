using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexxon.Models.Records;
using Nexxon.Models.Cat_Mant;
using Nexxon.ViewModels.Cat_Mant;
using System.Data;

namespace Nexxon.ViewModels.Records
{
    public class CasesViewModel
    {
        public void LoadServices(ref string sMsjError, ref CasesModel casesModel)
        {
            #region Local variables

            string sNombreTabla, sNombreSP;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();

            #endregion

            dbViewModel.GenerarDataTableParametros(ref dbModel);

            DataRow dr1 = dbModel.dtParametros.NewRow();
            dr1["Nombre"] = "@id_area";
            dr1["TipoDato"] = "9";
            dr1["Valor"] = casesModel.IdServiceArea;

            dbModel.dtParametros.Rows.Add(dr1);

            sNombreTabla = (App.Current as App).TblServices.ToString();
            sNombreSP = (App.Current as App).SpListServices.ToString();

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
                    casesModel.DataTableServices = dbModel.DS.Tables[sNombreTabla];
                    if (casesModel.ServicesList is null)
                    {
                        casesModel.ServicesList = new List<CasesModel>();
                    }
                    else
                    {
                        casesModel.ServicesList.Clear();
                    }

                    for (int i = 0; i < casesModel.DataTableServices.Rows.Count; i++)
                    {
                        CasesModel service = new CasesModel();
                        service.IdCaseService = Convert.ToInt16(casesModel.DataTableServices.Rows[i]["ID_SERVICIO"]);
                        service.IdServiceArea = Convert.ToInt16(casesModel.DataTableServices.Rows[i]["ID_AREA"]);
                        service.DescriptionCaseService = casesModel.DataTableServices.Rows[i]["NOMBRE"].ToString();

                        casesModel.ServicesList.Add(service);
                    }
                }
            }
        }

        public void LoadCasesStatus(ref string sMsjError, ref CasesModel casesModel)
        {
            #region Local variables

            string sNombreTabla, sNombreSP;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();

            #endregion

            dbViewModel.GenerarDataTableParametros(ref dbModel);

            sNombreTabla = (App.Current as App).TblStatus.ToString();
            sNombreSP = (App.Current as App).SpListPossibleCaseStatus.ToString();

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
                    casesModel.DataTableStatus = dbModel.DS.Tables[sNombreTabla];

                    if (casesModel.StatusList is null)
                    {
                        casesModel.StatusList = new List<CasesModel>();
                    }
                    else
                    {
                        casesModel.StatusList.Clear();
                    }

                    for (int i = 0; i < casesModel.DataTableStatus.Rows.Count; i++)
                    {
                        CasesModel status = new CasesModel();
                        status.IdCaseStatus = Convert.ToInt16(casesModel.DataTableStatus.Rows[i]["ID_ESTADO"]);
                        status.DescriptionCaseStatus = casesModel.DataTableStatus.Rows[i]["NOMBRE_ESTADO"].ToString();

                        casesModel.StatusList.Add(status);
                    }
                }
            }
        }

        public void CreateNewCase(ref string sMessage, ref CasesModel casesModel)
        {
            #region Local variables

            string sNombreSP, sResult = string.Empty;

            DbModel dbModel = new DbModel();
            DbViewModel dbViewModel = new DbViewModel();

            #endregion
            if (casesModel.IdCaseService == 0)
            {
                sMessage = "Por favor seleccione un tipo de caso";
            }
            else if (casesModel.CaseTitle == string.Empty || casesModel.CaseTitle is null)
            {
                sMessage = "Por favor ingrese un título para el caso";
            }
            else if (casesModel.IdServiceArea == 1 && (casesModel.SuedPartyName == string.Empty || casesModel.SuedPartyName is null ||
                     casesModel.SuedPartyIdNumber == string.Empty || casesModel.SuedPartyIdNumber is null))
            {
                sMessage = "Por favor ingrese los datos del demandado";
            }
            else if (casesModel.ProfessionalFees == 0)
            {
                sMessage = "Por favor ingrese el monto a cobrar";
            }
            else if (casesModel.IdCaseStatus == 0)
            {
                sMessage = "Por favor seleccione un estado para el caso";
            }
            else
            {
                if (casesModel.JudicialCircuit is null)
                {
                    casesModel.JudicialCircuit = "";
                }

                if (casesModel.JudicialCircuitCaseNumber is null)
                {
                    casesModel.JudicialCircuitCaseNumber = "";
                }

                casesModel.CaseEndDate = DateTime.MaxValue;

                #region Create SP parameters
                dbViewModel.GenerarDataTableParametros(ref dbModel);

                DataRow dr1 = dbModel.dtParametros.NewRow();
                dr1["Nombre"] = "@id_serv";
                dr1["TipoDato"] = "9";
                dr1["Valor"] = casesModel.IdCaseService;

                DataRow dr2 = dbModel.dtParametros.NewRow();
                dr2["Nombre"] = "@id_exp";
                dr2["TipoDato"] = "1";
                dr2["Valor"] = casesModel.IdCustomerRecord;

                DataRow dr3 = dbModel.dtParametros.NewRow();
                dr3["Nombre"] = "@caso_int";
                dr3["TipoDato"] = "4";
                dr3["Valor"] = casesModel.InternalCaseNumber;

                DataRow dr4 = dbModel.dtParametros.NewRow();
                dr4["Nombre"] = "@title";
                dr4["TipoDato"] = "4";
                dr4["Valor"] = casesModel.CaseTitle;

                DataRow dr5 = dbModel.dtParametros.NewRow();
                dr5["Nombre"] = "@n_demandado";
                dr5["TipoDato"] = "4";
                dr5["Valor"] = casesModel.SuedPartyName;

                DataRow dr6 = dbModel.dtParametros.NewRow();
                dr6["Nombre"] = "@id_demandado";
                dr6["TipoDato"] = "4";
                dr6["Valor"] = casesModel.SuedPartyIdNumber;

                DataRow dr7 = dbModel.dtParametros.NewRow();
                dr7["Nombre"] = "@juzg";
                dr7["TipoDato"] = "4";
                dr7["Valor"] = casesModel.JudicialCircuit;

                DataRow dr8 = dbModel.dtParametros.NewRow();
                dr8["Nombre"] = "@n_exp_juzg";
                dr8["TipoDato"] = "4";
                dr8["Valor"] = casesModel.JudicialCircuitCaseNumber;

                DataRow dr9 = dbModel.dtParametros.NewRow();
                dr9["Nombre"] = "@fecha_ini";
                dr9["TipoDato"] = "6";
                dr9["Valor"] = casesModel.CaseStartDate;

                DataRow dr10 = dbModel.dtParametros.NewRow();
                dr10["Nombre"] = "@fecha_fin";
                dr10["TipoDato"] = "6";
                dr10["Valor"] = casesModel.CaseEndDate;

                DataRow dr11 = dbModel.dtParametros.NewRow();
                dr11["Nombre"] = "@honorarios";
                dr11["TipoDato"] = "10";
                dr11["Valor"] = casesModel.ProfessionalFees;

                DataRow dr12 = dbModel.dtParametros.NewRow();
                dr12["Nombre"] = "@estado";
                dr12["TipoDato"] = "9";
                dr12["Valor"] = casesModel.IdCaseStatus;

                DataRow dr13 = dbModel.dtParametros.NewRow();
                dr13["Nombre"] = "@ruta_adj";
                dr13["TipoDato"] = "4";
                dr13["Valor"] = casesModel.AttachmentsRoute;


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
                sNombreSP = (App.Current as App).SpAddNewCase.ToString();

                dbViewModel.ExecuteScalar(sNombreSP, ref dbModel, ref sResult);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMessage = dbModel.sMsjError;
                }
                else
                {
                    casesModel.InternalCaseNumber = sResult;
                }
                #endregion
            }
        }

        public void SearchAllCustomerCases(ref CasesModel casesModel, ref string sMsjError)
        {
            if (casesModel.IdCustomerRecord == 0 )
            {
                sMsjError = "Por favor ingrese un número de expediente para realizar la busqueda";
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
                dr1["Nombre"] = "@idExpediente";
                dr1["TipoDato"] = "1";
                dr1["Valor"] = casesModel.IdCustomerRecord;

                dbModel.dtParametros.Rows.Add(dr1);

                sNombreTabla = (App.Current as App).TblCases.ToString();
                sNombreSP = (App.Current as App).SpListCustomerCases.ToString();

                dbViewModel.ExecuteFill(sNombreTabla, sNombreSP, ref dbModel);

                if (dbModel.sMsjError != string.Empty)
                {
                    sMsjError = dbModel.sMsjError;
                }
                else
                {
                    if (casesModel.CasesList is null)
                    {
                        casesModel.CasesList = new List<CasesModel>();
                    }
                    else
                    {
                        casesModel.CasesList.Clear();
                    }

                    sMsjError = string.Empty;

                    if (dbModel.DS.Tables[sNombreTabla].Rows.Count > 0)
                    {
                        for (int i = 0; i < dbModel.DS.Tables[sNombreTabla].Rows.Count; i++)
                        {
                            CasesModel internalCaseNumber = new CasesModel();
                            internalCaseNumber.InternalCaseNumber = dbModel.DS.Tables[sNombreTabla].Rows[i]["CASO_INTERNO"].ToString();

                            casesModel.CasesList.Add(internalCaseNumber);
                        }
                    }
                }
            }
        }
    }
}
