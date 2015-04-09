using System;
using System.Text;
using System.Web.UI;

namespace ConnectionSpy {
    public partial class Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            int id;
            Title = int.TryParse(Request["id"], out id)
                ? "Page " + id
                : "Home page";
            var html = new StringBuilder();
            html.AppendLine("<ul>");
            for (var i = 1; i < 11; i++) {
                var text = "Page " + i;
                var link = string.Format("<li><a href='Default.aspx?id={0}'>{1}</a></li>", i, text);
                html.AppendFormat(link);
            }
            html.AppendLine("</ul>");
            placeHolder.Controls.Add(
                new LiteralControl(html.ToString())
            );
        }
    }
}