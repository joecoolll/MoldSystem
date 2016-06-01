using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BussinessObject;
using Common;

namespace DataAccess
{
    public class GateSystemDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<GateSystemBO> GetGateSys(GateSystemBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT GateSysId AS GateSysID,GateSysName AS GateSysName ");
                SQLText.AppendLine(" FROM GateSystem ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.GateSysID.HasValue)
                {
                    SQLText.AppendLine(" AND (GateSysId = @GateSysId) ");
                }
                if (!string.IsNullOrEmpty(criteria.GateSysName))
                {
                    SQLText.AppendLine(" AND (GateSysName LIKE @GateSysName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.GateSysID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@GateSysId", criteria.GateSysID);
                        }
                        if (!string.IsNullOrEmpty(criteria.GateSysName))
                        {
                            comm.Parameters.AddWithValue("@GateSysName", "%" + criteria.GateSysName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<GateSystemBO> result = new List<GateSystemBO>();
                            result = CommonUtils.ConvertToDoList<GateSystemBO>(dt);
                            return result;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertGateSys(GateSystemBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO GateSystem (GateSysId,GateSysName) ");
                SQLText.AppendLine(" VALUES (@GateSysId,@GateSysName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@GateSysId", newData.GateSysID);
                        comm.Parameters.AddWithValue("@GateSysName", newData.GateSysName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateGateSys(GateSystemBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE GateSystem ");
                SQLText.AppendLine(" SET GateSysId = @NewGateSysId ");
                SQLText.AppendLine("    ,GateSysName = @GateSysName ");
                SQLText.AppendLine(" WHERE GateSysId = @GateSysId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewGateSysId", updateData.NewGateSysID);
                        comm.Parameters.AddWithValue("@GateSysName", updateData.GateSysName);
                        comm.Parameters.AddWithValue("@GateSysId", updateData.GateSysID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteGateSys(GateSystemBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM GateSystem ");
                SQLText.AppendLine(" WHERE GateSysId = @GateSysId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@GateSysId", deleteData.GateSysID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
