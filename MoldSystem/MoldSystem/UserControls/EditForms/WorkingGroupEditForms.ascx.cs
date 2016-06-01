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
    public partial class WorkingGroupEditForms : EditFormUserControl
    {
        private List<WorkingGroupBO> WorkGroupData
        {
            get
            {
                return (ViewState["WorkGroupData_EditForm"] as List<WorkingGroupBO>);
            }
            set
            {
                ViewState["WorkGroupData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            WorkGroupEditPopup.HeaderText = "Working Group";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void WorkGroupEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int WorkGroupID = int.Parse(e.Parameter);
            SetInitialEditData(WorkGroupID);

            WorkGroupEditPopup.JSProperties["cpWorkGroupID"] = WorkGroupID;
            WorkGroupEditPopup.JSProperties["cpHeaderText"] = "Working Group";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            WorkingGroupBL objWorkingGroupBL = new WorkingGroupBL();
            WorkGroupData = objWorkingGroupBL.GetWorkGroup(new WorkingGroupBO());
        }

        private void SetInitialEditData(int WorkGroupID)
        {
            var workgroupData = WorkGroupData.Where(x => x.WorkGroupID == WorkGroupID).FirstOrDefault();
            if (workgroupData == null)
                return;
            EditFormWorkGroupIDTextBox.Text = workgroupData.WorkGroupID.ToString();
            EditFormWorkGroupNameTextBox.Text = workgroupData.WorkGroupName;
        }

        private void ClearData()
        {
            EditFormWorkGroupIDTextBox.Text = "";
            EditFormWorkGroupNameTextBox.Text = "";
        }

        private void CreateWorkGroup()
        {
            WorkingGroupBO WorkGroup = new WorkingGroupBO();
            WorkGroup.WorkGroupID = int.Parse(EditFormWorkGroupIDTextBox.Text);
            WorkGroup.WorkGroupName = EditFormWorkGroupNameTextBox.Text.Trim();

            WorkingGroupBL objWorkingGroupBL = new WorkingGroupBL();
            objWorkingGroupBL.InsertWorkGroup(WorkGroup);
        }

        private void EditWorkGroup(int id)
        {
            WorkingGroupBO WorkGroup = new WorkingGroupBO();
            WorkGroup.WorkGroupID = id;
            WorkGroup.NewWorkGroupID = int.Parse(EditFormWorkGroupIDTextBox.Text);
            WorkGroup.WorkGroupName = EditFormWorkGroupNameTextBox.Text.Trim();

            WorkingGroupBL objWorkingGroupBL = new WorkingGroupBL();
            objWorkingGroupBL.UpdateWorkGroup(WorkGroup);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateWorkGroup();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditWorkGroup(id);
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
                WorkGroupEditPopup.JSProperties["cpWorkGroupID"] = id;
            }
        }
        #endregion
    }
}