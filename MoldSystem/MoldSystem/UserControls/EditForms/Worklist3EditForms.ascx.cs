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
    public partial class Worklist3EditForms : EditFormUserControl
    {
        //private List<Worklist3BO> Worklist3Data
        //{
        //    get
        //    {
        //        return (ViewState["Worklist3Data_EditForm"] as List<Worklist3BO>);
        //    }
        //    set
        //    {
        //        ViewState["Worklist3Data_EditForm"] = value;
        //    }
        //}

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            Worklist3EditPopup.HeaderText = "Worklist3";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Worklist3EditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            //int DiffiIndexID = int.Parse(e.Parameter);
            //SetInitialEditData(DiffiIndexID);

            //DiffiIndexEditPopup.JSProperties["cpDiffiIndexID"] = DiffiIndexID;
            //DiffiIndexEditPopup.JSProperties["cpHeaderText"] = "Difficulty Index";
        }
        #endregion
    }
}