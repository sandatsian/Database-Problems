#pragma checksum "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6007d97331fc3f2b70ef35f9a5bd518fea35ec32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProblemThemes_Index), @"mvc.1.0.view", @"/Views/ProblemThemes/Index.cshtml")]
namespace AspNetCore
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
#line 1 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\_ViewImports.cshtml"
using BDProblems;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\_ViewImports.cshtml"
using BDProblems.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6007d97331fc3f2b70ef35f9a5bd518fea35ec32", @"/Views/ProblemThemes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5766f0e8bb442af8119332dd0daacc91bd3f9855", @"/Views/_ViewImports.cshtml")]
    public class Views_ProblemThemes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BDProblems.ProblemTheme>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
  
    ViewData["Title"] = "Problem's themes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <p><h1>Problem\'s Themes</h1></p>\n\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            <!-- <th>\n        ");
#nullable restore
#line 14 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
   Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </th>-->\n            <th>\n                ");
#nullable restore
#line 17 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Problem));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 20 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Theme));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 26 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <!--<td>\n                ");
#nullable restore
#line 30 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>-->\n                <td>\n                    ");
#nullable restore
#line 33 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProblemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 36 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Theme.ThemeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 39 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 42 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \n    </tbody>\n</table>\n<p>\n    <div class=\"btn btn-success\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1134, "\"", 1230, 3);
            WriteAttributeValue("", 1144, "location.href=\'", 1144, 15, true);
#nullable restore
#line 48 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
WriteAttributeValue("", 1159, Url.Action("Create", "ProblemThemes", new { id = ViewBag.ProblemId }), 1159, 70, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1229, "\'", 1229, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\n        Add new theme\n    </div>\n</p>\n<p>\n    ");
#nullable restore
#line 53 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
Write(Html.ActionLink("Back to problem", "Details","Problems", new { id = ViewBag.ProblemId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>\n<input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1394, "\"", 1420, 1);
#nullable restore
#line 55 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\ProblemThemes\Index.cshtml"
WriteAttributeValue("", 1402, ViewBag.ProblemId, 1402, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"themeId\" />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BDProblems.ProblemTheme>> Html { get; private set; }
    }
}
#pragma warning restore 1591
