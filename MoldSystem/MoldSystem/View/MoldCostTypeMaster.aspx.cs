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
    public partial class MoldCostTypeMaster : MasterDetailPage
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
            MoldCostTypeBL objMoldCostTypeBL = new MoldCostTypeBL();

            List<MoldCostTypeBO> MoldCostTypeDataList = new List<MoldCostTypeBO>();

            if (formLoad)
            {
                MoldCostTypeDataList = objMoldCostTypeBL.GetMoldCostType(new MoldCostTypeBO());

            }
            else
            {
                MoldCostTypeBO criteria = new MoldCostTypeBO();
                criteria.MoldCostTypeID = string.IsNullOrEmpty(MoldCostTypeIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(MoldCostTypeIDTextBox.Text.Trim());
                criteria.MoldCostTypeDetail = MoldCostTypeDetailTextBox.Text.Trim();

                MoldCostTypeDataList = objMoldCostTypeBL.GetMoldCostType(criteria);
            }

            BindGrid(MoldCostTypeDataList);
        }

        private void BindGrid(List<MoldCostTypeBO> customerDataList)
        {
            MoldCostTypeGrid.DataSource = customerDataList;
            MoldCostTypeGrid.DataBind();
        }

        private void ResetScreen()
        {
            MoldCostTypeIDTextBox.Text = "";
            MoldCostTypeDetailTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            MoldCostTypeEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            MoldCostTypeEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldCostTypeBL objMoldCostTypeBL = new MoldCostTypeBL();
            objMoldCostTypeBL.DeleteMoldCostType(new MoldCostTypeBO() { MoldCostTypeID = id });
            GetData();
        }
        #endregion
    }
}