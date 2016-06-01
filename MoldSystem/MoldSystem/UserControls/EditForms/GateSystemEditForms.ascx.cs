using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class GateSystemEditForms : EditFormUserControl
    {
        private List<GateSystemBO> GateSysData
        {
            get
            {
                return (ViewState["GateSysData_EditForm"] as List<GateSystemBO>);
            }
            set
            {
                ViewState["GateSysData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            GateSysEditPopup.HeaderText = "Gate System";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void GateSysEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int GateSysID = int.Parse(e.Parameter);
            SetInitialEditData(GateSysID);

            GateSysEditPopup.JSProperties["cpGateSysID"] = GateSysID;
            GateSysEditPopup.JSProperties["cpHeaderText"] = "Gate System";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            GateSystemBL objGateSystemBL = new GateSystemBL();
            GateSysData = objGateSystemBL.GetGateSys(new GateSystemBO());
        }

        private void SetInitialEditData(int GateSysID)
        {
            var gatesysData = GateSysData.Where(x => x.GateSysID == GateSysID).FirstOrDefault();
            if (gatesysData == null)
                return;
            EditFormGateSysIDTextBox.Text = gatesysData.GateSysID.ToString();
            EditFormGateSysNameTextBox.Text = gatesysData.GateSysName;
        }

        private void ClearData()
        {
            EditFormGateSysIDTextBox.Text = "";
            EditFormGateSysNameTextBox.Text = "";
        }

        private void CreateGateSys()
        {
            GateSystemBO GateSys = new GateSystemBO();
            GateSys.GateSysID = int.Parse(EditFormGateSysIDTextBox.Text);
            GateSys.GateSysName = EditFormGateSysNameTextBox.Text.Trim();

            GateSystemBL objGateSystemBL = new GateSystemBL();
            objGateSystemBL.InsertGateSys(GateSys);
        }

        private void EditGateSys(int id)
        {
            GateSystemBO GateSys = new GateSystemBO();
            GateSys.GateSysID = id;
            GateSys.NewGateSysID = int.Parse(EditFormGateSysIDTextBox.Text);
            GateSys.GateSysName = EditFormGateSysNameTextBox.Text.Trim();

            GateSystemBL objGateSystemBL = new GateSystemBL();
            objGateSystemBL.UpdateGateSys(GateSys);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateGateSys();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditGateSys(id);
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
                GateSysEditPopup.JSProperties["cpGateSysID"] = id;
            }
        }
        #endregion
    }
}