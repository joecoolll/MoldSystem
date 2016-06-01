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
    public class MoldingMaterialDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();
        
        public List<MoldingMaterialBO> GetMoldingMat(MoldingMaterialBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT MoldingMatId AS MoldingMatID,MoldingMatName AS MoldingMatName ");
                SQLText.AppendLine(" FROM MoldingMat ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.MoldingMatID.HasValue)
                {
                    SQLText.AppendLine(" AND (MoldingMatId = @MoldingMatId) ");
                }
                if (!string.IsNullOrEmpty(criteria.MoldingMatName))
                {
                    SQLText.AppendLine(" AND (MoldingMatName LIKE @MoldingMatName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.MoldingMatID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@MoldingMatId", criteria.MoldingMatID);
                        }
                        if (!string.IsNullOrEmpty(criteria.MoldingMatName))
                        {
                            comm.Parameters.AddWithValue("@MoldingMatName", "%" + criteria.MoldingMatName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldingMaterialBO> result = new List<MoldingMaterialBO>();
                            result = CommonUtils.ConvertToDoList<MoldingMaterialBO>(dt);
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

        public void InsertMoldingMat(MoldingMaterialBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldingMat (MoldingMatId,MoldingMatName) ");
                SQLText.AppendLine(" VALUES (@MoldingMatId,@MoldingMatName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldingMatId", newData.MoldingMatID);
                        comm.Parameters.AddWithValue("@MoldingMatName", newData.MoldingMatName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldingMat(MoldingMaterialBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldingMat ");
                SQLText.AppendLine(" SET MoldingMatId = @NewMoldingMatId ");
                SQLText.AppendLine("    ,MoldingMatName = @MoldingMatName ");
                SQLText.AppendLine(" WHERE MoldingMatId = @MoldingMatId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewMoldingMatId", updateData.NewMoldingMatID);
                        comm.Parameters.AddWithValue("@MoldingMatName", updateData.MoldingMatName);
                        comm.Parameters.AddWithValue("@MoldingMatId", updateData.MoldingMatID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldingMat(MoldingMaterialBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldingMat ");
                SQLText.AppendLine(" WHERE MoldingMatId = @MoldingMatId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldingMatId", deleteData.MoldingMatID);

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
