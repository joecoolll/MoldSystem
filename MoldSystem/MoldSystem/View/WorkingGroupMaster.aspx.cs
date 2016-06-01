using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Bussinesslogic;
using BussinessObject;

namespace MoldSystem.View
{
    public partial class WorkingGroupMaster : MasterDetailPage
    {
        MasterUserControl masterUC;
        public override MasterUserControl MasterUC { get { return masterUC; } }

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData(true);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            GetData();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }
        #endregion

        #region Method
        private void GetData(bool formLoad = false)
        {
            WorkingGroupBL objWorkingGroupBL = new WorkingGroupBL();

            List<WorkingGroupBO> WorkGroupDataList = new List<WorkingGroupBO>();

            if (formLoad)
            {
                WorkGroupDataList = objWorkingGroupBL.GetWorkGroup(new WorkingGroupBO());

            }
            else
            {
                WorkingGroupBO criteria = new WorkingGroupBO();
                criteria.WorkGroupID = string.IsNullOrEmpty(WorkGroupIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(WorkGroupIDTextBox.Text.Trim());
                criteria.WorkGroupName = WorkGroupNameTextBox.Text.Trim();

                WorkGroupDataList = objWorkingGroupBL.GetWorkGroup(criteria);
            }

            BindGrid(WorkGroupDataList);
        }

        private void BindGrid(List<WorkingGroupBO> customerDataList)
        {
            WorkGroupGrid.DataSource = customerDataList;
            WorkGroupGrid.DataBind();
        }

        private void ResetScreen()
        {
            WorkGroupIDTextBox.Text = "";
            WorkGroupNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            WorkGroupEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            WorkGroupEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            WorkingGroupBL objWorkingGroupBL = new WorkingGroupBL();
            objWorkingGroupBL.DeleteWorkGroup(new WorkingGroupBO() { WorkGroupID = id });
            GetData();
        }
        #endregion
    }
}