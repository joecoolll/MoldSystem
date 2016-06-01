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
    public partial class MoldTypeEditForms : EditFormUserControl
    {
        private List<MoldTypeBO> MoldTypeData
        {
            get
            {
                return (ViewState["MoldTypeData_EditForm"] as List<MoldTypeBO>);
            }
            set
            {
                ViewState["MoldTypeData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            MoldTypeEditPopup.HeaderText = "Mold Type";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void MoldTypeEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int MoldTypeID = int.Parse(e.Parameter);
            SetInitialEditData(MoldTypeID);

            MoldTypeEditPopup.JSProperties["cpMoldTypeID"] = MoldTypeID;
            MoldTypeEditPopup.JSProperties["cpHeaderText"] = "Mold Type";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            MoldTypeBL objMoldTypeBL = new MoldTypeBL();
            MoldTypeData = objMoldTypeBL.GetMoldType(new MoldTypeBO());
        }

        private void SetInitialEditData(int MoldTypeID)
        {
            var moldtypeData = MoldTypeData.Where(x => x.MoldTypeID == MoldTypeID).FirstOrDefault();
            if (moldtypeData == null)
                return;
            EditFormMoldTypeIDTextBox.Text = moldtypeData.MoldTypeID.ToString();
            EditFormMoldTypeDetailTextBox.Text = moldtypeData.MoldTypeDetail;
        }

        private void ClearData()
        {
            EditFormMoldTypeIDTextBox.Text = "";
            EditFormMoldTypeDetailTextBox.Text = "";
        }

        private void CreateMoldType()
        {
            MoldTypeBO MoldType = new MoldTypeBO();
            MoldType.MoldTypeID = int.Parse(EditFormMoldTypeIDTextBox.Text);
            MoldType.MoldTypeDetail = EditFormMoldTypeDetailTextBox.Text.Trim();

            MoldTypeBL objMoldTypeBL = new MoldTypeBL();
            objMoldTypeBL.InsertMoldType(MoldType);
        }

        private void EditMoldType(int id)
        {
            MoldTypeBO MoldType = new MoldTypeBO();
            MoldType.MoldTypeID = id;
            MoldType.NewMoldTypeID = int.Parse(EditFormMoldTypeIDTextBox.Text);
            MoldType.MoldTypeDetail = EditFormMoldTypeDetailTextBox.Text.Trim();

            MoldTypeBL objMoldTypeBL = new MoldTypeBL();
            objMoldTypeBL.UpdateMoldType(MoldType);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateMoldType();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditMoldType(id);
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
                MoldTypeEditPopup.JSProperties["cpMoldTypeID"] = id;
            }
        }
        #endregion

    }
}