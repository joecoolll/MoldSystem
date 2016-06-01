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
    public class MoldStructureDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<MoldStructureBO> GetMoldStructure(MoldStructureBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT MoldStructureId AS MoldStructureID,MoldStructureName AS MoldStructureName ");
                SQLText.AppendLine(" FROM MoldStructure ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.MoldStructureID.HasValue)
                {
                    SQLText.AppendLine(" AND (MoldStructureId = @MoldStructureId) ");
                }
                if (!string.IsNullOrEmpty(criteria.MoldStructureName))
                {
                    SQLText.AppendLine(" AND (MoldStructureName LIKE @MoldStructureName) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.MoldStructureID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@MoldStructureId", criteria.MoldStructureID);
                        }
                        if (!string.IsNullOrEmpty(criteria.MoldStructureName))
                        {
                            comm.Parameters.AddWithValue("@MoldStructureName", "%" + criteria.MoldStructureName + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<MoldStructureBO> result = new List<MoldStructureBO>();
                            result = CommonUtils.ConvertToDoList<MoldStructureBO>(dt);
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

        public void InsertMoldStructure(MoldStructureBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO MoldStructure (MoldStructureId,MoldStructureName) ");
                SQLText.AppendLine(" VALUES (@MoldStructureId,@MoldStructureName) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldStructureId", newData.MoldStructureID);
                        comm.Parameters.AddWithValue("@MoldStructureName", newData.MoldStructureName);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldStructure(MoldStructureBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE MoldStructure ");
                SQLText.AppendLine(" SET MoldStructureId = @NewMoldStructureId ");
                SQLText.AppendLine("    ,MoldStructureName = @MoldStructureName ");
                SQLText.AppendLine(" WHERE MoldStructureId = @MoldStructureId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewMoldStructureId", updateData.NewMoldStructureID);
                        comm.Parameters.AddWithValue("@MoldStructureName", updateData.MoldStructureName);
                        comm.Parameters.AddWithValue("@MoldStructureId", updateData.MoldStructureID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldStructure(MoldStructureBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM MoldStructure ");
                SQLText.AppendLine(" WHERE MoldStructureId = @MoldStructureId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@MoldStructureId", deleteData.MoldStructureID);

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
