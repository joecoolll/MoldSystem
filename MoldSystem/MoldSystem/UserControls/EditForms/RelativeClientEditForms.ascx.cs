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
    public partial class RelativeClientEditForms : EditFormUserControl
    {
        private List<RelativeClientBO> RelativeClientData
        {
            get
            {
                return (ViewState["RelativeClientData_EditForm"] as List<RelativeClientBO>);
            }
            set
            {
                ViewState["RelativeClientData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            RelativeClientEditPopup.HeaderText = "Relative Client";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }
        
        protected void RelativeClientEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int RelativeClientID = int.Parse(e.Parameter);
            SetInitialEditData(RelativeClientID);

            RelativeClientEditPopup.JSProperties["cpRelativeClientID"] = RelativeClientID;
            RelativeClientEditPopup.JSProperties["cpHeaderText"] = "Relative Client";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            RelativeClientBL objRelativeClientBL = new RelativeClientBL();
            RelativeClientData = objRelativeClientBL.GetRelativeClient(new RelativeClientBO());
        }

        private void SetInitialEditData(int RelativeClientID)
        {
            var relativeclientData = RelativeClientData.Where(x => x.RelativeClientID == RelativeClientID).FirstOrDefault();
            if (relativeclientData == null)
                return;
            EditFormRelativeClientIDTextBox.Text = relativeclientData.RelativeClientID.ToString();
            EditFormRelativeClientNameTextBox.Text = relativeclientData.RelativeClientName;
        }

        private void ClearData()
        {
            EditFormRelativeClientIDTextBox.Text = "";
            EditFormRelativeClientNameTextBox.Text = "";
        }

        private void CreateRelativeClient()
        {
            RelativeClientBO rclient = new RelativeClientBO();
            rclient.RelativeClientID = int.Parse(EditFormRelativeClientIDTextBox.Text);
            rclient.RelativeClientName = EditFormRelativeClientNameTextBox.Text.Trim();

            RelativeClientBL objRelativeClientBL = new RelativeClientBL();
            objRelativeClientBL.InsertRelativeClient(rclient);
        }

        private void EditRelativeClient(int id)
        {
            RelativeClientBO rclient = new RelativeClientBO();
            rclient.RelativeClientID = id;
            rclient.NewRelativeClientID = int.Parse(EditFormRelativeClientIDTextBox.Text);
            rclient.RelativeClientName = EditFormRelativeClientNameTextBox.Text.Trim();

            RelativeClientBL objRelativeClientBL = new RelativeClientBL();
            objRelativeClientBL.UpdateRelativeClient(rclient);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateRelativeClient();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditRelativeClient(id);
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
                RelativeClientEditPopup.JSProperties["cpRelativeClientID"] = id;
            }
        }
        #endregion
    }
}