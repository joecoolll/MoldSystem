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
    public class NoCavitiesDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<NoCavitiesBO> GetNoCav(NoCavitiesBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT NoCavId AS NoCavID,NoCavDetail AS NoCavDetail ");
                SQLText.AppendLine(" FROM NoCavities ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.NoCavID.HasValue)
                {
                    SQLText.AppendLine(" AND (NoCavId = @NoCavId) ");
                }
                if (!string.IsNullOrEmpty(criteria.NoCavDetail))
                {
                    SQLText.AppendLine(" AND (NoCavDetail LIKE @NoCavDetail) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.NoCavID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@NoCavId", criteria.NoCavID);
                        }
                        if (!string.IsNullOrEmpty(criteria.NoCavDetail))
                        {
                            comm.Parameters.AddWithValue("@NoCavDetail", "%" + criteria.NoCavDetail + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<NoCavitiesBO> result = new List<NoCavitiesBO>();
                            result = CommonUtils.ConvertToDoList<NoCavitiesBO>(dt);
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

        public void InsertNoCav(NoCavitiesBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO NoCavities (NoCavId,NoCavDetail) ");
                SQLText.AppendLine(" VALUES (@NoCavId,@NoCavDetail) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NoCavId", newData.NoCavID);
                        comm.Parameters.AddWithValue("@NoCavDetail", newData.NoCavDetail);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateNoCav(NoCavitiesBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE NoCavities ");
                SQLText.AppendLine(" SET NoCavId = @NewNoCavId ");
                SQLText.AppendLine("    ,NoCavDetail = @NoCavDetail ");
                SQLText.AppendLine(" WHERE NoCavId = @NoCavId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewNoCavId", updateData.NewNoCavID);
                        comm.Parameters.AddWithValue("@NoCavDetail", updateData.NoCavDetail);
                        comm.Parameters.AddWithValue("@NoCavId", updateData.NoCavID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteNoCav(NoCavitiesBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM NoCavities ");
                SQLText.AppendLine(" WHERE NoCavId = @NoCavId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NoCavId", deleteData.NoCavID);

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
