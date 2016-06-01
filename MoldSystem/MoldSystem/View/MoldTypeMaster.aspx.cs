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
    public partial class MoldTypeMaster : MasterDetailPage
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
            MoldTypeBL objMoldTypeBL = new MoldTypeBL();

            List<MoldTypeBO> MoldTypeDataList = new List<MoldTypeBO>();

            if (formLoad)
            {
                MoldTypeDataList = objMoldTypeBL.GetMoldType(new MoldTypeBO());

            }
            else
            {
                MoldTypeBO criteria = new MoldTypeBO();
                criteria.MoldTypeID = string.IsNullOrEmpty(MoldTypeIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(MoldTypeIDTextBox.Text.Trim());
                criteria.MoldTypeDetail = MoldTypeDetailTextBox.Text.Trim();

                MoldTypeDataList = objMoldTypeBL.GetMoldType(criteria);
            }

            BindGrid(MoldTypeDataList);
        }

        private void BindGrid(List<MoldTypeBO> customerDataList)
        {
            MoldTypeGrid.DataSource = customerDataList;
            MoldTypeGrid.DataBind();
        }

        private void ResetScreen()
        {
            MoldTypeIDTextBox.Text = "";
            MoldTypeDetailTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            MoldTypeEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            MoldTypeEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            MoldTypeBL objMoldTypeBL = new MoldTypeBL();
            objMoldTypeBL.DeleteMoldType(new MoldTypeBO() { MoldTypeID = id });
            GetData();
        }
        #endregion
    }
}