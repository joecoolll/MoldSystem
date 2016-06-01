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
    public class StaffGroupDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<StaffGroupBO> GetStaffGroup(StaffGroupBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT StaffGroupId AS StaffGroupID,StaffGroupName AS StaffGroupName ");
                SQLText.AppendLine(" FROM StaffGroup ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.StaffGroupID.HasValue)
                {
                    SQLText.AppendLine(" AND (StaffGroupId = @StaffGroupId) ");
                }
                if (!string.IsNullOrEmpty(criteria.StaffGroupName))
                {
                    SQLText.AppendLine(" AND (StaffGroupName LIKE @StaffGroupName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.StaffGroupID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@StaffGroupId", criteria.StaffGroupID);
                        }
                        if (!string.IsNullOrEmpty(criteria.StaffGroupName))
                        {
                            comm.Parameters.AddWithValue("@StaffGroupName", "%" + criteria.StaffGroupName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<StaffGroupBO> result = new List<StaffGroupBO>();
                            result = CommonUtils.ConvertToDoList<StaffGroupBO>(dt);
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

        public void InsertStaffGroup(StaffGroupBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO StaffGroup (StaffGroupID,StaffGroupName) ");
                SQLText.AppendLine(" VALUES (@StaffGroupID,@StaffGroupName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@StaffGroupId", newData.StaffGroupID);
                        comm.Parameters.AddWithValue("@StaffGroupName", newData.StaffGroupName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateStaffGroup(StaffGroupBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE StaffGroup ");
                SQLText.AppendLine(" SET StaffGroupId = @NewStaffGroupId ");
                SQLText.AppendLine("    ,StaffGroupName = @StaffGroupName ");
                SQLText.AppendLine(" WHERE StaffGroupId = @StaffGroupId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewStaffGroupId", updateData.NewStaffGroupID);
                        comm.Parameters.AddWithValue("@StaffGroupName", updateData.StaffGroupName);
                        comm.Parameters.AddWithValue("@StaffGroupId", updateData.StaffGroupID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteStaffGroup(StaffGroupBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM StaffGroup ");
                SQLText.AppendLine(" WHERE StaffGroupId = @StaffGroupId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@StaffGroupId", deleteData.StaffGroupID);

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
