using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:VInput runat=server></{0}:VInput>")]
    public class VInput : WebControl
    {
        public string Namespace { get; set; }
        public string Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
}
