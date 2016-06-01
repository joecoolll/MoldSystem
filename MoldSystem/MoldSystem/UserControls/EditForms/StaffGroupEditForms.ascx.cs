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
    public partial class StaffGroupEditForms : EditFormUserControl
    {
        private List<StaffGroupBO> StaffGroupData
        {
            get
            {
                return (ViewState["StaffGroupData_EditForm"] as List<StaffGroupBO>);
            }
            set
            {
                ViewState["StaffGroupData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void StaffGroupEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int StaffGroupID = int.Parse(e.Parameter);
            SetInitialEditData(StaffGroupID);

            StaffGroupEditPopup.JSProperties["cpStaffGroupID"] = StaffGroupID;
            StaffGroupEditPopup.JSProperties["cpHeaderText"] = "Staff Group";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            StaffGroupBL objStaffGroupBL = new StaffGroupBL();
            StaffGroupData = objStaffGroupBL.GetStaffGroup(new StaffGroupBO());
        }

        private void SetInitialEditData(int StaffGroupID)
        {
            var staffgroupData = StaffGroupData.Where(x => x.StaffGroupID == StaffGroupID).FirstOrDefault();
            if (staffgroupData == null)
                return;
            EditFormStaffGroupIDTextBox.Text = staffgroupData.StaffGroupID.ToString();
            EditFormStaffGroupNameTextBox.Text = staffgroupData.StaffGroupName;
        }

        private void ClearData()
        {
            EditFormStaffGroupIDTextBox.Text = "";
            EditFormStaffGroupNameTextBox.Text = "";
        }

        private void CreateStaffGroup()
        {
            StaffGroupBO StaffGroup = new StaffGroupBO();
            StaffGroup.StaffGroupID = int.Parse(EditFormStaffGroupIDTextBox.Text);
            StaffGroup.StaffGroupName = EditFormStaffGroupNameTextBox.Text.Trim();

            StaffGroupBL objStaffGroupBL = new StaffGroupBL();
            objStaffGroupBL.InsertStaffGroup(StaffGroup);
        }

        private void EditStaffGroup(int id)
        {
            StaffGroupBO StaffGroup = new StaffGroupBO();
            StaffGroup.StaffGroupID = id;
            StaffGroup.NewStaffGroupID = int.Parse(EditFormStaffGroupIDTextBox.Text);
            StaffGroup.StaffGroupName = EditFormStaffGroupNameTextBox.Text.Trim();

            StaffGroupBL objStaffGroupBL = new StaffGroupBL();
            objStaffGroupBL.UpdateStaffGroup(StaffGroup);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateStaffGroup();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditStaffGroup(id);
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
                StaffGroupEditPopup.JSProperties["cpStaffGroupID"] = id;
            }
        }
        #endregion
    }
}