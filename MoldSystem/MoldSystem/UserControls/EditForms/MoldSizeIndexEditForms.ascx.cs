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
    public partial class MoldSizeIndexEditForms : EditFormUserControl
    {
        private List<MoldSizeIndexBO> SizeIndexData
        {
            get
            {
                return (ViewState["SizeIndexData_EditForm"] as List<MoldSizeIndexBO>);
            }
            set
            {
                ViewState["SizeIndexData_EditForm"] = value;
            }
        }

        #region Event
        protected void Page_Init(object sender, EventArgs e)
        {
            SizeIndexEditPopup.HeaderText = "Mold Size Index";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        protected void SizeIndexEditPopup_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            int SizeIndexID = int.Parse(e.Parameter);
            SetInitialEditData(SizeIndexID);

            SizeIndexEditPopup.JSProperties["cpSizeIndexID"] = SizeIndexID;
            SizeIndexEditPopup.JSProperties["cpHeaderText"] = "Mold Size Index";
        }
        #endregion


        #region Method
        private void GetAllData()
        {
            MoldSizeIndexBL objMoldSizeIndexBL = new MoldSizeIndexBL();
            SizeIndexData = objMoldSizeIndexBL.GetSizeIndex(new MoldSizeIndexBO());
        }

        private void SetInitialEditData(int SizeIndexID)
        {
            var sizeindexData = SizeIndexData.Where(x => x.SizeIndexID == SizeIndexID).FirstOrDefault();
            if (sizeindexData == null)
                return;
            EditFormSizeIndexIDTextBox.Text = sizeindexData.SizeIndexID.ToString();
            EditFormSizeIndexNameTextBox.Text = sizeindexData.SizeIndexName;
        }

        private void ClearData()
        {
            EditFormSizeIndexIDTextBox.Text = "";
            EditFormSizeIndexNameTextBox.Text = "";
        }

        private void CreateSizeIndex()
        {
            MoldSizeIndexBO SizeIndex = new MoldSizeIndexBO();
            SizeIndex.SizeIndexID = int.Parse(EditFormSizeIndexIDTextBox.Text);
            SizeIndex.SizeIndexName = EditFormSizeIndexNameTextBox.Text.Trim();

            MoldSizeIndexBL objMoldSizeIndexBL = new MoldSizeIndexBL();
            objMoldSizeIndexBL.InsertSizeIndex(SizeIndex);
        }

        private void EditSizeIndex(int id)
        {
            MoldSizeIndexBO SizeIndex = new MoldSizeIndexBO();
            SizeIndex.SizeIndexID = id;
            SizeIndex.NewSizeIndexID = int.Parse(EditFormSizeIndexIDTextBox.Text);
            SizeIndex.SizeIndexName = EditFormSizeIndexNameTextBox.Text.Trim();

            MoldSizeIndexBL objMoldSizeIndexBL = new MoldSizeIndexBL();
            objMoldSizeIndexBL.UpdateSizeIndex(SizeIndex);
        }
        #endregion

        #region "Override Method"
        public override void SaveChanges(string args)
        {
            var callbackArgs = CommonUtils.DeserializeCallbackArgs(args);

            if (callbackArgs[0] == "New")
                CreateSizeIndex();
            else if (callbackArgs[0] == "Edit")
            {
                int id = int.Parse(callbackArgs[1]);
                EditSizeIndex(id);
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
                SizeIndexEditPopup.JSProperties["cpSizeIndexID"] = id;
            }
        }
        #endregion
    }
}