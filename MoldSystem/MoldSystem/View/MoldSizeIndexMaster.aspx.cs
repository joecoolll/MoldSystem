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
    public partial class MoldSizeIndexMaster : MasterDetailPage
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
            MoldSizeIndexBL objMoldSizeIndexBL = new MoldSizeIndexBL();

            List<MoldSizeIndexBO> SizeIndexDataList = new List<MoldSizeIndexBO>();

            if (formLoad)
            {
                SizeIndexDataList = objMoldSizeIndexBL.GetSizeIndex(new MoldSizeIndexBO());

            }
            else
            {
                MoldSizeIndexBO criteria = new MoldSizeIndexBO();
                criteria.SizeIndexID = string.IsNullOrEmpty(SizeIndexIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(SizeIndexIDTextBox.Text.Trim());
                criteria.SizeIndexName = SizeIndexNameTextBox.Text.Trim();

                SizeIndexDataList = objMoldSizeIndexBL.GetSizeIndex(criteria);
            }

            BindGrid(SizeIndexDataList);
        }

        private void BindGrid(List<MoldSizeIndexBO> customerDataList)
        {
            SizeIndexGrid.DataSource = customerDataList;
            SizeIndexGrid.DataBind();
        }

        private void ResetScreen()
        {
            SizeIndexIDTextBox.Text = "";
            SizeIndexNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            SizeIndexEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            SizeIndexEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldSizeIndexBL objMoldSizeIndexBL = new MoldSizeIndexBL();
            objMoldSizeIndexBL.DeleteSizeIndex(new MoldSizeIndexBO() { SizeIndexID = id });
            GetData();
        }
        #endregion
    }
}