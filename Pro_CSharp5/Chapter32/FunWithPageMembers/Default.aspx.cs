using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetBrowserStats_Click(object sender, EventArgs e) {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<ul>");
        sb.AppendFormat("<li>Is the browser AOL {0}</li>", Request.Browser.AOL);
        sb.AppendFormat("<li>ActiveX Supported {0}</li>", Request.Browser.ActiveXControls);
        sb.AppendFormat("<li>Beta? {0}</li>", Request.Browser.Beta);
        sb.AppendFormat("<li>Java Applets Supported {0}</li>", Request.Browser.JavaApplets);
        sb.AppendFormat("<li>Cookies Supported {0}</li>", Request.Browser.Cookies);
        sb.AppendFormat("<li>VBScript Supported {0}</li>", Request.Browser.VBScript);
        sb.AppendFormat("<li>ECMA Script Version Supported {0}</li>", Request.Browser.EcmaScriptVersion);
        sb.AppendLine("</ul>");
        lblOutput.Text = sb.ToString();
    }
    protected void btnRedirect_Click(object sender, EventArgs e) {
        Response.Redirect("http://www.microsoft.com/");
    }
    protected void btnWriteToResponse_Click(object sender, EventArgs e) {
        Response.Write("<b>My name is</b><br />");
        Response.Write(this.ToString());
        
        Response.WriteFile("text.txt");
        
        Response.Flush();
    }
}