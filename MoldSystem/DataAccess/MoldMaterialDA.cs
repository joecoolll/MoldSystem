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
    public class MoldMaterialDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<MoldMaterialBO> GetMoldMat(MoldMaterialBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT MoldMatId AS MoldMatID,MoldMatName AS MoldMatName ");
                SQLText.AppendLine(" FROM MoldMaterial ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.MoldMatID.HasValue)
                {
                    SQLText.AppendLine(" AND (MoldMatId = @MoldMatId) ");
                }
                if (!string.IsNullOrEmpty(criteria.MoldMatName))
                {
                    SQLText.AppendLine(" AND (MoldMatName LIKE @MoldMatName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.MoldMatID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@MoldMatId", criteria.MoldMatID);
                        }
                        if (!string.IsNullOrEmpty(criteria.MoldMatName))
                        {
                            comm.Parameters.AddWithValue("@MoldMatName", "%" + criteria.MoldMatName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldMaterialBO> result = new List<MoldMaterialBO>();
                            result = CommonUtils.ConvertToDoList<MoldMaterialBO>(dt);
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

        public void InsertMoldMat(MoldMaterialBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldMaterial (MoldMatId,MoldMatName) ");
                SQLText.AppendLine(" VALUES (@MoldMatId,@MoldMatName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldMatId", newData.MoldMatID);
                        comm.Parameters.AddWithValue("@MoldMatName", newData.MoldMatName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldMat(MoldMaterialBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldMaterial ");
                SQLText.AppendLine(" SET MoldMatId = @NewMoldMatId ");
                SQLText.AppendLine("    ,MoldMatName = @MoldMatName ");
                SQLText.AppendLine(" WHERE MoldMatId = @MoldMatId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewMoldMatId", updateData.NewMoldMatID);
                        comm.Parameters.AddWithValue("@MoldMatName", updateData.MoldMatName);
                        comm.Parameters.AddWithValue("@MoldMatId", updateData.MoldMatID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldMat(MoldMaterialBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldMaterial ");
                SQLText.AppendLine(" WHERE MoldMatId = @MoldMatId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldMatId", deleteData.MoldMatID);

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
