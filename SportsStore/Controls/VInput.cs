using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
        public string Namespace { get; set; } = "SportsStore.Models";
        public string Model { get; set; } = "Order";
        public string Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());

            Type modelType = Type.GetType($"{Namespace}.{Model}");
            PropertyInfo propertyInfo = modelType.GetProperty(Property);
            var attribute = propertyInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (attribute != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", attribute.ErrorMessage);
            }
            output.RenderBeginTag("input");
            output.RenderEndTag();
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }
    }
}
