using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace DATA
{
    public class Players
    {
        public static DataTable GetPlayers()
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_GET_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@CURSOR", SqlDbType.).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
            return dt;
        }
        public static void AddPlayer(string Name, string LastName, decimal MoneyAccount)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_ADD_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;            
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@VLastName", SqlDbType.VarChar).Value = LastName;
                cmd.Parameters.Add("@VMoneyAccount", SqlDbType.Decimal).Value = MoneyAccount;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
        }
        public static void UpdatePlayer(int IdPlayer, string Name, string LastName, decimal MoneyAccount)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VIdPlayer", SqlDbType.VarChar).Value = IdPlayer;
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@VLastName", SqlDbType.VarChar).Value = LastName;
                cmd.Parameters.Add("@VMoneyAccount", SqlDbType.VarChar).Value = MoneyAccount;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
        }
        public static void DeletePlayer(int IdPlayer)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_DELETE_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VIdPlayer", SqlDbType.Int).Value = IdPlayer;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
        }
        public static void CatchException(Exception ex)
        {
                Tools.WriteLog(ex);      
        }
    }
}
