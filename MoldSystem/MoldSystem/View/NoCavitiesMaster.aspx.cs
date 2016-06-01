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
    public partial class NoCavitiesMaster : MasterDetailPage
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
            NoCavitiesBL objNoCavitiesBL = new NoCavitiesBL();

            List<NoCavitiesBO> NoCavDataList = new List<NoCavitiesBO>();

            if (formLoad)
            {
                NoCavDataList = objNoCavitiesBL.GetNoCav(new NoCavitiesBO());

            }
            else
            {
                NoCavitiesBO criteria = new NoCavitiesBO();
                criteria.NoCavID = string.IsNullOrEmpty(NoCavIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(NoCavIDTextBox.Text.Trim());
                criteria.NoCavDetail = NoCavDetailTextBox.Text.Trim();

                NoCavDataList = objNoCavitiesBL.GetNoCav(criteria);
            }

            BindGrid(NoCavDataList);
        }

        private void BindGrid(List<NoCavitiesBO> customerDataList)
        {
            NoCavGrid.DataSource = customerDataList;
            NoCavGrid.DataBind();
        }

        private void ResetScreen()
        {
            NoCavIDTextBox.Text = "";
            NoCavDetailTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            NoCavEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            NoCavEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            NoCavitiesBL objNoCavitiesBL = new NoCavitiesBL();
            objNoCavitiesBL.DeleteNoCav(new NoCavitiesBO() { NoCavID = id });
            GetData();
        }
        #endregion
    }
}