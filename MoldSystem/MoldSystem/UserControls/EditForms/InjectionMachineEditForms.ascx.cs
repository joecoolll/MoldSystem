using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class InjectionMachineEditForms : EditFormUserControl
    {
        private List<InjectionMachineBO> InjectionMachData
        {
            get
            {
                return (ViewState["InjectionMachData_EditForm"] as List<InjectionMachineBO>);
            }
            set
            {
                ViewState["InjectionMachData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            InjectionMachEditPopup.HeaderText = "Injection Machine";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void InjectionMachEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int InjectionMachID = int.Parse(e.Parameter);
            SetInitialEditData(InjectionMachID);

            InjectionMachEditPopup.JSProperties["cpInjectionMachID"] = InjectionMachID;
            InjectionMachEditPopup.JSProperties["cpHeaderText"] = "Injection Machine";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            InjectionMachineBL objInjectionMachineBL = new InjectionMachineBL();
            InjectionMachData = objInjectionMachineBL.GetInjectionMach(new InjectionMachineBO());
        }

        private void SetInitialEditData(int InjectionMachID)
        {
            var injectionmachData = InjectionMachData.Where(x => x.InjectionMachID == InjectionMachID).FirstOrDefault();
            if (injectionmachData == null)
                return;
            EditFormInjectionMachIDTextBox.Text = injectionmachData.InjectionMachID.ToString();
            EditFormInjectionMachNameTextBox.Text = injectionmachData.InjectionMachName;
        }

        private void ClearData()
        {
            EditFormInjectionMachIDTextBox.Text = "";
            EditFormInjectionMachNameTextBox.Text = "";
        }

        private void CreateInjectionMach()
        {
            InjectionMachineBO InjectionMach = new InjectionMachineBO();
            InjectionMach.InjectionMachID = int.Parse(EditFormInjectionMachIDTextBox.Text);
            InjectionMach.InjectionMachName = EditFormInjectionMachNameTextBox.Text.Trim();

            InjectionMachineBL objInjectionMachineBL = new InjectionMachineBL();
            objInjectionMachineBL.InsertInjectionMach(InjectionMach);
        }

        private void EditInjectionMach(int id)
        {
            InjectionMachineBO InjectionMach = new InjectionMachineBO();
            InjectionMach.InjectionMachID = id;
            InjectionMach.NewInjectionMachID = int.Parse(EditFormInjectionMachIDTextBox.Text);
            InjectionMach.InjectionMachName = EditFormInjectionMachNameTextBox.Text.Trim();

            InjectionMachineBL objInjectionMachineBL = new InjectionMachineBL();
            objInjectionMachineBL.UpdateInjectionMach(InjectionMach);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateInjectionMach();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditInjectionMach(id);
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
                InjectionMachEditPopup.JSProperties["cpInjectionMachID"] = id;
            }
        }
        #endregion
    }
}