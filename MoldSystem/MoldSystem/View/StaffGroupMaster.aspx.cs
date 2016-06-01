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
    public partial class StaffGroupMaster : MasterDetailPage
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
            StaffGroupBL objStaffGroupBL = new StaffGroupBL();

            List<StaffGroupBO> StaffGroupDataList = new List<StaffGroupBO>();

            if (formLoad)
            {
                StaffGroupDataList = objStaffGroupBL.GetStaffGroup(new StaffGroupBO());

            }
            else
            {
                StaffGroupBO criteria = new StaffGroupBO();
                criteria.StaffGroupID = string.IsNullOrEmpty(StaffGroupIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(StaffGroupIDTextBox.Text.Trim());
                criteria.StaffGroupName = StaffGroupNameTextBox.Text.Trim();

                StaffGroupDataList = objStaffGroupBL.GetStaffGroup(criteria);
            }

            BindGrid(StaffGroupDataList);
        }

        private void BindGrid(List<StaffGroupBO> customerDataList)
        {
            StaffGroupGrid.DataSource = customerDataList;
            StaffGroupGrid.DataBind();
        }

        private void ResetScreen()
        {
            StaffGroupIDTextBox.Text = "";
            StaffGroupNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            StaffGroupEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            StaffGroupEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            StaffGroupBL objStaffGroupBL = new StaffGroupBL();
            objStaffGroupBL.DeleteStaffGroup(new StaffGroupBO() { StaffGroupID = id });
            GetData();
        }
        #endregion
    }
}