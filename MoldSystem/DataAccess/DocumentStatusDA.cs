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
    public class DocumentStatusDA
    {
        string connString = ConfigurationManager.ConnectionStrings["Myconstr"].ToString();

        public List<DocumentStatusBO> GetDocumentStatus(DocumentStatusBO criteria)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" SELECT DocumentStatusId AS DocumentStatusID,DocumentStatusDetail AS DocumentStatusDetail ");
                SQLText.AppendLine(" FROM DocumentStatus ");
                SQLText.AppendLine(" WHERE 1=1 ");

                if (criteria.DocumentStatusID.HasValue)
                {
                    SQLText.AppendLine(" AND (DocumentStatusId = @DocumentStatusId) ");
                }
                if (!string.IsNullOrEmpty(criteria.DocumentStatusDetail))
                {
                    SQLText.AppendLine(" AND (DocumentStatusDetail LIKE @DocumentStatusDetail) ");
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        if (criteria.DocumentStatusID.HasValue)
                        {
                            comm.Parameters.AddWithValue("@DocumentStatusId", criteria.DocumentStatusID);
                        }
                        if (!string.IsNullOrEmpty(criteria.DocumentStatusDetail))
                        {
                            comm.Parameters.AddWithValue("@DocumentStatusDetail", "%" + criteria.DocumentStatusDetail + "%");
                        }

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            List<DocumentStatusBO> result = new List<DocumentStatusBO>();
                            result = CommonUtils.ConvertToDoList<DocumentStatusBO>(dt);
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

        public void InsertDocumentStatus(DocumentStatusBO newData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" INSERT INTO DocumentStatus (DocumentStatusId,DocumentStatusDetail) ");
                SQLText.AppendLine(" VALUES (@DocumentStatusId,@DocumentStatusDetail) ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@DocumentStatusId", newData.DocumentStatusID);
                        comm.Parameters.AddWithValue("@DocumentStatusDetail", newData.DocumentStatusDetail);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDocumentStatus(DocumentStatusBO updateData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" UPDATE DocumentStatus ");
                SQLText.AppendLine(" SET DocumentStatusId = @NewDocumentStatusId ");
                SQLText.AppendLine("    ,DocumentStatusDetail = @DocumentStatusDetail ");
                SQLText.AppendLine(" WHERE DocumentStatusId = @DocumentStatusId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@NewDocumentStatusId", updateData.NewDocumentStatusID);
                        comm.Parameters.AddWithValue("@DocumentStatusDetail", updateData.DocumentStatusDetail);
                        comm.Parameters.AddWithValue("@DocumentStatusId", updateData.DocumentStatusID);

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDocumentStatus(DocumentStatusBO deleteData)
        {
            try
            {
                StringBuilder SQLText = new StringBuilder();
                SQLText.AppendLine(" DELETE FROM DocumentStatus ");
                SQLText.AppendLine(" WHERE DocumentStatusId = @DocumentStatusId ");

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = SQLText.ToString();
                        comm.CommandType = CommandType.Text;

                        comm.Parameters.AddWithValue("@DocumentStatusId", deleteData.DocumentStatusID);

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
