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
    public partial class CustomerMaster : MasterDetailPage
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
            CustomerBL objCustomerBL = new CustomerBL();

            List<CustomerBO> customerDataList = new List<CustomerBO>();

            if (formLoad)
            {
                customerDataList = objCustomerBL.GetCustomer(new CustomerBO());

            }
            else
            {
                CustomerBO criteria = new CustomerBO();
                criteria.CustomerID = string.IsNullOrEmpty(CustomerIDTextBox.Text.Trim()) ? null : (int?)Convert.ToInt32(CustomerIDTextBox.Text.Trim());
                criteria.CustomerCode = CustomerCodeTextBox.Text.Trim();
                criteria.CustomerName = CustomerNameTextBox.Text.Trim();

                customerDataList = objCustomerBL.GetCustomer(criteria);
            }

            BindGrid(customerDataList);
        }

        private void BindGrid(List<CustomerBO> customerDataList)
        {
            CustomerGrid.DataSource = customerDataList;
            CustomerGrid.DataBind();
        }

        private void ResetScreen()
        {
            CustomerIDTextBox.Text = "";
            CustomerCodeTextBox.Text = "";
            CustomerNameTextBox.Text = "";

            GetData(true);
        }
        #endregion

        #region "Override Method"
        public override void SaveEditFormChanges(string parameters)
        {
            CustomerEditForm.SaveChanges(parameters); // TODO rename SaveChanges
            GetData();
        }

        public override void CancelEditFormChanges(string parameters)
        {
            CustomerEditForm.CancelChanges(parameters); // TODO rename SaveChanges
        }

        public override void DeleteEntry(string parameter)
        {
            int id = int.Parse(parameter);

            CustomerBL objCustomerBL = new CustomerBL();
            objCustomerBL.DeleteCustomer(new CustomerBO() { CustomerID = id });
            GetData();
        }






        #endregion

        
    }
}