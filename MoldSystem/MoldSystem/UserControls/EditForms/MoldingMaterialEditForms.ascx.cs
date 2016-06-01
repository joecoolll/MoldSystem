using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MoldingMaterialEditForms : EditFormUserControl
    {
        private List<MoldingMaterialBO> MoldingMatData
        {
            get
            {
                return (ViewState["MoldingMatData_EditForm"] as List<MoldingMaterialBO>);
            }
            set
            {
                ViewState["MoldingMatData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            MoldingMatEditPopup.HeaderText = "Molding Material";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void MoldingMatEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int MoldingMatID = int.Parse(e.Parameter);
            SetInitialEditData(MoldingMatID);

            MoldingMatEditPopup.JSProperties["cpMoldingMatID"] = MoldingMatID;
            MoldingMatEditPopup.JSProperties["cpHeaderText"] = "Molding Material";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            MoldingMaterialBL objMoldingMaterialBL = new MoldingMaterialBL();
            MoldingMatData = objMoldingMaterialBL.GetMoldingMat(new MoldingMaterialBO());
        }

        private void SetInitialEditData(int MoldingMatID)
        {
            var moldingmatData = MoldingMatData.Where(x => x.MoldingMatID == MoldingMatID).FirstOrDefault();
            if (moldingmatData == null)
                return;
            EditFormMoldingMatIDTextBox.Text = moldingmatData.MoldingMatID.ToString();
            EditFormMoldingMatNameTextBox.Text = moldingmatData.MoldingMatName;
        }

        private void ClearData()
        {
            EditFormMoldingMatIDTextBox.Text = "";
            EditFormMoldingMatNameTextBox.Text = "";
        }

        private void CreateMoldingMat()
        {
            MoldingMaterialBO MoldingMat = new MoldingMaterialBO();
            MoldingMat.MoldingMatID = int.Parse(EditFormMoldingMatIDTextBox.Text);
            MoldingMat.MoldingMatName = EditFormMoldingMatNameTextBox.Text.Trim();

            MoldingMaterialBL objMoldingMaterialBL = new MoldingMaterialBL();
            objMoldingMaterialBL.InsertMoldingMat(MoldingMat);
        }

        private void EditMoldingMat(int id)
        {
            MoldingMaterialBO MoldingMat = new MoldingMaterialBO();
            MoldingMat.MoldingMatID = id;
            MoldingMat.NewMoldingMatID = int.Parse(EditFormMoldingMatIDTextBox.Text);
            MoldingMat.MoldingMatName = EditFormMoldingMatNameTextBox.Text.Trim();

            MoldingMaterialBL objMoldingMaterialBL = new MoldingMaterialBL();
            objMoldingMaterialBL.UpdateMoldingMat(MoldingMat);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateMoldingMat();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditMoldingMat(id);
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
                MoldingMatEditPopup.JSProperties["cpMoldingMatID"] = id;
            }
        }
        #endregion
    }
}