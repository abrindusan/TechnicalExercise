#pragma checksum "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb4cb734b5c7dfa8831e6f7d76f2e8f18b91ec04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AndreiBrindusan.Web.Models.DrugUnits.Views_DrugUnits_Grouped), @"mvc.1.0.view", @"/Views/DrugUnits/Grouped.cshtml")]
namespace AndreiBrindusan.Web.Models.DrugUnits
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\_ViewImports.cshtml"
using AndreiBrindusan.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4cb734b5c7dfa8831e6f7d76f2e8f18b91ec04", @"/Views/DrugUnits/Grouped.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7be09d188351cc6b0acf55f107436849b83ec5c8", @"/Views/_ViewImports.cshtml")]
    public class Views_DrugUnits_Grouped : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<string, List<AndreiBrindusan.DataModel.DrugUnit>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    table {
        border-collapse: collapse;
        width: 100%;
    }

    th, td {
        padding: 8px;
        text-align: left;
        border-bottom: 1px solid #ddd;
    }

    th {
        background-color: #f2f2f2;
        font-weight: bold;
    }

    .group-heading {
        background-color: #f2f2f2;
        font-weight: bold;
    }

    .group-name {
        font-style: italic;
    }
</style>

");
#nullable restore
#line 30 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
     foreach (var group in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2 class=\"group-heading\">");
#nullable restore
#line 34 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
                             Write(group.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <table>\r\n            <thead>\r\n                <tr>\r\n                    <th>Drug Unit Name</th>\r\n                    <th>Depot ID</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
                 foreach (var drug in group.Value)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 46 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
                       Write(drug.DrugUnitName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 47 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
                       Write(drug.DepotId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 49 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 52 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\abrindusan\source\repos\AndreiBrindusan\AndreiBrindusan.Web\Views\DrugUnits\Grouped.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<string, List<AndreiBrindusan.DataModel.DrugUnit>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
