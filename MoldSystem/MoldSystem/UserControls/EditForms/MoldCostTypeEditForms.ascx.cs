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
    public partial class MoldCostTypeEditForms : EditFormUserControl
    {
        private List<MoldCostTypeBO> MoldCostTypeData
        {
            get
            {
                return (ViewState["MoldCostTypeData_EditForm"] as List<MoldCostTypeBO>);
            }
            set
            {
                ViewState["MoldCostTypeData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            MoldCostTypeEditPopup.HeaderText = "Mold Cost Type";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void MoldCostTypeEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int MoldCostTypeID = int.Parse(e.Parameter);
            SetInitialEditData(MoldCostTypeID);

            MoldCostTypeEditPopup.JSProperties["cpMoldCostTypeID"] = MoldCostTypeID;
            MoldCostTypeEditPopup.JSProperties["cpHeaderText"] = "Mold Cost Type";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            MoldCostTypeBL objMoldCostTypeBL = new MoldCostTypeBL();
            MoldCostTypeData = objMoldCostTypeBL.GetMoldCostType(new MoldCostTypeBO());
        }

        private void SetInitialEditData(int MoldCostTypeID)
        {
            var moldcosttypeData = MoldCostTypeData.Where(x => x.MoldCostTypeID == MoldCostTypeID).FirstOrDefault();
            if (moldcosttypeData == null)
                return;
            EditFormMoldCostTypeIDTextBox.Text = moldcosttypeData.MoldCostTypeID.ToString();
            EditFormMoldCostTypeDetailTextBox.Text = moldcosttypeData.MoldCostTypeDetail;
        }

        private void ClearData()
        {
            EditFormMoldCostTypeIDTextBox.Text = "";
            EditFormMoldCostTypeDetailTextBox.Text = "";
        }

        private void CreateMoldCostType()
        {
            MoldCostTypeBO MoldCostType = new MoldCostTypeBO();
            MoldCostType.MoldCostTypeID = int.Parse(EditFormMoldCostTypeIDTextBox.Text);
            MoldCostType.MoldCostTypeDetail = EditFormMoldCostTypeDetailTextBox.Text.Trim();

            MoldCostTypeBL objMoldCostTypeBL = new MoldCostTypeBL();
            objMoldCostTypeBL.InsertMoldCostType(MoldCostType);
        }

        private void EditMoldCostType(int id)
        {
            MoldCostTypeBO MoldCostType = new MoldCostTypeBO();
            MoldCostType.MoldCostTypeID = id;
            MoldCostType.NewMoldCostTypeID = int.Parse(EditFormMoldCostTypeIDTextBox.Text);
            MoldCostType.MoldCostTypeDetail = EditFormMoldCostTypeDetailTextBox.Text.Trim();

            MoldCostTypeBL objMoldCostTypeBL = new MoldCostTypeBL();
            objMoldCostTypeBL.UpdateMoldCostType(MoldCostType);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateMoldCostType();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditMoldCostType(id);
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
                MoldCostTypeEditPopup.JSProperties["cpMoldCostTypeID"] = id;
            }
        }
        #endregion
    }
}