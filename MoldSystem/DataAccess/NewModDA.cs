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
    public class NewModDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<NewModBO> GetNewMod(NewModBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT NewModId AS NewModID,NewModDetail AS NewModDetail ");
                SQLText.AppendLine(" FROM NewMod ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.NewModID.HasValue)
                {
                    SQLText.AppendLine(" AND (NewModId = @NewModId) ");
                }
                if (!string.IsNullOrEmpty(criteria.NewModDetail))
                {
                    SQLText.AppendLine(" AND (NewModDetail LIKE @NewModDetail) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.NewModID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@NewModId", criteria.NewModID);
                        }
                        if (!string.IsNullOrEmpty(criteria.NewModDetail))
                        {
                            comm.Parameters.AddWithValue("@NewModDetail", "%" + criteria.NewModDetail + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<NewModBO> result = new List<NewModBO>();
                            result = CommonUtils.ConvertToDoList<NewModBO>(dt);
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

        public void InsertNewMod(NewModBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO NewMod (NewModId,NewModDetail) ");
                SQLText.AppendLine(" VALUES (@NewModId,@NewModDetail) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewModId", newData.NewModID);
                        comm.Parameters.AddWithValue("@NewModDetail", newData.NewModDetail);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateNewMod(NewModBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE NewMod ");
                SQLText.AppendLine(" SET NewModId = @NewNewModId ");
                SQLText.AppendLine("    ,NewModDetail = @NewModDetail ");
                SQLText.AppendLine(" WHERE NewModId = @NewModId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewNewModId", updateData.NewNewModID);
                        comm.Parameters.AddWithValue("@NewModDetail", updateData.NewModDetail);
                        comm.Parameters.AddWithValue("@NewModId", updateData.NewModID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteNewMod(NewModBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM NewMod ");
                SQLText.AppendLine(" WHERE NewModId = @NewModId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewModId", deleteData.NewModID);

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
