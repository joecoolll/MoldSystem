using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using Bussinesslogic;
using Common;

namespace MoldSystem.UserControls.EditForms
{
    public partial class DocumentStatusEditForms : EditFormUserControl
    {
        private List<DocumentStatusBO> DocumentStatusData
        {
            get
            {
                return (ViewState["DocumentStatusData_EditForm"] as List<DocumentStatusBO>);
            }
            set
            {
                ViewState["DocumentStatusData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            DocumentStatusEditPopup.HeaderText = "Document Status";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void DocumentStatusEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int DocumentStatusID = int.Parse(e.Parameter);
            SetInitialEditData(DocumentStatusID);

            DocumentStatusEditPopup.JSProperties["cpDocumentStatusID"] = DocumentStatusID;
            DocumentStatusEditPopup.JSProperties["cpHeaderText"] = "Document Status";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            DocumentStatusBL objDocumentStatusBL = new DocumentStatusBL();
            DocumentStatusData = objDocumentStatusBL.GetDocumentStatus(new DocumentStatusBO());
        }

        private void SetInitialEditData(int DocumentStatusID)
        {
            var documentstatusData = DocumentStatusData.Where(x => x.DocumentStatusID == DocumentStatusID).FirstOrDefault();
            if (documentstatusData == null)
                return;
            EditFormDocumentStatusIDTextBox.Text = documentstatusData.DocumentStatusID.ToString();
            EditFormDocumentStatusDetailTextBox.Text = documentstatusData.DocumentStatusDetail;
        }

        private void ClearData()
        {
            EditFormDocumentStatusIDTextBox.Text = "";
            EditFormDocumentStatusDetailTextBox.Text = "";
        }

        private void CreateDocumentStatus()
        {
            DocumentStatusBO DocumentStatus = new DocumentStatusBO();
            DocumentStatus.DocumentStatusID = int.Parse(EditFormDocumentStatusIDTextBox.Text);
            DocumentStatus.DocumentStatusDetail = EditFormDocumentStatusDetailTextBox.Text.Trim();

            DocumentStatusBL objDocumentStatusBL = new DocumentStatusBL();
            objDocumentStatusBL.InsertDocumentStatus(DocumentStatus);
        }

        private void EditDocumentStatus(int id)
        {
            DocumentStatusBO DocumentStatus = new DocumentStatusBO();
            DocumentStatus.DocumentStatusID = id;
            DocumentStatus.NewDocumentStatusID = int.Parse(EditFormDocumentStatusIDTextBox.Text);
            DocumentStatus.DocumentStatusDetail = EditFormDocumentStatusDetailTextBox.Text.Trim();

            DocumentStatusBL objDocumentStatusBL = new DocumentStatusBL();
            objDocumentStatusBL.UpdateDocumentStatus(DocumentStatus);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateDocumentStatus();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditDocumentStatus(id);
            }
        }

        public override void CancelChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
            {
                ClearData();
            }
            else if (callbackArgs[0] == "Edit")
            {
                ClearData();
                int id = int.Parse(callbackArgs[1]);
                SetInitialEditData(id);
                DocumentStatusEditPopup.JSProperties["cpDocumentStatusID"] = id;
            }
        }
        #endregion
    }
}