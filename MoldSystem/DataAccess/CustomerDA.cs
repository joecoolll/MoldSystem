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
    public class CustomerDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<CustomerBO> GetCustomer(CustomerBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT CustomerId,CustomerCode,CustomerName ");
                SQLText.AppendLine(" FROM Customer ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.CustomerID.HasValue)
                {
                    SQLText.AppendLine(" AND (CustomerID = @CustomerID) ");
                }
                if (!string.IsNullOrEmpty(criteria.CustomerCode))
                {
                    SQLText.AppendLine(" AND (CustomerCode LIKE @CustomerCode) ");
                }
                if (!string.IsNullOrEmpty(criteria.CustomerName))
                {
                    SQLText.AppendLine(" AND (CustomerName LIKE @CustomerName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.CustomerID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@CustomerID", criteria.CustomerID);
                        }
                        if (!string.IsNullOrEmpty(criteria.CustomerCode))
                        {
                            comm.Parameters.AddWithValue("@CustomerCode", "%" + criteria.CustomerCode + "%");
                        }
                        if (!string.IsNullOrEmpty(criteria.CustomerName))
                        {
                            comm.Parameters.AddWithValue("@CustomerName", "%" + criteria.CustomerName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<CustomerBO> result = new List<CustomerBO>();
                            result = CommonUtils.ConvertToDoList<CustomerBO>(dt);
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

        public void InsertCustomer(CustomerBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO Customer (CustomerId,CustomerCode,CustomerName) ");
                SQLText.AppendLine(" VALUES (@CustomerId,@CustomerCode,@CustomerName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@CustomerID", newData.CustomerID);
                        comm.Parameters.AddWithValue("@CustomerCode", newData.CustomerName);
                        comm.Parameters.AddWithValue("@CustomerName", newData.CustomerName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCustomer(CustomerBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE Customer ");
                SQLText.AppendLine(" SET CustomerID = @NewCustomerID ");
                SQLText.AppendLine("    ,CustomerCode = @CustomerCode ");
                SQLText.AppendLine("    ,CustomerName = @CustomerName ");
                SQLText.AppendLine(" WHERE CustomerId = @CustomerId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewCustomerID", updateData.NewCustomerID);
                        comm.Parameters.AddWithValue("@CustomerCode", updateData.CustomerName);
                        comm.Parameters.AddWithValue("@CustomerName", updateData.CustomerName);
                        comm.Parameters.AddWithValue("@CustomerID", updateData.CustomerID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCustomer(CustomerBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM Customer ");
                SQLText.AppendLine(" WHERE CustomerId = @CustomerId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;
                        
                        comm.Parameters.AddWithValue("@CustomerID", deleteData.CustomerID);

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
