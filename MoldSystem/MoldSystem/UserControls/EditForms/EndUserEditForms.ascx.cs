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
    public partial class EndUserEditForms : EditFormUserControl
    {
        private List<EndUserBO> EndUserData
        {
            get
            {
                return (ViewState["EndUserData_EditForm"] as List<EndUserBO>);
            }
            set
            {
                ViewState["EndUserData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            EndUserEditPopup.HeaderText = "End User";
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void EndUserEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int EndUserID = int.Parse(e.Parameter);
            SetInitialEditData(EndUserID);

            EndUserEditPopup.JSProperties["cpEndUserID"] = EndUserID;
            EndUserEditPopup.JSProperties["cpHeaderText"] = "End User";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            EndUserBL objEndUserBL = new EndUserBL();
            EndUserData = objEndUserBL.GetEndUser(new EndUserBO());
        }

        private void SetInitialEditData(int EndUserID)
        {
            var enduserData = EndUserData.Where(x => x.EndUserID == EndUserID).FirstOrDefault();
            if (enduserData == null)
                return;
            EditFormEndUserIDTextBox.Text = enduserData.EndUserID.ToString();
            EditFormEndUserNameTextBox.Text = enduserData.EndUserName;
        }

        private void ClearData()
        {
            EditFormEndUserIDTextBox.Text = "";
            EditFormEndUserNameTextBox.Text = "";
        }

        private void CreateEndUser()
        {
            EndUserBO enduser = new EndUserBO();
            enduser.EndUserID = int.Parse(EditFormEndUserIDTextBox.Text);
            enduser.EndUserName = EditFormEndUserNameTextBox.Text.Trim();

            EndUserBL objEndUserBL = new EndUserBL();
            objEndUserBL.InsertEndUser(enduser);
        }

        private void EditEndUser(int id)
        {
            EndUserBO enduser = new EndUserBO();
            enduser.EndUserID = id;
            enduser.NewEndUserID = int.Parse(EditFormEndUserIDTextBox.Text);
            enduser.EndUserName = EditFormEndUserNameTextBox.Text.Trim();

            EndUserBL objEndUserBL = new EndUserBL();
            objEndUserBL.UpdateEndUser(enduser);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateEndUser();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditEndUser(id);
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
                EndUserEditPopup.JSProperties["cpEndUserID"] = id;
            }
        }
        #endregion
    }
}