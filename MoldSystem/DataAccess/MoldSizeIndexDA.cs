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
    public class MoldSizeIndexDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<MoldSizeIndexBO> GetSizeIndex(MoldSizeIndexBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT SizeIndexId AS SizeIndexID,SizeIndexName AS SizeIndexName ");
                SQLText.AppendLine(" FROM MoldSizeIndex ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.SizeIndexID.HasValue)
                {
                    SQLText.AppendLine(" AND (SizeIndexId = @SizeIndexId) ");
                }
                if (!string.IsNullOrEmpty(criteria.SizeIndexName))
                {
                    SQLText.AppendLine(" AND (SizeIndexName LIKE @SizeIndexName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.SizeIndexID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@SizeIndexId", criteria.SizeIndexID);
                        }
                        if (!string.IsNullOrEmpty(criteria.SizeIndexName))
                        {
                            comm.Parameters.AddWithValue("@SizeIndexName", "%" + criteria.SizeIndexName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldSizeIndexBO> result = new List<MoldSizeIndexBO>();
                            result = CommonUtils.ConvertToDoList<MoldSizeIndexBO>(dt);
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

        public void InsertSizeIndex(MoldSizeIndexBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldSizeIndex (SizeIndexId,SizeIndexName) ");
                SQLText.AppendLine(" VALUES (@SizeIndexId,@SizeIndexName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@SizeIndexId", newData.SizeIndexID);
                        comm.Parameters.AddWithValue("@SizeIndexName", newData.SizeIndexName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSizeIndex(MoldSizeIndexBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldSizeIndex ");
                SQLText.AppendLine(" SET SizeIndexId = @NewSizeIndexId ");
                SQLText.AppendLine("    ,SizeIndexName = @SizeIndexName ");
                SQLText.AppendLine(" WHERE SizeIndexId = @SizeIndexId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewSizeIndexId", updateData.NewSizeIndexID);
                        comm.Parameters.AddWithValue("@SizeIndexName", updateData.SizeIndexName);
                        comm.Parameters.AddWithValue("@SizeIndexId", updateData.SizeIndexID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSizeIndex(MoldSizeIndexBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldSizeIndex ");
                SQLText.AppendLine(" WHERE SizeIndexId = @SizeIndexId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@SizeIndexId", deleteData.SizeIndexID);

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
