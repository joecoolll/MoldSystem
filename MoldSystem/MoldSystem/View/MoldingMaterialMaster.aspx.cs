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
    public partial class MoldingMaterialMaster : MasterDetailPage
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
            MoldingMaterialBL objMoldingMaterialBL = new MoldingMaterialBL();

            List<MoldingMaterialBO> MoldingMatDataList = new List<MoldingMaterialBO>();

            if (formLoad)
            {
                MoldingMatDataList = objMoldingMaterialBL.GetMoldingMat(new MoldingMaterialBO());

            }
            else
            {
                MoldingMaterialBO criteria = new MoldingMaterialBO();
                criteria.MoldingMatID = string.IsNullOrEmpty(MoldingMatIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(MoldingMatIDTextBox.Text.Trim());
                criteria.MoldingMatName = MoldingMatNameTextBox.Text.Trim();

                MoldingMatDataList = objMoldingMaterialBL.GetMoldingMat(criteria);
            }

            BindGrid(MoldingMatDataList);
        }

        private void BindGrid(List<MoldingMaterialBO> customerDataList)
        {
            MoldingMatGrid.DataSource = customerDataList;
            MoldingMatGrid.DataBind();
        }

        private void ResetScreen()
        {
            MoldingMatIDTextBox.Text = "";
            MoldingMatNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            MoldingMatEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            MoldingMatEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldingMaterialBL objMoldingMaterialBL = new MoldingMaterialBL();
            objMoldingMaterialBL.DeleteMoldingMat(new MoldingMaterialBO() { MoldingMatID = id });
            GetData();
        }
        #endregion
    }
}