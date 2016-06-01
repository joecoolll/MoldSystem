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
    public class Worklist3DA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<Worklist3BO> GetWorklist3(Worklist3BO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT workno AS WorkNo,partname AS PartName,clientname AS ClientName ");
                SQLText.AppendLine(" FROM worklist3 ");
                SQLText.AppendLine(" WHERE 1=1 ");
                
                if (!string.IsNullOrEmpty(criteria.WorkNo))
                {
                    SQLText.AppendLine(" AND (workno LIKE @workno) ");
                }
                if (!string.IsNullOrEmpty(criteria.PartName))
                {
                    SQLText.AppendLine(" AND (partname LIKE @partname) ");
                }
                if (!string.IsNullOrEmpty(criteria.ClientName))
                {
                    SQLText.AppendLine(" AND (clientname LIKE @clientname) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (!string.IsNullOrEmpty(criteria.WorkNo))
                        {
                            comm.Parameters.AddWithValue("@workno", criteria.WorkNo);
                        }
                        if (!string.IsNullOrEmpty(criteria.PartName))
                        {
                            comm.Parameters.AddWithValue("@partname", criteria.PartName);
                        }
                        if (!string.IsNullOrEmpty(criteria.ClientName))
                        {
                            comm.Parameters.AddWithValue("@clientname", criteria.ClientName);
                        }
                        

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<Worklist3BO> result = new List<Worklist3BO>();
                            result = CommonUtils.ConvertToDoList<Worklist3BO>(dt);
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

        public void InsertWorklist3(Worklist3BO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO worklist3(workno,partname,clientname) ");
                SQLText.AppendLine(" VALUES (@workno,@partname,@clientname) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@workno", newData.WorkNo);
                        comm.Parameters.AddWithValue("@partname", newData.PartName);
                        comm.Parameters.AddWithValue("@clientname", newData.ClientName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWorklist3(Worklist3BO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE worklist3 ");
                SQLText.AppendLine(" SET workno = @Newworkno ");
                SQLText.AppendLine("    ,partname = @partname ");
                SQLText.AppendLine("    ,clientname = @clientname ");
                SQLText.AppendLine(" WHERE workno = @workno ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@Newworkno", updateData.NewWorkNo);
                        comm.Parameters.AddWithValue("@partname", updateData.PartName);
                        comm.Parameters.AddWithValue("@clientname", updateData.ClientName);
                        comm.Parameters.AddWithValue("@workno", updateData.WorkNo);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorklist3(Worklist3BO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM worklist3 ");
                SQLText.AppendLine(" WHERE workno = @workno ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@workno", deleteData.WorkNo);

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
