#pragma checksum "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4d0a3ad0333d5057631e528518c90363aead558"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Problems_Details), @"mvc.1.0.view", @"/Views/Problems/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4d0a3ad0333d5057631e528518c90363aead558", @"/Views/Problems/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5766f0e8bb442af8119332dd0daacc91bd3f9855", @"/Views/_ViewImports.cshtml")]
    public class Views_Problems_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BDProblems.Problem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
  
    ViewData["Title"] = "Info about Problem";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\n        <h1>Info about Problem #");
#nullable restore
#line 7 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
                           Write(ViewBag.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n    </p>\n\n<div>\n    <h4>Problem</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 15 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Statement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 18 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Statement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 21 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Solution));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 24 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Solution));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 27 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Level));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 30 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Level.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 33 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 36 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Source.SourceName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 39 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 42 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Source.Info));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            Themes\n        </dt>\n        <dd class=\"col-sm-10\">\n");
#nullable restore
#line 48 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
             foreach (var item in Model.ProblemTheme)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Theme.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
                                                            
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt class=\"col-sm-2\">\n            Grades\n        </dt>\n        <dd class=\"col-sm-10\">\n");
#nullable restore
#line 56 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
             foreach (var item in Model.ProblemGrade)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Grade.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
                                                            
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\n    </dl>\n</div>\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4d0a3ad0333d5057631e528518c90363aead5589119", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "G:\Programming\2\istp\BDProblems_new\BDProblems\Views\Problems\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4d0a3ad0333d5057631e528518c90363aead55811257", async() => {
                WriteLiteral("See all list");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BDProblems.Problem> Html { get; private set; }
    }
}
#pragma warning restore 1591
