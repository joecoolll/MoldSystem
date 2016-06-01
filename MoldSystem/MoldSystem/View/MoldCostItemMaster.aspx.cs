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
    public partial class MoldCostItemMaster : MasterDetailPage
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
            MoldCostItemBL objMoldCostItemBL = new MoldCostItemBL();

            List<MoldCostItemBO> MoldCostItemDataList = new List<MoldCostItemBO>();

            if (formLoad)
            {
                MoldCostItemDataList = objMoldCostItemBL.GetMoldCostItem(new MoldCostItemBO());

            }
            else
            {
                MoldCostItemBO criteria = new MoldCostItemBO();
                criteria.MoldCostItemID = string.IsNullOrEmpty(MoldCostItemIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(MoldCostItemIDTextBox.Text.Trim());
                criteria.MoldCostItemDetail = MoldCostItemDetailTextBox.Text.Trim();

                MoldCostItemDataList = objMoldCostItemBL.GetMoldCostItem(criteria);
            }

            BindGrid(MoldCostItemDataList);
        }

        private void BindGrid(List<MoldCostItemBO> customerDataList)
        {
            MoldCostItemGrid.DataSource = customerDataList;
            MoldCostItemGrid.DataBind();
        }

        private void ResetScreen()
        {
            MoldCostItemIDTextBox.Text = "";
            MoldCostItemDetailTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            MoldCostItemEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            MoldCostItemEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldCostItemBL objMoldCostItemBL = new MoldCostItemBL();
            objMoldCostItemBL.DeleteMoldCostItem(new MoldCostItemBO() { MoldCostItemID = id });
            GetData();
        }
        #endregion
    }
}