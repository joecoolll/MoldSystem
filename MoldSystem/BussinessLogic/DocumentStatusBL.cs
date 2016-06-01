using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class DocumentStatusBL
    {
        public List<DocumentStatusBO> GetDocumentStatus(DocumentStatusBO criteria)
        {
            try
            {
                DocumentStatusDA objDocumentStatusDA = new DocumentStatusDA();
                return objDocumentStatusDA.GetDocumentStatus(criteria);
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
                DocumentStatusDA objDocumentStatusDA = new DocumentStatusDA();
                objDocumentStatusDA.InsertDocumentStatus(newData);
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
                DocumentStatusDA objDocumentStatusDA = new DocumentStatusDA();
                objDocumentStatusDA.UpdateDocumentStatus(updateData);
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
                DocumentStatusDA objDocumentStatusDA = new DocumentStatusDA();
                objDocumentStatusDA.DeleteDocumentStatus(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
