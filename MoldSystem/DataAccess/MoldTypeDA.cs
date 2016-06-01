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
    public class MoldTypeDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<MoldTypeBO> GetMoldType(MoldTypeBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT MoldTypeId AS MoldTypeID,MoldTypeDetail AS MoldTypeDetail ");
                SQLText.AppendLine(" FROM MoldType ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.MoldTypeID.HasValue)
                {
                    SQLText.AppendLine(" AND (MoldTypeId = @MoldTypeId) ");
                }
                if (!string.IsNullOrEmpty(criteria.MoldTypeDetail))
                {
                    SQLText.AppendLine(" AND (MoldTypeDetail LIKE @MoldTypeDetail) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.MoldTypeID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@MoldTypeId", criteria.MoldTypeID);
                        }
                        if (!string.IsNullOrEmpty(criteria.MoldTypeDetail))
                        {
                            comm.Parameters.AddWithValue("@MoldTypeDetail", "%" + criteria.MoldTypeDetail + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldTypeBO> result = new List<MoldTypeBO>();
                            result = CommonUtils.ConvertToDoList<MoldTypeBO>(dt);
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

        public void InsertMoldType(MoldTypeBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldType (MoldTypeID,MoldTypeDetail) ");
                SQLText.AppendLine(" VALUES (@MoldTypeID,@MoldTypeDetail) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldTypeId", newData.MoldTypeID);
                        comm.Parameters.AddWithValue("@MoldTypeDetail", newData.MoldTypeDetail);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldType(MoldTypeBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldType ");
                SQLText.AppendLine(" SET MoldTypeId = @NewMoldTypeId ");
                SQLText.AppendLine("    ,MoldTypeDetail = @MoldTypeDetail ");
                SQLText.AppendLine(" WHERE MoldTypeId = @MoldTypeId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewMoldTypeId", updateData.NewMoldTypeID);
                        comm.Parameters.AddWithValue("@MoldTypeDetail", updateData.MoldTypeDetail);
                        comm.Parameters.AddWithValue("@MoldTypeId", updateData.MoldTypeID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldType(MoldTypeBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldType ");
                SQLText.AppendLine(" WHERE MoldTypeId = @MoldTypeId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldTypeId", deleteData.MoldTypeID);

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
