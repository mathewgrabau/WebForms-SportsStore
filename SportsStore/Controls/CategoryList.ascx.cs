using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace SportsStore.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<string> GetCategories()
        {
            return new Repository().Products.Select(p => p.Category).Distinct().OrderBy(x => x);
        }

        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return $"<a href='{path}'>Home</a>";
        }

        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];

            string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary { { "category", category }, { "page", "1" } }).VirtualPath;

            return $"<a href='{path}' {(category == selectedCategory ? "class='selected'" : string.Empty)}>{category}</a>";
        }
    }
}