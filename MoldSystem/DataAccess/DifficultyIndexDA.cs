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
    public class DifficultyIndexDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<DifficultyIndexBO> GetDiffiIndex(DifficultyIndexBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT DiffiIndexId AS DiffiIndexID,DiffiIndexName AS DiffiIndexName ");
                SQLText.AppendLine(" FROM DifficultyIndex ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.DiffiIndexID.HasValue)
                {
                    SQLText.AppendLine(" AND (DiffiIndexId = @DiffiIndexId) ");
                }
                if (!string.IsNullOrEmpty(criteria.DiffiIndexName))
                {
                    SQLText.AppendLine(" AND (DiffiIndexName LIKE @DiffiIndexName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.DiffiIndexID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@DiffiIndexId", criteria.DiffiIndexID);
                        }
                        if (!string.IsNullOrEmpty(criteria.DiffiIndexName))
                        {
                            comm.Parameters.AddWithValue("@DiffiIndexName", "%" + criteria.DiffiIndexName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<DifficultyIndexBO> result = new List<DifficultyIndexBO>();
                            result = CommonUtils.ConvertToDoList<DifficultyIndexBO>(dt);
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

        public void InsertDiffiIndex(DifficultyIndexBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO DifficultyIndex (DiffiIndexId,DiffiIndexName) ");
                SQLText.AppendLine(" VALUES (@DiffiIndexId,@DiffiIndexName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@DiffiIndexId", newData.DiffiIndexID);
                        comm.Parameters.AddWithValue("@DiffiIndexName", newData.DiffiIndexName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDiffiIndex(DifficultyIndexBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE DifficultyIndex ");
                SQLText.AppendLine(" SET DiffiIndexId = @NewDiffiIndexId ");
                SQLText.AppendLine("    ,DiffiIndexName = @DiffiIndexName ");
                SQLText.AppendLine(" WHERE DiffiIndexId = @DiffiIndexId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewDiffiIndexId", updateData.NewDiffiIndexID);
                        comm.Parameters.AddWithValue("@DiffiIndexName", updateData.DiffiIndexName);
                        comm.Parameters.AddWithValue("@DiffiIndexId", updateData.DiffiIndexID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDiffiIndex(DifficultyIndexBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM DifficultyIndex ");
                SQLText.AppendLine(" WHERE DiffiIndexId = @DiffiIndexId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@DiffiIndexId", deleteData.DiffiIndexID);

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
