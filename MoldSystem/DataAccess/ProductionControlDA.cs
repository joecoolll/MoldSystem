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
    public class ProductionControlDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<ProductionControlBO> GetProdCon(ProductionControlBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT ProdConId AS ProdConID,ProdConName AS ProdConName ");
                SQLText.AppendLine(" FROM ProdControl ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.ProdConID.HasValue)
                {
                    SQLText.AppendLine(" AND (ProdConId = @ProdConId) ");
                }
                if (!string.IsNullOrEmpty(criteria.ProdConName))
                {
                    SQLText.AppendLine(" AND (ProdConName LIKE @ProdConName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.ProdConID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@ProdConId", criteria.ProdConID);
                        }
                        if (!string.IsNullOrEmpty(criteria.ProdConName))
                        {
                            comm.Parameters.AddWithValue("@ProdConName", "%" + criteria.ProdConName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<ProductionControlBO> result = new List<ProductionControlBO>();
                            result = CommonUtils.ConvertToDoList<ProductionControlBO>(dt);
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

        public void InsertProdCon(ProductionControlBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO ProdControl (ProdConId,ProdConName) ");
                SQLText.AppendLine(" VALUES (@ProdConId,@ProdConName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@ProdConId", newData.ProdConID);
                        comm.Parameters.AddWithValue("@ProdConName", newData.ProdConName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProdCon(ProductionControlBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE ProdControl ");
                SQLText.AppendLine(" SET ProdConId = @NewProdConId ");
                SQLText.AppendLine("    ,ProdConName = @ProdConName ");
                SQLText.AppendLine(" WHERE ProdConId = @ProdConId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewProdConId", updateData.NewProdConID);
                        comm.Parameters.AddWithValue("@ProdConName", updateData.ProdConName);
                        comm.Parameters.AddWithValue("@ProdConId", updateData.ProdConID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProdCon(ProductionControlBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM ProdControl ");
                SQLText.AppendLine(" WHERE ProdConId = @ProdConId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@ProdConId", deleteData.ProdConID);

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
