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
    public class RelativeClientDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<RelativeClientBO> GetRelativeClient(RelativeClientBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT RClientId AS RelativeClientID,RClientName AS RelativeClientName ");
                SQLText.AppendLine(" FROM RelativeClient ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.RelativeClientID.HasValue)
                {
                    SQLText.AppendLine(" AND (RClientId = @RClientId) ");
                }
                if (!string.IsNullOrEmpty(criteria.RelativeClientName))
                {
                    SQLText.AppendLine(" AND (RClientName LIKE @RClientName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.RelativeClientID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@RClientId", criteria.RelativeClientID);
                        }
                        if (!string.IsNullOrEmpty(criteria.RelativeClientName))
                        {
                            comm.Parameters.AddWithValue("@RClientName", "%" + criteria.RelativeClientName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<RelativeClientBO> result = new List<RelativeClientBO>();
                            result = CommonUtils.ConvertToDoList<RelativeClientBO>(dt);
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

        public void InsertRelativeClient(RelativeClientBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO RelativeClient (RClientId,RClientName) ");
                SQLText.AppendLine(" VALUES (@RClientId,@RClientName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@RClientId", newData.RelativeClientID);
                        comm.Parameters.AddWithValue("@RClientName", newData.RelativeClientName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateRelativeClient(RelativeClientBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE RelativeClient ");
                SQLText.AppendLine(" SET RClientId = @NewRClientId ");
                SQLText.AppendLine("    ,RClientName = @RClientName ");
                SQLText.AppendLine(" WHERE RClientId = @RClientId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewRClientId", updateData.NewRelativeClientID);
                        comm.Parameters.AddWithValue("@RClientName", updateData.RelativeClientName);
                        comm.Parameters.AddWithValue("@RClientId", updateData.RelativeClientID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRelativeClient(RelativeClientBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM RelativeClient ");
                SQLText.AppendLine(" WHERE RClientId = @RClientId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@RClientId", deleteData.RelativeClientID);

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
