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
    public partial class WorkNoRunningEditForms : EditFormUserControl
    {
        private List<WorkNoRunningBO> WorkNoRunningData
        {
            get
            {
                return (ViewState["WorkNoRunningData_EditForm"] as List<WorkNoRunningBO>);
            }
            set
            {
                ViewState["WorkNoRunningData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            WorkNoRunningEditPopup.HeaderText = "Work No Running";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void WorkNoRunningEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            //int DiffiIndexID = int.Parse(e.Parameter);
            //SetInitialEditData(DiffiIndexID);

            //DiffiIndexEditPopup.JSProperties["cpDiffiIndexID"] = DiffiIndexID;
            //DiffiIndexEditPopup.JSProperties["cpHeaderText"] = "Difficulty Index";
        }
        #endregion 
    }
}