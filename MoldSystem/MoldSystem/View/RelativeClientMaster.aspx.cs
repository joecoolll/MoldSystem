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
    public partial class RelativeClientMaster : MasterDetailPage
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
            RelativeClientBL objRelativeClientBL = new RelativeClientBL();

            List<RelativeClientBO> relativeclientDataList = new List<RelativeClientBO>();

            if (formLoad)
            {
                relativeclientDataList = objRelativeClientBL.GetRelativeClient(new RelativeClientBO());

            }
            else
            {
                RelativeClientBO criteria = new RelativeClientBO();
                criteria.RelativeClientID = string.IsNullOrEmpty(RelativeClientIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(RelativeClientIDTextBox.Text.Trim());
                criteria.RelativeClientName = RelativeClientNameTextBox.Text.Trim();

                relativeclientDataList = objRelativeClientBL.GetRelativeClient(criteria);
            }

            BindGrid(relativeclientDataList);
        }

        private void BindGrid(List<RelativeClientBO> customerDataList)
        {
            RelativeClientGrid.DataSource = customerDataList;
            RelativeClientGrid.DataBind();
        }

        private void ResetScreen()
        {
            RelativeClientIDTextBox.Text = "";
            RelativeClientNameTextBox.Text = "";

            GetData(true);
        }
        #endregion


        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            RelativeClientEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            RelativeClientEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            RelativeClientBL objRelativeClientBL = new RelativeClientBL();
            objRelativeClientBL.DeleteRelativeClient(new RelativeClientBO() { RelativeClientID = id });
            GetData();
        }
        #endregion


    }
}