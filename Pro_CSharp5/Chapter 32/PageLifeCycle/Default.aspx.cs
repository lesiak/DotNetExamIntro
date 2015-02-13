using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        Response.Write("Load event fired!");
    }

    protected void Page_Unload(object sender, EventArgs e) {
        // No longer possible to emit data to the HTTP
        // response, so we will write to a local file.
        //System.IO.File.WriteAllText(@"C:\MyLog.txt", "Page unloading!");
    }



    protected void Page_Error(object sender, EventArgs e) {
        Response.Clear();
        Response.Write("I am sorry...I can't find a required file.<br>");
        Response.Write(string.Format("The error was: <b>{0}</b>",
            Server.GetLastError().Message));
        Server.ClearError();
    }

    protected void btnTriggerError_Click(object sender, EventArgs e) {
        System.IO.File.ReadAllText(@"C:\IDontExist.txt");
    }
}