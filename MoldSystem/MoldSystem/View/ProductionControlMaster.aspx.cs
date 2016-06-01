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
    public partial class ProductionControlMaster : MasterDetailPage
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
            ProductionControlBL objProductionControlBL = new ProductionControlBL();

            List<ProductionControlBO> ProdConDataList = new List<ProductionControlBO>();

            if (formLoad)
            {
                ProdConDataList = objProductionControlBL.GetProdCon(new ProductionControlBO());

            }
            else
            {
                ProductionControlBO criteria = new ProductionControlBO();
                criteria.ProdConID = string.IsNullOrEmpty(ProdConIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(ProdConIDTextBox.Text.Trim());
                criteria.ProdConName = ProdConNameTextBox.Text.Trim();

                ProdConDataList = objProductionControlBL.GetProdCon(criteria);
            }

            BindGrid(ProdConDataList);
        }

        private void BindGrid(List<ProductionControlBO> customerDataList)
        {
            ProdConGrid.DataSource = customerDataList;
            ProdConGrid.DataBind();
        }

        private void ResetScreen()
        {
            ProdConIDTextBox.Text = "";
            ProdConNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            ProdConEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            ProdConEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            ProductionControlBL objProductionControlBL = new ProductionControlBL();
            objProductionControlBL.DeleteProdCon(new ProductionControlBO() { ProdConID = id });
            GetData();
        }
        #endregion
    }
}