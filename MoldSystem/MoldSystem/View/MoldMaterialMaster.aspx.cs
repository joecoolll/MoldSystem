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
    public partial class MoldMaterialMaster : MasterDetailPage
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
            MoldMaterialBL objMoldMaterialBL = new MoldMaterialBL();

            List<MoldMaterialBO> MoldMatDataList = new List<MoldMaterialBO>();

            if (formLoad)
            {
                MoldMatDataList = objMoldMaterialBL.GetMoldMat(new MoldMaterialBO());

            }
            else
            {
                MoldMaterialBO criteria = new MoldMaterialBO();
                criteria.MoldMatID = string.IsNullOrEmpty(MoldMatIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(MoldMatIDTextBox.Text.Trim());
                criteria.MoldMatName = MoldMatNameTextBox.Text.Trim();

                MoldMatDataList = objMoldMaterialBL.GetMoldMat(criteria);
            }

            BindGrid(MoldMatDataList);
        }

        private void BindGrid(List<MoldMaterialBO> customerDataList)
        {
            MoldMatGrid.DataSource = customerDataList;
            MoldMatGrid.DataBind();
        }

        private void ResetScreen()
        {
            MoldMatIDTextBox.Text = "";
            MoldMatNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            MoldMatEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            MoldMatEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldMaterialBL objMoldMaterialBL = new MoldMaterialBL();
            objMoldMaterialBL.DeleteMoldMat(new MoldMaterialBO() { MoldMatID = id });
            GetData();
        }
        #endregion
    }
}