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
    public partial class MoldMaterialEditForms : EditFormUserControl
    {
        private List<MoldMaterialBO> MoldMatData
        {
            get
            {
                return (ViewState["MoldMatData_EditForm"] as List<MoldMaterialBO>);
            }
            set
            {
                ViewState["MoldMatData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            MoldMatEditPopup.HeaderText = "Mold Material";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void MoldMatEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int MoldMatID = int.Parse(e.Parameter);
            SetInitialEditData(MoldMatID);

            MoldMatEditPopup.JSProperties["cpMoldMatID"] = MoldMatID;
            MoldMatEditPopup.JSProperties["cpHeaderText"] = "End User";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            MoldMaterialBL objMoldMaterialBL = new MoldMaterialBL();
            MoldMatData = objMoldMaterialBL.GetMoldMat(new MoldMaterialBO());
        }

        private void SetInitialEditData(int MoldMatID)
        {
            var moldmatData = MoldMatData.Where(x => x.MoldMatID == MoldMatID).FirstOrDefault();
            if (moldmatData == null)
                return;
            EditFormMoldMatIDTextBox.Text = moldmatData.MoldMatID.ToString();
            EditFormMoldMatNameTextBox.Text = moldmatData.MoldMatName;
        }

        private void ClearData()
        {
            EditFormMoldMatIDTextBox.Text = "";
            EditFormMoldMatNameTextBox.Text = "";
        }

        private void CreateMoldMat()
        {
            MoldMaterialBO MoldMat = new MoldMaterialBO();
            MoldMat.MoldMatID = int.Parse(EditFormMoldMatIDTextBox.Text);
            MoldMat.MoldMatName = EditFormMoldMatNameTextBox.Text.Trim();

            MoldMaterialBL objMoldMaterialBL = new MoldMaterialBL();
            objMoldMaterialBL.InsertMoldMat(MoldMat);
        }

        private void EditMoldMat(int id)
        {
            MoldMaterialBO MoldMat = new MoldMaterialBO();
            MoldMat.MoldMatID = id;
            MoldMat.NewMoldMatID = int.Parse(EditFormMoldMatIDTextBox.Text);
            MoldMat.MoldMatName = EditFormMoldMatNameTextBox.Text.Trim();

            MoldMaterialBL objMoldMaterialBL = new MoldMaterialBL();
            objMoldMaterialBL.UpdateMoldMat(MoldMat);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateMoldMat();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditMoldMat(id);
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
                MoldMatEditPopup.JSProperties["cpMoldMatID"] = id;
            }
        }
        #endregion
    }
}