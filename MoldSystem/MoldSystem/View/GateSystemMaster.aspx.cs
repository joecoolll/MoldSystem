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
    public partial class GateSystemMaster : MasterDetailPage
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
            GateSystemBL objGateSystemBL = new GateSystemBL();

            List<GateSystemBO> GateSysDataList = new List<GateSystemBO>();

            if (formLoad)
            {
                GateSysDataList = objGateSystemBL.GetGateSys(new GateSystemBO());

            }
            else
            {
                GateSystemBO criteria = new GateSystemBO();
                criteria.GateSysID = string.IsNullOrEmpty(GateSysIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(GateSysIDTextBox.Text.Trim());
                criteria.GateSysName = GateSysNameTextBox.Text.Trim();

                GateSysDataList = objGateSystemBL.GetGateSys(criteria);
            }

            BindGrid(GateSysDataList);
        }

        private void BindGrid(List<GateSystemBO> customerDataList)
        {
            GateSysGrid.DataSource = customerDataList;
            GateSysGrid.DataBind();
        }

        private void ResetScreen()
        {
            GateSysIDTextBox.Text = "";
            GateSysNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            GateSysEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            GateSysEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            GateSystemBL objGateSystemBL = new GateSystemBL();
            objGateSystemBL.DeleteGateSys(new GateSystemBO() { GateSysID = id });
            GetData();
        }
        #endregion
    }
}