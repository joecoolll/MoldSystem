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
    public class WorkNoRunningDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<WorkNoRunningBO> GetWorkNoRunning(WorkNoRunningBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT Id AS ID,StartWorkNo AS StartWorkNo,DataYear AS DataYear ");
                SQLText.AppendLine(" FROM WorkNoRunning ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.ID.HasValue)
                {
                    SQLText.AppendLine(" AND (Id = @Id) ");
                }
                if (!string.IsNullOrEmpty(criteria.StartWorkNo))
                {
                    SQLText.AppendLine(" AND (StartWorkNo LIKE @StartWorkNo) ");
                }
                if (criteria.DataYear.HasValue)
                {
                    SQLText.AppendLine(" AND (DataYear = @DataYear) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.ID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@Id", criteria.ID);
                        }
                        if (!string.IsNullOrEmpty(criteria.StartWorkNo))
                        {
                            comm.Parameters.AddWithValue("@StartWorkNo", "%" + criteria.StartWorkNo + "%");
                        }
                        if (criteria.DataYear.HasValue)
                        {
                            comm.Parameters.AddWithValue("@DataYear", criteria.DataYear);
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<WorkNoRunningBO> result = new List<WorkNoRunningBO>();
                            result = CommonUtils.ConvertToDoList<WorkNoRunningBO>(dt);
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

        public void InsertWorkNoRunning(WorkNoRunningBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO WorkNoRunning (Id,StartWorkNo,DataYear) ");
                SQLText.AppendLine(" VALUES (@Id,@StartWorkNo,@DataYear) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@Id", newData.ID);
                        comm.Parameters.AddWithValue("@StartWorkNo", newData.StartWorkNo);
                        comm.Parameters.AddWithValue("@DataYear", newData.DataYear);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWorkNoRunning(WorkNoRunningBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE WorkNoRunning ");
                SQLText.AppendLine(" SET Id = @NewId ");
                SQLText.AppendLine("    ,StartWorkNo = @StartWorkNo ");
                SQLText.AppendLine("    ,DataYear = @DataYear ");
                SQLText.AppendLine(" WHERE Id = @Id ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewId", updateData.NewID);
                        comm.Parameters.AddWithValue("@StartWorkNo", updateData.StartWorkNo);
                        comm.Parameters.AddWithValue("@DataYear", updateData.DataYear);
                        comm.Parameters.AddWithValue("@Id", updateData.ID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorkNoRunning(WorkNoRunningBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM WorkNoRunning ");
                SQLText.AppendLine(" WHERE Id = @Id ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@Id", deleteData.ID);

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
