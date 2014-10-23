using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using CommonSnappableTypes;

namespace CSharpSnapIn
{
    [CompanyInfo(CompanyName="My Company", CompanyUrl="www.mycompany.com")]
    public class CSharpModule : IAppFunctionality
    {

        void IAppFunctionality.DoIt() {
            MessageBox.Show("you have just used the C# snap in");
        }
    }
}
