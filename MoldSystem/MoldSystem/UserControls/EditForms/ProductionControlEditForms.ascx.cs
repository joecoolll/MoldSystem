using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ProductionControlEditForms : EditFormUserControl
    {
        private List<ProductionControlBO> ProdConData
        {
            get
            {
                return (ViewState["ProdConData_EditForm"] as List<ProductionControlBO>);
            }
            set
            {
                ViewState["ProdConData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            ProdConEditPopup.HeaderText = "Production Control";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void ProdConEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int ProdConID = int.Parse(e.Parameter);
            SetInitialEditData(ProdConID);

            ProdConEditPopup.JSProperties["cpProdConID"] = ProdConID;
            ProdConEditPopup.JSProperties["cpHeaderText"] = "Production Control";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            ProductionControlBL objProductionControlBL = new ProductionControlBL();
            ProdConData = objProductionControlBL.GetProdCon(new ProductionControlBO());
        }

        private void SetInitialEditData(int ProdConID)
        {
            var prodconData = ProdConData.Where(x => x.ProdConID == ProdConID).FirstOrDefault();
            if (prodconData == null)
                return;
            EditFormProdConIDTextBox.Text = prodconData.ProdConID.ToString();
            EditFormProdConNameTextBox.Text = prodconData.ProdConName;
        }

        private void ClearData()
        {
            EditFormProdConIDTextBox.Text = "";
            EditFormProdConNameTextBox.Text = "";
        }

        private void CreateProdCon()
        {
            ProductionControlBO ProdCon = new ProductionControlBO();
            ProdCon.ProdConID = int.Parse(EditFormProdConIDTextBox.Text);
            ProdCon.ProdConName = EditFormProdConNameTextBox.Text.Trim();

            ProductionControlBL objProductionControlBL = new ProductionControlBL();
            objProductionControlBL.InsertProdCon(ProdCon);
        }

        private void EditProdCon(int id)
        {
            ProductionControlBO ProdCon = new ProductionControlBO();
            ProdCon.ProdConID = id;
            ProdCon.NewProdConID = int.Parse(EditFormProdConIDTextBox.Text);
            ProdCon.ProdConName = EditFormProdConNameTextBox.Text.Trim();

            ProductionControlBL objProductionControlBL = new ProductionControlBL();
            objProductionControlBL.UpdateProdCon(ProdCon);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateProdCon();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditProdCon(id);
            }
        }

        public override void CancelChanges(string args)
        {
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
                ProdConEditPopup.JSProperties["cpProdConID"] = id;
            }
        }
        #endregion
    }
}