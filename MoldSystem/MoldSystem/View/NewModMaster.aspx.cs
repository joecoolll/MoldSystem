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
    public partial class NewModMaster : MasterDetailPage
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
            NewModBL objNewModBL = new NewModBL();

            List<NewModBO> NewModDataList = new List<NewModBO>();

            if (formLoad)
            {
                NewModDataList = objNewModBL.GetNewMod(new NewModBO());

            }
            else
            {
                NewModBO criteria = new NewModBO();
                criteria.NewModID = string.IsNullOrEmpty(NewModIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(NewModIDTextBox.Text.Trim());
                criteria.NewModDetail = NewModDetailTextBox.Text.Trim();

                NewModDataList = objNewModBL.GetNewMod(criteria);
            }

            BindGrid(NewModDataList);
        }

        private void BindGrid(List<NewModBO> customerDataList)
        {
            NewModGrid.DataSource = customerDataList;
            NewModGrid.DataBind();
        }

        private void ResetScreen()
        {
            NewModIDTextBox.Text = "";
            NewModDetailTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            NewModEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            NewModEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            NewModBL objNewModBL = new NewModBL();
            objNewModBL.DeleteNewMod(new NewModBO() { NewModID = id });
            GetData();
        }
        #endregion
    }
}