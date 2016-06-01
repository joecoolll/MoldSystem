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
    public partial class InjectionMachineMaster : MasterDetailPage
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
            InjectionMachineBL objInjectionMachineBL = new InjectionMachineBL();

            List<InjectionMachineBO> InjectionMachDataList = new List<InjectionMachineBO>();

            if (formLoad)
            {
                InjectionMachDataList = objInjectionMachineBL.GetInjectionMach(new InjectionMachineBO());

            }
            else
            {
                InjectionMachineBO criteria = new InjectionMachineBO();
                criteria.InjectionMachID = string.IsNullOrEmpty(InjectionMachIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(InjectionMachIDTextBox.Text.Trim());
                criteria.InjectionMachName = InjectionMachNameTextBox.Text.Trim();

                InjectionMachDataList = objInjectionMachineBL.GetInjectionMach(criteria);
            }

            BindGrid(InjectionMachDataList);
        }

        private void BindGrid(List<InjectionMachineBO> customerDataList)
        {
            InjectionMachGrid.DataSource = customerDataList;
            InjectionMachGrid.DataBind();
        }

        private void ResetScreen()
        {
            InjectionMachIDTextBox.Text = "";
            InjectionMachNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            InjectionMachEditForm.SaveChanges(parameters);
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            InjectionMachEditForm.CancelChanges(parameters);
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            InjectionMachineBL objInjectionMachineBL = new InjectionMachineBL();
            objInjectionMachineBL.DeleteInjectionMach(new InjectionMachineBO() { InjectionMachID = id });
            GetData();
        }
        #endregion

    }
}