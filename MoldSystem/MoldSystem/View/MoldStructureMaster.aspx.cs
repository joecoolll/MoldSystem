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
    public partial class MoldStructureMaster : MasterDetailPage
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
            MoldStructureBL objMoldStructureBL = new MoldStructureBL();

            List<MoldStructureBO> MoldStructureDataList = new List<MoldStructureBO>();

            if (formLoad)
            {
                MoldStructureDataList = objMoldStructureBL.GetMoldStructure(new MoldStructureBO());

            }
            else
            {
                MoldStructureBO criteria = new MoldStructureBO();
                criteria.MoldStructureID = string.IsNullOrEmpty(MoldStructureIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(MoldStructureIDTextBox.Text.Trim());
                criteria.MoldStructureName = MoldStructureNameTextBox.Text.Trim();

                MoldStructureDataList = objMoldStructureBL.GetMoldStructure(criteria);
            }

            BindGrid(MoldStructureDataList);
        }

        private void BindGrid(List<MoldStructureBO> customerDataList)
        {
            MoldStructureGrid.DataSource = customerDataList;
            MoldStructureGrid.DataBind();
        }

        private void ResetScreen()
        {
            MoldStructureIDTextBox.Text = "";
            MoldStructureNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            MoldStructureEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            MoldStructureEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldStructureBL objMoldStructureBL = new MoldStructureBL();
            objMoldStructureBL.DeleteMoldStructure(new MoldStructureBO() { MoldStructureID = id });
            GetData();
        }
        #endregion
    }
}