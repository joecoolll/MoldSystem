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
    public class MoldCostItemDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<MoldCostItemBO> GetMoldCostItem(MoldCostItemBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT MoldCostItemId AS MoldCostItemID,MoldCostItemDetail AS MoldCostItemDetail ");
                SQLText.AppendLine(" FROM MoldCostItem ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.MoldCostItemID.HasValue)
                {
                    SQLText.AppendLine(" AND (MoldCostItemId = @MoldCostItemId) ");
                }
                if (!string.IsNullOrEmpty(criteria.MoldCostItemDetail))
                {
                    SQLText.AppendLine(" AND (MoldCostItemDetail LIKE @MoldCostItemDetail) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.MoldCostItemID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@MoldCostItemId", criteria.MoldCostItemID);
                        }
                        if (!string.IsNullOrEmpty(criteria.MoldCostItemDetail))
                        {
                            comm.Parameters.AddWithValue("@MoldCostItemDetail", "%" + criteria.MoldCostItemDetail + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldCostItemBO> result = new List<MoldCostItemBO>();
                            result = CommonUtils.ConvertToDoList<MoldCostItemBO>(dt);
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

        public void InsertMoldCostItem(MoldCostItemBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldCostItem (MoldCostItemId,MoldCostItemDetail) ");
                SQLText.AppendLine(" VALUES (@MoldCostItemId,@MoldCostItemDetail) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldCostItemId", newData.MoldCostItemID);
                        comm.Parameters.AddWithValue("@MoldCostItemDetail", newData.MoldCostItemDetail);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldCostItem(MoldCostItemBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldCostItem ");
                SQLText.AppendLine(" SET MoldCostItemId = @NewMoldCostItemId ");
                SQLText.AppendLine("    ,MoldCostItemDetail = @MoldCostItemDetail ");
                SQLText.AppendLine(" WHERE MoldCostItemId = @MoldCostItemId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewMoldCostItemId", updateData.NewMoldCostItemID);
                        comm.Parameters.AddWithValue("@MoldCostItemDetail", updateData.MoldCostItemDetail);
                        comm.Parameters.AddWithValue("@MoldCostItemId", updateData.MoldCostItemID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldCostItem(MoldCostItemBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldCostItem ");
                SQLText.AppendLine(" WHERE MoldCostItemId = @MoldCostItemId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldCostItemId", deleteData.MoldCostItemID);

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
