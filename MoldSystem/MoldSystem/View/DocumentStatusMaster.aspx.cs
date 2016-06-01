using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Bussinesslogic;
using BussinessObject;

namespace MoldSystem.View
{
    public partial class DocumentStatusMaster : MasterDetailPage
    {
        MasterUserControl masterUC;
        public override MasterUserControl MasterUC { get { return masterUC; } }

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData(true);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            GetData();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }
        #endregion

        #region Method
        private void GetData(bool formLoad = false)
        {
            DocumentStatusBL objDocumentStatusBL = new DocumentStatusBL();

            List<DocumentStatusBO> DocumentStatusDataList = new List<DocumentStatusBO>();

            if (formLoad)
            {
                DocumentStatusDataList = objDocumentStatusBL.GetDocumentStatus(new DocumentStatusBO());

            }
            else
            {
                DocumentStatusBO criteria = new DocumentStatusBO();
                criteria.DocumentStatusID = string.IsNullOrEmpty(DocumentStatusIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(DocumentStatusIDTextBox.Text.Trim());
                criteria.DocumentStatusDetail = DocumentStatusDetailTextBox.Text.Trim();

                DocumentStatusDataList = objDocumentStatusBL.GetDocumentStatus(criteria);
            }

            BindGrid(DocumentStatusDataList);
        }

        private void BindGrid(List<DocumentStatusBO> customerDataList)
        {
            DocumentStatusGrid.DataSource = customerDataList;
            DocumentStatusGrid.DataBind();
        }

        private void ResetScreen()
        {
            DocumentStatusIDTextBox.Text = "";
            DocumentStatusDetailTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            DocumentStatusEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            DocumentStatusEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            DocumentStatusBL objDocumentStatusBL = new DocumentStatusBL();
            objDocumentStatusBL.DeleteDocumentStatus(new DocumentStatusBO() { DocumentStatusID = id });
            GetData();
        }
        #endregion
    }
}