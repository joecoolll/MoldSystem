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
    public partial class MoldCostItemEditForms : EditFormUserControl
    {
        private List<MoldCostItemBO> MoldCostItemData
        {
            get
            {
                return (ViewState["MoldCostItemData_EditForm"] as List<MoldCostItemBO>);
            }
            set
            {
                ViewState["MoldCostItemData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            MoldCostItemEditPopup.HeaderText = "Mold Cost Item";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void MoldCostItemEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int MoldCostItemID = int.Parse(e.Parameter);
            SetInitialEditData(MoldCostItemID);

            MoldCostItemEditPopup.JSProperties["cpMoldCostItemID"] = MoldCostItemID;
            MoldCostItemEditPopup.JSProperties["cpHeaderText"] = "Mold Cost Item";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            MoldCostItemBL objMoldCostItemBL = new MoldCostItemBL();
            MoldCostItemData = objMoldCostItemBL.GetMoldCostItem(new MoldCostItemBO());
        }

        private void SetInitialEditData(int MoldCostItemID)
        {
            var moldcostitemData = MoldCostItemData.Where(x => x.MoldCostItemID == MoldCostItemID).FirstOrDefault();
            if (moldcostitemData == null)
                return;
            EditFormMoldCostItemIDTextBox.Text = moldcostitemData.MoldCostItemID.ToString();
            EditFormMoldCostItemDetailTextBox.Text = moldcostitemData.MoldCostItemDetail;
        }

        private void ClearData()
        {
            EditFormMoldCostItemIDTextBox.Text = "";
            EditFormMoldCostItemDetailTextBox.Text = "";
        }

        private void CreateMoldCostItem()
        {
            MoldCostItemBO MoldCostItem = new MoldCostItemBO();
            MoldCostItem.MoldCostItemID = int.Parse(EditFormMoldCostItemIDTextBox.Text);
            MoldCostItem.MoldCostItemDetail = EditFormMoldCostItemDetailTextBox.Text.Trim();

            MoldCostItemBL objMoldCostItemBL = new MoldCostItemBL();
            objMoldCostItemBL.InsertMoldCostItem(MoldCostItem);
        }

        private void EditMoldCostItem(int id)
        {
            MoldCostItemBO MoldCostItem = new MoldCostItemBO();
            MoldCostItem.MoldCostItemID = id;
            MoldCostItem.NewMoldCostItemID = int.Parse(EditFormMoldCostItemIDTextBox.Text);
            MoldCostItem.MoldCostItemDetail = EditFormMoldCostItemDetailTextBox.Text.Trim();

            MoldCostItemBL objMoldCostItemBL = new MoldCostItemBL();
            objMoldCostItemBL.UpdateMoldCostItem(MoldCostItem);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateMoldCostItem();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditMoldCostItem(id);
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
                MoldCostItemEditPopup.JSProperties["cpMoldCostItemID"] = id;
            }
        }
        #endregion
    }
}