using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexxon.Models.Cat_Mant;

namespace Nexxon.ViewModels.Cat_Mant
{
    public class DbViewModel
    {
        /// <summary>
        /// Metodo para ir al App.waml.cs y leer el connection string y usarlo para crear
        /// un objeto SqlConnection a partir de dicho connection string
        /// </summary>
        /// <param name="dbModel">Objeto de tipo DbModel</param>
        public void GetConnection(ref DbModel dbModel)
        {
            try
            {
                dbModel.sCadenaCNX = (App.Current as App).ConnectionString;
                dbModel.CNX = new SqlConnection(dbModel.sCadenaCNX);

                dbModel.bBanderaError = false;
                dbModel.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                dbModel.sCadenaCNX = string.Empty;
                dbModel.CNX = null;

                dbModel.bBanderaError = true;
                dbModel.sMsjError = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Metodo para abrir la conexion a la base de datos
        /// </summary>
        /// <param name="dbModel">Objeto de tipo DbModel</param>
        public void OpenConnection(ref DbModel dbModel)
        {
            try
            {
                if (dbModel.CNX != null)
                {
                    if (dbModel.CNX.State == ConnectionState.Closed)
                    {
                        dbModel.CNX.Open();
                        dbModel.bBanderaError = false;
                        dbModel.sMsjError = string.Empty;
                    }
                    else
                    {
                        dbModel.bBanderaError = true;
                        dbModel.sMsjError = "La conexion ya se encuentra abierta";
                    }
                }
            }
            catch (SqlException ex)
            {
                dbModel.bBanderaError = true;
                dbModel.sMsjError = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Metodo para cerrar la conexion a la base de datos
        /// </summary>
        /// <param name="dbModel">Objeto de tipo DbModel</param>
        public void CloseConnection(ref DbModel dbModel)
        {
            try
            {
                if (dbModel.CNX != null)
                {
                    if (dbModel.CNX.State == ConnectionState.Open)
                    {
                        dbModel.CNX.Close();
                        dbModel.CNX.Dispose();
                        dbModel.bBanderaError = false;
                        dbModel.sMsjError = string.Empty;
                    }
                    else
                    {
                        dbModel.bBanderaError = true;
                        dbModel.sMsjError = "La conexion ya se encuentra cerrada";
                    }
                }
            }
            catch (SqlException ex)
            {
                dbModel.bBanderaError = true;
                dbModel.sMsjError = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Metodo para Ejecutar los Listar y Filtrar de las Tablas
        /// </summary>
        /// <param name="sNombreTabla">Tabla a la cual se va a hacer la consulta</param>
        /// <param name="sNombreSP">Stored procedure que se llamara</param>
        /// <param name="dbModel">Objeto de tipo DbModel</param>
        public void ExecuteFill(string sNombreTabla, string sNombreSP, ref DbModel dbModel)
        {
            try
            {
                GetConnection(ref dbModel);
                OpenConnection(ref dbModel);

                dbModel.DAP = new SqlDataAdapter(sNombreSP, dbModel.CNX);
                dbModel.DAP.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (!(dbModel.dtParametros is null))
                {
                    foreach (DataRow dr in dbModel.dtParametros.Rows)
                    {
                        switch (dr["TipoDato"].ToString())
                        {
                            case "1":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Int).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "2":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Char).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "3":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NChar).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "4":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "5":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NVarChar).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "6":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.DateTime).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "7":
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Bit).Value = dr["Valor"].ToString();
                                }
                                break;
                            case "8":
                                {
                                    dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Decimal).Value = dr["Valor"].ToString();
                                }
                                break;
                            default:
                                {
                                    dbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                                }
                                break;
                        }
                    }
                }

                dbModel.DAP.Fill(dbModel.DS, sNombreTabla);

