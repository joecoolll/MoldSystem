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
    public partial class DifficultyIndexEditForms : EditFormUserControl
    {
        private List<DifficultyIndexBO> DiffiIndexData
        {
            get
            {
                return (ViewState["DiffiIndexData_EditForm"] as List<DifficultyIndexBO>);
            }
            set
            {
                ViewState["DiffiIndexData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            DiffiIndexEditPopup.HeaderText = "Difficulty Index";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void DiffiIndexEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int DiffiIndexID = int.Parse(e.Parameter);
            SetInitialEditData(DiffiIndexID);

            DiffiIndexEditPopup.JSProperties["cpDiffiIndexID"] = DiffiIndexID;
            DiffiIndexEditPopup.JSProperties["cpHeaderText"] = "Difficulty Index";
        }
        #endregion


        #region Method
        private void GetAllData()
        {
            DifficultyIndexBL objDifficultyIndexBL = new DifficultyIndexBL();
            DiffiIndexData = objDifficultyIndexBL.GetDiffiIndex(new DifficultyIndexBO());
        }

        private void SetInitialEditData(int DiffiIndexID)
        {
            var diffiindexData = DiffiIndexData.Where(x => x.DiffiIndexID == DiffiIndexID).FirstOrDefault();
            if (diffiindexData == null)
                return;
            EditFormDiffiIndexIDTextBox.Text = diffiindexData.DiffiIndexID.ToString();
            EditFormDiffiIndexNameTextBox.Text = diffiindexData.DiffiIndexName;
        }

        private void ClearData()
        {
            EditFormDiffiIndexIDTextBox.Text = "";
            EditFormDiffiIndexNameTextBox.Text = "";
        }

        private void CreateDiffiIndex()
        {
            DifficultyIndexBO DiffiIndex = new DifficultyIndexBO();
            DiffiIndex.DiffiIndexID = int.Parse(EditFormDiffiIndexIDTextBox.Text);
            DiffiIndex.DiffiIndexName = EditFormDiffiIndexNameTextBox.Text.Trim();

            DifficultyIndexBL objDifficultyIndexBL = new DifficultyIndexBL();
            objDifficultyIndexBL.InsertDiffiIndex(DiffiIndex);
        }

        private void EditDiffiIndex(int id)
        {
            DifficultyIndexBO DiffiIndex = new DifficultyIndexBO();
            DiffiIndex.DiffiIndexID = id;
            DiffiIndex.NewDiffiIndexID = int.Parse(EditFormDiffiIndexIDTextBox.Text);
            DiffiIndex.DiffiIndexName = EditFormDiffiIndexNameTextBox.Text.Trim();

            DifficultyIndexBL objDifficultyIndexBL = new DifficultyIndexBL();
            objDifficultyIndexBL.UpdateDiffiIndex(DiffiIndex);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateDiffiIndex();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditDiffiIndex(id);
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
                DiffiIndexEditPopup.JSProperties["cpDiffiIndexID"] = id;
            }
        }
        #endregion
    }
}