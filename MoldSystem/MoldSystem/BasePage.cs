using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web;

public abstract class BasePage : System.Web.UI.Page
{
    public virtual void SaveEditFormChanges(string args) { }
    public virtual void CancelEditFormChanges(string args) { }
    public virtual void DeleteEntry(string args) { }
    
}

public abstract class MasterDetailPage : BasePage
{
    public abstract MasterUserControl MasterUC { get; }

    public long SelectedItemID { get { return MasterUC.SelectedItemID; } }
    public void Update()
    {
        MasterUC.Update(); // should force update detail
    }
}
public abstract class MasterUserControl : ViewUserControl
{
    public new MasterDetailPage OwnerPage { get { return Page as MasterDetailPage; } }
    
}

public abstract class ViewUserControl : UserControl
{
    public abstract void Update();

    public BasePage OwnerPage { get { return Page as BasePage; } }
    public virtual long SelectedItemID { get; set; }
}

public abstract class EditFormUserControl : UserControl
{
    public abstract void SaveChanges(string args);
    public abstract void CancelChanges(string args);
}
