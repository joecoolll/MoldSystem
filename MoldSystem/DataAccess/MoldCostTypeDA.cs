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
    public class MoldCostTypeDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<MoldCostTypeBO> GetMoldCostType(MoldCostTypeBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT MoldCostTypeId AS MoldCostTypeID,MoldCostTypeDetail AS MoldCostTypeDetail ");
                SQLText.AppendLine(" FROM MoldCostType ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.MoldCostTypeID.HasValue)
                {
                    SQLText.AppendLine(" AND (MoldCostTypeId = @MoldCostTypeId) ");
                }
                if (!string.IsNullOrEmpty(criteria.MoldCostTypeDetail))
                {
                    SQLText.AppendLine(" AND (MoldCostTypeDetail LIKE @MoldCostTypeDetail) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.MoldCostTypeID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@MoldCostTypeId", criteria.MoldCostTypeID);
                        }
                        if (!string.IsNullOrEmpty(criteria.MoldCostTypeDetail))
                        {
                            comm.Parameters.AddWithValue("@MoldCostTypeDetail", "%" + criteria.MoldCostTypeDetail + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldCostTypeBO> result = new List<MoldCostTypeBO>();
                            result = CommonUtils.ConvertToDoList<MoldCostTypeBO>(dt);
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

        public void InsertMoldCostType(MoldCostTypeBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldCostType (MoldCostTypeId,MoldCostTypeDetail) ");
                SQLText.AppendLine(" VALUES (@MoldCostTypeId,@MoldCostTypeDetail) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldCostTypeId", newData.MoldCostTypeID);
                        comm.Parameters.AddWithValue("@MoldCostTypeDetail", newData.MoldCostTypeDetail);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldCostType(MoldCostTypeBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldCostType ");
                SQLText.AppendLine(" SET MoldCostTypeId = @NewMoldCostTypeId ");
                SQLText.AppendLine("    ,MoldCostTypeDetail = @MoldCostTypeDetail ");
                SQLText.AppendLine(" WHERE MoldCostTypeId = @MoldCostTypeId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewMoldCostTypeId", updateData.NewMoldCostTypeID);
                        comm.Parameters.AddWithValue("@MoldCostTypeDetail", updateData.MoldCostTypeDetail);
                        comm.Parameters.AddWithValue("@MoldCostTypeId", updateData.MoldCostTypeID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldCostType(MoldCostTypeBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldCostType ");
                SQLText.AppendLine(" WHERE MoldCostTypeId = @MoldCostTypeId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldCostTypeId", deleteData.MoldCostTypeID);

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
