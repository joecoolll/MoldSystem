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
    public partial class NoCavitiesEditForms : EditFormUserControl
    {
        private List<NoCavitiesBO> NoCavData
        {
            get
            {
                return (ViewState["NoCavData_EditForm"] as List<NoCavitiesBO>);
            }
            set
            {
                ViewState["NoCavData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            NoCavEditPopup.HeaderText = "No Cavities";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void NoCavEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int NoCavID = int.Parse(e.Parameter);
            SetInitialEditData(NoCavID);

            NoCavEditPopup.JSProperties["cpNoCavID"] = NoCavID;
            NoCavEditPopup.JSProperties["cpHeaderText"] = "No Cavities";
        }
        #endregion

        #region Method
        private void GetAllData()
        {
            NoCavitiesBL objNoCavitiesBL = new NoCavitiesBL();
            NoCavData = objNoCavitiesBL.GetNoCav(new NoCavitiesBO());
        }

        private void SetInitialEditData(int NoCavID)
        {
            var nocavData = NoCavData.Where(x => x.NoCavID == NoCavID).FirstOrDefault();
            if (nocavData == null)
                return;
            EditFormNoCavIDTextBox.Text = nocavData.NoCavID.ToString();
            EditFormNoCavDetailTextBox.Text = nocavData.NoCavDetail;
        }

        private void ClearData()
        {
            EditFormNoCavIDTextBox.Text = "";
            EditFormNoCavDetailTextBox.Text = "";
        }

        private void CreateNoCav()
        {
            NoCavitiesBO NoCav = new NoCavitiesBO();
            NoCav.NoCavID = int.Parse(EditFormNoCavIDTextBox.Text);
            NoCav.NoCavDetail = EditFormNoCavDetailTextBox.Text.Trim();

            NoCavitiesBL objNoCavitiesBL = new NoCavitiesBL();
            objNoCavitiesBL.InsertNoCav(NoCav);
        }

        private void EditNoCav(int id)
        {
            NoCavitiesBO NoCav = new NoCavitiesBO();
            NoCav.NoCavID = id;
            NoCav.NewNoCavID = int.Parse(EditFormNoCavIDTextBox.Text);
            NoCav.NoCavDetail = EditFormNoCavDetailTextBox.Text.Trim();

            NoCavitiesBL objNoCavitiesBL = new NoCavitiesBL();
            objNoCavitiesBL.UpdateNoCav(NoCav);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateNoCav();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditNoCav(id);
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
                NoCavEditPopup.JSProperties["cpNoCavID"] = id;
            }
        }
        #endregion
    }
}