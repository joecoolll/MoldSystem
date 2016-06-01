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
    public partial class DifficultyIndexMaster : MasterDetailPage
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
            DifficultyIndexBL objDifficultyIndexBL = new DifficultyIndexBL();

            List<DifficultyIndexBO> DiffiIndexDataList = new List<DifficultyIndexBO>();

            if (formLoad)
            {
                DiffiIndexDataList = objDifficultyIndexBL.GetDiffiIndex(new DifficultyIndexBO());

            }
            else
            {
                DifficultyIndexBO criteria = new DifficultyIndexBO();
                criteria.DiffiIndexID = string.IsNullOrEmpty(DiffiIndexIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(DiffiIndexIDTextBox.Text.Trim());
                criteria.DiffiIndexName = DiffiIndexNameTextBox.Text.Trim();

                DiffiIndexDataList = objDifficultyIndexBL.GetDiffiIndex(criteria);
            }

            BindGrid(DiffiIndexDataList);
        }

        private void BindGrid(List<DifficultyIndexBO> customerDataList)
        {
            DiffiIndexGrid.DataSource = customerDataList;
            DiffiIndexGrid.DataBind();
        }

        private void ResetScreen()
        {
            DiffiIndexIDTextBox.Text = "";
            DiffiIndexNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            DiffiIndexEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            DiffiIndexEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            DifficultyIndexBL objDifficultyIndexBL = new DifficultyIndexBL();
            objDifficultyIndexBL.DeleteDiffiIndex(new DifficultyIndexBO() { DiffiIndexID = id });
            GetData();
        }
        #endregion
    }
}