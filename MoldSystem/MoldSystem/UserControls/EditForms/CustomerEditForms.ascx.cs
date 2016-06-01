using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using Bussinesslogic;
using Common;

namespace MoldSystem.UserControls.EditForms
{
    public partial class CustomerEditForms : EditFormUserControl
    {
        private List<CustomerBO> CustomerData
        {
            get
            {
                return (ViewState["CustomerData_EditForm"] as List<CustomerBO>);
            }
            set
            {
                ViewState["CustomerData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            CustomerEditPopup.HeaderText = "Customer";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void CustomerEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int CustomerID = int.Parse(e.Parameter);
            SetInitialEditData(CustomerID);

            CustomerEditPopup.JSProperties["cpCustomerID"] = CustomerID;
            CustomerEditPopup.JSProperties["cpHeaderText"] = "Customer";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            CustomerBL objCustomerBL = new CustomerBL();
            CustomerData = objCustomerBL.GetCustomer(new CustomerBO());
        }

        private void SetInitialEditData(int CustomerID)
        {

            var customerData = CustomerData.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
            if (customerData == null)
                return;
            EditFormCustomerIDTextBox.Text = customerData.CustomerID.ToString();
            EditFormCustomerCodeTextBox.Text = customerData.CustomerCode;
            EditFormCustomerNameTextBox.Text = customerData.CustomerName;
        }

        private void ClearData()
        {
            EditFormCustomerIDTextBox.Text = "";
            EditFormCustomerCodeTextBox.Text = "";
            EditFormCustomerNameTextBox.Text = "";
        }

        private void CreateCustomer()
        {
            CustomerBO customer = new CustomerBO();
            customer.CustomerID = int.Parse(EditFormCustomerIDTextBox.Text);
            customer.CustomerCode = EditFormCustomerCodeTextBox.Text.Trim();
            customer.CustomerName = EditFormCustomerNameTextBox.Text.Trim();

            CustomerBL objCustomerBL = new CustomerBL();
            objCustomerBL.InsertCustomer(customer);

        }

        private void EditCustomer(int id)
        {
            CustomerBO customer = new CustomerBO();
            customer.CustomerID = Convert.ToInt32(id);
            customer.NewCustomerID = int.Parse(EditFormCustomerIDTextBox.Text);
            customer.CustomerCode = EditFormCustomerCodeTextBox.Text.Trim();
            customer.CustomerName = EditFormCustomerNameTextBox.Text.Trim();

            CustomerBL objCustomerBL = new CustomerBL();
            objCustomerBL.UpdateCustomer(customer);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            // Step 4
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateCustomer();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditCustomer(id);
            }
        }

        public override void CancelChanges(string args)
        {
            // Step 4
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
            {
                ClearData();
            }
            else if (callbackArgs[0] == "Edit")
            {
                ClearData();
                int id = int.Parse(callbackArgs[1]);
                SetInitialEditData(id);
                CustomerEditPopup.JSProperties["cpCustomerID"] = id;
            }
        }
        #endregion







    }
}