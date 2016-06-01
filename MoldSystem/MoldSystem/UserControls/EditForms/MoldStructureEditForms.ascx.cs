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
    public partial class MoldStructureEditForms : EditFormUserControl
    {
        private List<MoldStructureBO> MoldStructureData
        {
            get
            {
                return (ViewState["MoldStructureData_EditForm"] as List<MoldStructureBO>);
            }
            set
            {
                ViewState["MoldStructureData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            MoldStructureEditPopup.HeaderText = "Mold Structure";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void MoldStructureEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int MoldStructureID = int.Parse(e.Parameter);
            SetInitialEditData(MoldStructureID);

            MoldStructureEditPopup.JSProperties["cpMoldStructureID"] = MoldStructureID;
            MoldStructureEditPopup.JSProperties["cpHeaderText"] = "Mold Structure";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            MoldStructureBL objMoldStructureBL = new MoldStructureBL();
            MoldStructureData = objMoldStructureBL.GetMoldStructure(new MoldStructureBO());
        }

        private void SetInitialEditData(int MoldStructureID)
        {
            var moldstructureData = MoldStructureData.Where(x => x.MoldStructureID == MoldStructureID).FirstOrDefault();
            if (moldstructureData == null)
                return;
            EditFormMoldStructureIDTextBox.Text = moldstructureData.MoldStructureID.ToString();
            EditFormMoldStructureNameTextBox.Text = moldstructureData.MoldStructureName;
        }

        private void ClearData()
        {
            EditFormMoldStructureIDTextBox.Text = "";
            EditFormMoldStructureNameTextBox.Text = "";
        }

        private void CreateMoldStructure()
        {
            MoldStructureBO MoldStructure = new MoldStructureBO();
            MoldStructure.MoldStructureID = int.Parse(EditFormMoldStructureIDTextBox.Text);
            MoldStructure.MoldStructureName = EditFormMoldStructureNameTextBox.Text.Trim();

            MoldStructureBL objMoldStructureBL = new MoldStructureBL();
            objMoldStructureBL.InsertMoldStructure(MoldStructure);
        }

        private void EditMoldStructure(int id)
        {
            MoldStructureBO MoldStructure = new MoldStructureBO();
            MoldStructure.MoldStructureID = id;
            MoldStructure.NewMoldStructureID = int.Parse(EditFormMoldStructureIDTextBox.Text);
            MoldStructure.MoldStructureName = EditFormMoldStructureNameTextBox.Text.Trim();

            MoldStructureBL objMoldStructureBL = new MoldStructureBL();
            objMoldStructureBL.UpdateMoldStructure(MoldStructure);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateMoldStructure();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditMoldStructure(id);
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
                MoldStructureEditPopup.JSProperties["cpMoldStructureID"] = id;
            }
        }
        #endregion
    }
}