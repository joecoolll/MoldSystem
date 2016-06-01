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
    public class WorkingGroupDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<WorkingGroupBO> GetWorkGroup(WorkingGroupBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT WorkGroupId AS WorkGroupID,WorkGroupName AS WorkGroupName ");
                SQLText.AppendLine(" FROM WorkingGroup ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.WorkGroupID.HasValue)
                {
                    SQLText.AppendLine(" AND (WorkGroupId = @WorkGroupId) ");
                }
                if (!string.IsNullOrEmpty(criteria.WorkGroupName))
                {
                    SQLText.AppendLine(" AND (WorkGroupName LIKE @WorkGroupName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.WorkGroupID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@WorkGroupId", criteria.WorkGroupID);
                        }
                        if (!string.IsNullOrEmpty(criteria.WorkGroupName))
                        {
                            comm.Parameters.AddWithValue("@WorkGroupName", "%" + criteria.WorkGroupName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<WorkingGroupBO> result = new List<WorkingGroupBO>();
                            result = CommonUtils.ConvertToDoList<WorkingGroupBO>(dt);
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

        public void InsertWorkGroup(WorkingGroupBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO WorkingGroup (WorkGroupId,WorkGroupName) ");
                SQLText.AppendLine(" VALUES (@WorkGroupId,@WorkGroupName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@WorkGroupId", newData.WorkGroupID);
                        comm.Parameters.AddWithValue("@WorkGroupName", newData.WorkGroupName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWorkGroup(WorkingGroupBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE WorkingGroup ");
                SQLText.AppendLine(" SET WorkGroupId = @NewWorkGroupId ");
                SQLText.AppendLine("    ,WorkGroupName = @WorkGroupName ");
                SQLText.AppendLine(" WHERE WorkGroupId = @WorkGroupId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewWorkGroupId", updateData.NewWorkGroupID);
                        comm.Parameters.AddWithValue("@WorkGroupName", updateData.WorkGroupName);
                        comm.Parameters.AddWithValue("@WorkGroupId", updateData.WorkGroupID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorkGroup(WorkingGroupBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM WorkingGroup ");
                SQLText.AppendLine(" WHERE WorkGroupId = @WorkGroupId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@WorkGroupId", deleteData.WorkGroupID);

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
