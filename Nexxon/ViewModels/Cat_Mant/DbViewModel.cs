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
        /// Metodo para ir al App.config y leer el connectionString y usarlo para crear
        /// un objeto SqlConnection a partir de dicho connectionString
        /// </summary>
        /// <param name="obj_DAL_BD">Objeto de tipo cls_DAL_BaseDeDatos</param>
        public void getConnection(ref DbModel obj_DbModel)
        {
            try
            {
                obj_DbModel.sCadenaCNX = (App.Current as App).ConnectionString;
                obj_DbModel.CNX = new SqlConnection(obj_DbModel.sCadenaCNX);

                obj_DbModel.bBanderaError = false;
                obj_DbModel.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                obj_DbModel.sCadenaCNX = string.Empty;
                obj_DbModel.CNX = null;

                obj_DbModel.bBanderaError = true;
                obj_DbModel.sMsjError = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Metodo para abrir la conexion a la base de datos
        /// </summary>
        /// <param name="obj_DAL_BD">Objeto de tipo cls_DAL_BaseDeDatos</param>
        public void openConnection(ref DbModel obj_DbModel)
        {
            try
            {
                if (obj_DbModel.CNX != null)
                {
                    if (obj_DbModel.CNX.State == ConnectionState.Closed)
                    {
                        obj_DbModel.CNX.Open();
                        obj_DbModel.bBanderaError = false;
                        obj_DbModel.sMsjError = string.Empty;
                    }
                    else
                    {
                        obj_DbModel.bBanderaError = true;
                        obj_DbModel.sMsjError = "La conexion ya se encuentra abierta";
                    }
                }
            }
            catch (SqlException ex)
            {
                obj_DbModel.bBanderaError = true;
                obj_DbModel.sMsjError = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Metodo para cerrar la conexion a la base de datos
        /// </summary>
        /// <param name="obj_DAL_BD">Objeto de tipo cls_DAL_BaseDeDatos</param>
        public void closeConnection(ref DbModel obj_DbModel)
        {
            try
            {
                if (obj_DbModel.CNX != null)
                {
                    if (obj_DbModel.CNX.State == ConnectionState.Open)
                    {
                        obj_DbModel.CNX.Close();
                        obj_DbModel.CNX.Dispose();
                        obj_DbModel.bBanderaError = false;
                        obj_DbModel.sMsjError = string.Empty;
                    }
                    else
                    {
                        obj_DbModel.bBanderaError = true;
                        obj_DbModel.sMsjError = "La conexion ya se encuentra cerrada";
                    }
                }
            }
            catch (SqlException ex)
            {
                obj_DbModel.bBanderaError = true;
                obj_DbModel.sMsjError = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Metodo para Ejecutar los Listar y Filtrar de las Tablas
        /// </summary>
        /// <param name="sNombreTabla">Tabla a la cual se va a hacer la consulta</param>
        /// <param name="sNombreSP">Stored procedure que se llamara</param>
        /// <param name="obj_DAL_BD">Objeto de tipo cls_DAL_BaseDeDatos</param>
        /// <param name="obj_DAL_Genericos">Objeto de tipo cls_DAL_Genericos</param>
        public void executeFill(string sNombreTabla, string sNombreSP,
                                ref DbModel obj_DbModel/*, cls_DAL_Genericos obj_DAL_Genericos*/)
        {
            try
            {
                getConnection(ref obj_DbModel);
                openConnection(ref obj_DbModel);

                obj_DbModel.DAP = new SqlDataAdapter(sNombreSP, obj_DbModel.CNX);
                obj_DbModel.DAP.SelectCommand.CommandType = CommandType.StoredProcedure;

                foreach (DataRow dr in obj_DbModel.dtParametros.Rows)
                {
                    switch (dr["TipoDato"].ToString())
                    {
                        case "1":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Int).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "2":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Char).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "3":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "4":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "5":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NVarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "6":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.DateTime).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "7":
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Bit).Value = dr["Valor"].ToString();
                            }
                            break;
                        case "8":
                            {
                                obj_DbModel.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Decimal).Value = dr["Valor"].ToString();
                            }
                            break;
                        default:
                            {
                                obj_DbModel.DAP.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
                            }
                            break;
                    }
                }

                obj_DbModel.DAP.Fill(obj_DbModel.DS, sNombreTabla);

                obj_DbModel.bBanderaError = false;
                obj_DbModel.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                obj_DbModel.bBanderaError = true;
                obj_DbModel.sMsjError = ex.Message.ToString();
            }
            finally
            {
                if (obj_DbModel.CNX.State == ConnectionState.Open)
                {
                    obj_DbModel.CNX.Close();
                    obj_DbModel.CNX.Dispose();
                    obj_DbModel.bBanderaError = false;
                    obj_DbModel.sMsjError = string.Empty;
                }

            }
        }

        /// <summary>
        /// Metodo para Ejecutar eliminar, modificar e insertar datos de las Tablas cuya PK no sea IDENTITY
        /// </summary>
        /// <param name="sNombreSP">Stored procedure que se llamara</param>
        /// <param name="obj_DAL_BD">Objeto de tipo cls_DAL_BaseDeDatos</param>
        /// <param name="obj_DAL_Genericos">Objeto de tipo cls_DAL_Genericos</param>
        //public void executeNonQuery(string sNombreSP,
        //                            ref DbModel obj_DAL_BD, cls_DAL_Genericos obj_DAL_Genericos)
        //{
        //    try
        //    {
        //        traerConexion(ref obj_DAL_BD);
        //        abrirConexion(ref obj_DAL_BD);

        //        obj_DAL_BD.CMD = new SqlCommand(sNombreSP, obj_DAL_BD.CNX);
        //        obj_DAL_BD.CMD.CommandType = CommandType.StoredProcedure;

        //        foreach (DataRow dr in obj_DAL_Genericos.dtParametros.Rows)
        //        {
        //            switch (dr["TipoDato"].ToString())
        //            {
        //                case "1":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Int).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "2":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Char).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "3":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "4":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "5":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NVarChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "6":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.DateTime).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "7":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Bit).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "8":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Decimal).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                default:
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //            }
        //        }

        //        obj_DAL_BD.CMD.ExecuteNonQuery();

        //        obj_DAL_BD.bBanderaError = false;
        //        obj_DAL_BD.sMsjError = string.Empty;
        //    }
        //    catch (SqlException ex)
        //    {
        //        obj_DAL_BD.bBanderaError = true;
        //        obj_DAL_BD.sMsjError = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        if (obj_DAL_BD.CNX.State == ConnectionState.Open)
        //        {
        //            obj_DAL_BD.CNX.Close();
        //            obj_DAL_BD.CNX.Dispose();
        //            obj_DAL_BD.bBanderaError = false;
        //            obj_DAL_BD.sMsjError = string.Empty;
        //        }
        //    }
        //}

        /// <summary>
        /// Metodo para Ejecutar insertar datos de las Tablas cuya PK es IDENTITY
        /// </summary>
        /// <param name="sNombreSP">Stored procedure que se llamara</param>
        /// <param name="obj_DAL_BD">Objeto de tipo cls_DAL_BaseDeDatos</param>
        /// <param name="obj_DAL_Genericos">Objeto de tipo cls_DAL_Genericos</param>
        //public void executeScalar(string sNombreSP,
        //                            ref DbModel obj_DAL_BD, cls_DAL_Genericos obj_DAL_Genericos, ref string sResultado)
        //{
        //    try
        //    {
        //        traerConexion(ref obj_DAL_BD);
        //        abrirConexion(ref obj_DAL_BD);

        //        obj_DAL_BD.CMD = new SqlCommand(sNombreSP, obj_DAL_BD.CNX);
        //        obj_DAL_BD.CMD.CommandType = CommandType.StoredProcedure;

        //        foreach (DataRow dr in obj_DAL_Genericos.dtParametros.Rows)
        //        {
        //            switch (dr["TipoDato"].ToString())
        //            {
        //                case "1":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Int).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "2":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Char).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "3":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "4":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "5":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.NVarChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "6":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.DateTime).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "7":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Bit).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                case "8":
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.Decimal).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //                default:
        //                    {
        //                        obj_DAL_BD.CMD.Parameters.Add(dr["Nombre"].ToString(), SqlDbType.VarChar).Value = dr["Valor"].ToString();
        //                    }
        //                    break;
        //            }
        //        }

        //        sResultado = obj_DAL_BD.CMD.ExecuteScalar().ToString();

        //        obj_DAL_BD.bBanderaError = false;
        //        obj_DAL_BD.sMsjError = string.Empty;
        //    }
        //    catch (SqlException ex)
        //    {
        //        obj_DAL_BD.bBanderaError = true;
        //        obj_DAL_BD.sMsjError = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        if (obj_DAL_BD.CNX.State == ConnectionState.Open)
        //        {
        //            obj_DAL_BD.CNX.Close();
        //            obj_DAL_BD.CNX.Dispose();
        //            obj_DAL_BD.bBanderaError = false;
        //            obj_DAL_BD.sMsjError = string.Empty;
        //        }
        //    }
        //}

        /// <summary>
        /// Metodo para llenar el DT de parametros
        /// </summary>
        /// <param name="obj_DbModel">DT de parametros</param>
        public void generarDataTableParametros(ref DbModel obj_DbModel)
        {
            obj_DbModel.dtParametros = new DataTable("Parametros");

            DataColumn dcNombre = new DataColumn("Nombre");
            DataColumn dcTipoDato = new DataColumn("TipoDato");
            DataColumn dcValor = new DataColumn("Valor");

            obj_DbModel.dtParametros.Columns.Add(dcNombre);
            obj_DbModel.dtParametros.Columns.Add(dcTipoDato);
            obj_DbModel.dtParametros.Columns.Add(dcValor);
        }
    }
}
