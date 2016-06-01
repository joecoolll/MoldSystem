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
    public partial class EndUserMaster : MasterDetailPage
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
            EndUserBL objEndUserBL = new EndUserBL();

            List<EndUserBO> enduserDataList = new List<EndUserBO>();

            if (formLoad)
            {
                enduserDataList = objEndUserBL.GetEndUser(new EndUserBO());

            }
            else
            {
                EndUserBO criteria = new EndUserBO();
                criteria.EndUserID = string.IsNullOrEmpty(EndUserIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(EndUserIDTextBox.Text.Trim());
                criteria.EndUserName = EndUserNameTextBox.Text.Trim();

                enduserDataList = objEndUserBL.GetEndUser(criteria);
            }

            BindGrid(enduserDataList);
        }

        private void BindGrid(List<EndUserBO> customerDataList)
        {
            EndUserGrid.DataSource = customerDataList;
            EndUserGrid.DataBind();
        }

        private void ResetScreen()
        {
            EndUserIDTextBox.Text = "";
            EndUserNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            EndUserEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            EndUserEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            EndUserBL objEndUserBL = new EndUserBL();
            objEndUserBL.DeleteEndUser(new EndUserBO() { EndUserID = id });
            GetData();
        }
        #endregion
    }
}