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
    public class EndUserDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<EndUserBO> GetEndUser(EndUserBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT EndUserId AS EndUserID,EndUserName AS EndUserName ");
                SQLText.AppendLine(" FROM EndUser ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.EndUserID.HasValue)
                {
                    SQLText.AppendLine(" AND (EndUserId = @EndUserId) ");
                }
                if (!string.IsNullOrEmpty(criteria.EndUserName))
                {
                    SQLText.AppendLine(" AND (EndUserName LIKE @EndUserName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.EndUserID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@EndUserId", criteria.EndUserID);
                        }
                        if (!string.IsNullOrEmpty(criteria.EndUserName))
                        {
                            comm.Parameters.AddWithValue("@EndUserName", "%" + criteria.EndUserName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<EndUserBO> result = new List<EndUserBO>();
                            result = CommonUtils.ConvertToDoList<EndUserBO>(dt);
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

        public void InsertEndUser(EndUserBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO EndUser (EndUserId,EndUserName) ");
                SQLText.AppendLine(" VALUES (@EndUserId,@EndUserName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@EndUserId", newData.EndUserID);
                        comm.Parameters.AddWithValue("@EndUserName", newData.EndUserName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEndUser(EndUserBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE EndUser ");
                SQLText.AppendLine(" SET EndUserId = @NewEndUserId ");
                SQLText.AppendLine("    ,EndUserName = @EndUserName ");
                SQLText.AppendLine(" WHERE EndUserId = @EndUserId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewEndUserId", updateData.NewEndUserID);
                        comm.Parameters.AddWithValue("@EndUserName", updateData.EndUserName);
                        comm.Parameters.AddWithValue("@EndUserId", updateData.EndUserID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEndUser(EndUserBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM EndUser ");
                SQLText.AppendLine(" WHERE EndUserId = @EndUserId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@EndUserId", deleteData.EndUserID);

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
