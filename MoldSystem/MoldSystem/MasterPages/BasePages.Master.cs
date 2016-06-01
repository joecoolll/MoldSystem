using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace MoldSystem.MasterPages
{
    public partial class BasePages : System.Web.UI.MasterPage
    {
        protected BasePage BasePage { get { return Page as BasePage; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MainCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = CommonUtils.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;
            if (args[0] == "SaveEditForm")
                BasePage.SaveEditFormChanges(args[2]);
            if (args[0] == "CancelEditForm")
                BasePage.CancelEditFormChanges(args[2]);
            if (args[0] == "DeleteEntry")
                BasePage.DeleteEntry(args[1]);
        }

        protected void HiddenField_Init(object sender, EventArgs e)
        {
            CommonUtils.RegisterStateHiddenField(HiddenField);
        }
    }
}