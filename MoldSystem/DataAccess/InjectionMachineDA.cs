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
    public class InjectionMachineDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<InjectionMachineBO> GetInjectionMach(InjectionMachineBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT InjectMachId AS InjectionMachID,InjectMachName AS InjectionMachName ");
                SQLText.AppendLine(" FROM InjectionMachine ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.InjectionMachID.HasValue)
                {
                    SQLText.AppendLine(" AND (InjectMachId = @InjectionMachId) ");
                }
                if (!string.IsNullOrEmpty(criteria.InjectionMachName))
                {
                    SQLText.AppendLine(" AND (InjectMachName LIKE @InjectionMachName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.InjectionMachID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@InjectionMachId", criteria.InjectionMachID);
                        }
                        if (!string.IsNullOrEmpty(criteria.InjectionMachName))
                        {
                            comm.Parameters.AddWithValue("@InjectionMachName", "%" + criteria.InjectionMachName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<InjectionMachineBO> result = new List<InjectionMachineBO>();
                            result = CommonUtils.ConvertToDoList<InjectionMachineBO>(dt);
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

        public void InsertInjectionMach(InjectionMachineBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO InjectionMachine (InjectMachId,InjectMachName) ");
                SQLText.AppendLine(" VALUES (@InjectionMachId,@InjectionMachName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@InjectionMachId", newData.InjectionMachID);
                        comm.Parameters.AddWithValue("@InjectionMachName", newData.InjectionMachName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateInjectionMach(InjectionMachineBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE InjectionMachine ");
                SQLText.AppendLine(" SET InjectMachId = @NewInjectionMachId ");
                SQLText.AppendLine("    ,InjectMachName = @InjectionMachName ");
                SQLText.AppendLine(" WHERE InjectMachId = @InjectionMachId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewInjectionMachId", updateData.NewInjectionMachID);
                        comm.Parameters.AddWithValue("@InjectionMachName", updateData.InjectionMachName);
                        comm.Parameters.AddWithValue("@InjectionMachId", updateData.InjectionMachID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteInjectionMach(InjectionMachineBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM InjectionMachine ");
                SQLText.AppendLine(" WHERE InjectMachId = @InjectionMachId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@InjectionMachId", deleteData.InjectionMachID);

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
