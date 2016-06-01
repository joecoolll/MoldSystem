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
    public partial class NewModEditForms : EditFormUserControl
    {
        private List<NewModBO> NewModData
        {
            get
            {
                return (ViewState["NewModData_EditForm"] as List<NewModBO>);
            }
            set
            {
                ViewState["NewModData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            NewModEditPopup.HeaderText = "New Mod";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void NewModEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int NewModID = int.Parse(e.Parameter);
            SetInitialEditData(NewModID);

            NewModEditPopup.JSProperties["cpNewModID"] = NewModID;
            NewModEditPopup.JSProperties["cpHeaderText"] = "New Mod";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            NewModBL objNewModBL = new NewModBL();
            NewModData = objNewModBL.GetNewMod(new NewModBO());
        }

        private void SetInitialEditData(int NewModID)
        {
            var newmodData = NewModData.Where(x => x.NewModID == NewModID).FirstOrDefault();
            if (newmodData == null)
                return;
            EditFormNewModIDTextBox.Text = newmodData.NewModID.ToString();
            EditFormNewModDetailTextBox.Text = newmodData.NewModDetail;
        }

        private void ClearData()
        {
            EditFormNewModIDTextBox.Text = "";
            EditFormNewModDetailTextBox.Text = "";
        }

        private void CreateNewMod()
        {
            NewModBO NewMod = new NewModBO();
            NewMod.NewModID = int.Parse(EditFormNewModIDTextBox.Text);
            NewMod.NewModDetail = EditFormNewModDetailTextBox.Text.Trim();

            NewModBL objNewModBL = new NewModBL();
            objNewModBL.InsertNewMod(NewMod);
        }

        private void EditNewMod(int id)
        {
            NewModBO NewMod = new NewModBO();
            NewMod.NewModID = id;
            NewMod.NewNewModID = int.Parse(EditFormNewModIDTextBox.Text);
            NewMod.NewModDetail = EditFormNewModDetailTextBox.Text.Trim();

            NewModBL objNewModBL = new NewModBL();
            objNewModBL.UpdateNewMod(NewMod);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateNewMod();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditNewMod(id);
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
                NewModEditPopup.JSProperties["cpNewModID"] = id;
            }
        }
        #endregion
    }
}