                dbModel.bBanderaError = false;
                dbModel.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                dbModel.bBanderaError = true;
                dbModel.sMsjError = ex.Message.ToString();
            }
            finally
            {
                if (dbModel.CNX.State == ConnectionState.Open)
                {
                    dbModel.CNX.Close();
                    dbModel.CNX.Dispose();
                    dbModel.bBanderaError = false;
                    dbModel.sMsjError = string.Empty;
                }

            }
        }

        /// <summary>
        /// Metodo para Ejecutar eliminar, modificar e insertar datos de las Tablas cuya PK no sea IDENTITY
        /// </summary>
        /// <param name="sNombreSP">Stored procedure que se llamara</param>
        /// <param name="dbModel">Objeto de tipo DbModel</param>
        public void ExecuteNonQuery(string sNombreSP, ref DbModel dbModel)
        {
            try
            {
                GetConnection(ref dbModel);
                OpenConnection(ref dbModel);

                dbModel.CMD = new SqlCommand(sNombreSP, dbModel.CNX);
                dbModel.CMD.CommandType = CommandType.StoredProcedure;

                foreach (DataRow dr in dbModel.dtParametros.Rows)
                {
                    switch (dr["TipoDato"].ToString())
                    {
                        case "1":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Int).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "2":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Char).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "3":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "4":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "5":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NVarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "6":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.DateTime).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "7":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Bit).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "8":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Decimal).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "9":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.SmallInt).Value = dr["Valor"].ToString();
                            }
                            break;
                        default:
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                    }
                }

                dbModel.CMD.ExecuteNonQuery();

                dbModel.bBanderaError = false;
                dbModel.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                dbModel.bBanderaError = true;
                dbModel.sMsjError = ex.Message.ToString();
            }
            finally
            {
                if (dbModel.CNX.State == ConnectionState.Open)
                {
                    dbModel.CNX.Close();
                    dbModel.CNX.Dispose();
                }
            }
        }

        /// <summary>
        /// Metodo para Ejecutar insertar datos de las Tablas cuya PK es IDENTITY
        /// </summary>
        /// <param name="sNombreSP">Stored procedure que se llamara</param>
        /// <param name="dbModel">Objeto de tipo DbModel</param>
        /// <param name="sResult">String para devolver el resultado del insert</param>
        public void ExecuteScalar(string sNombreSP, ref DbModel dbModel, ref string sResult)
        {
            try
            {
                GetConnection(ref dbModel);
                OpenConnection(ref dbModel);

                dbModel.CMD = new SqlCommand(sNombreSP, dbModel.CNX);
                dbModel.CMD.CommandType = CommandType.StoredProcedure;

                foreach (DataRow dr in dbModel.dtParametros.Rows)
                {
                    switch (dr["TipoDato"].ToString())
                    {
                        case "1":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Int).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "2":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Char).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "3":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "4":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "5":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NVarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "6":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.DateTime).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "7":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Bit).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "8":
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Decimal).Value = dr["Valor"].ToString();
                            }
                            break;
                        default:
                            {
                                dbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                    }
                }

                sResult = dbModel.CMD.ExecuteScalar().ToString();

                dbModel.bBanderaError = false;
                dbModel.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                dbModel.bBanderaError = true;
                dbModel.sMsjError = ex.Message.ToString();
            }
            finally
            {
                if (dbModel.CNX.State == ConnectionState.Open)
                {
                    dbModel.CNX.Close();
                    dbModel.CNX.Dispose();
                }
            }
        }

        /// <summary>
        /// Metodo para llenar el DT de parametros
        /// </summary>
        /// <param name="dbModel">DT de parametros</param>
        public void GenerarDataTableParametros(ref DbModel dbModel)
        {
            dbModel.dtParametros = new DataTable("Parametros");

            DataColumn dcNombre = new DataColumn("Nombre");
            DataColumn dcTipoDato = new DataColumn("TipoDato");
            DataColumn dcValor = new DataColumn("Valor");

            dbModel.dtParametros.Columns.Add(dcNombre);
            dbModel.dtParametros.Columns.Add(dcTipoDato);
            dbModel.dtParametros.Columns.Add(dcValor);
        }
    }
}
