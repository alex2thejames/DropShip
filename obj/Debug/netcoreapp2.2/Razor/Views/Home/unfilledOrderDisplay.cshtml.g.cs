#pragma checksum "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d55bbd0783f80dc6542c6656d2fa3cd702a9f10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DropShip.Pages.Home.Views_Home_unfilledOrderDisplay), @"mvc.1.0.view", @"/Views/Home/unfilledOrderDisplay.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/unfilledOrderDisplay.cshtml", typeof(DropShip.Pages.Home.Views_Home_unfilledOrderDisplay))]
namespace DropShip.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/Alexander/Documents/DropShip/Views/_ViewImports.cshtml"
using DropShip;

#line default
#line hidden
#line 2 "/Users/Alexander/Documents/DropShip/Views/_ViewImports.cshtml"
using DropShip.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d55bbd0783f80dc6542c6656d2fa3cd702a9f10", @"/Views/Home/unfilledOrderDisplay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"435d652a888a4adea0d5c3b60694d15c03976c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_unfilledOrderDisplay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FillOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 33, true);
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            EndContext();
            BeginContext(33, 1081, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d55bbd0783f80dc6542c6656d2fa3cd702a9f104546", async() => {
                BeginContext(39, 1068, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        .whiteBG {
            background: white;
        }
        .main {
            border-radius: 10px;
            height: 100vh;
            margin-bottom: -85px;
            overflow: auto;
            text-align: center;
        }
        table {
            margin-top: 4%;
        }
        td {
            vertical-align: middle !important;
        }
        .btn-success {
            height: 3vh !important;
            line-height: 1vh !important;
        }
        .btn-secondary {
            height: 3vh !important;
            width: 5vh !important;
            padding: 0 !important;
            line-height: 1vh !important;
        }
        #greenBG {
            height: 60%;
            width: 100%;
            max-width: 700px;
            margin: auto;
            margin-top: 2vw;
            text-align: center;
            background: green;
            color: white;
          ");
                WriteLiteral("  padding-top: 20vw;\n        }\n    </style>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1114, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(1115, 2378, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d55bbd0783f80dc6542c6656d2fa3cd702a9f106818", async() => {
                BeginContext(1121, 42, true);
                WriteLiteral("\n    <div class=\"whiteBG main container\">\n");
                EndContext();
#line 48 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
         if(ViewBag.UnfilledOrders.Count > 0){

#line default
#line hidden
                BeginContext(1210, 470, true);
                WriteLiteral(@"            <table class=""table table-striped table-bordered table-sm"">
                <tr>
                    <th colspan=""7""><h2>Order Search</h2></th>
                </tr>
                <tr>
                    <th>Customer Name</th>
                    <th>Customer Email</th>
                    <th>Shipping Method</th>
                    <th>Placed On</th>
                    <th>Order Number</th>
                    <th>Action</th>
                </tr>
");
                EndContext();
#line 61 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                 foreach(var j in ViewBag.UnfilledOrders){

#line default
#line hidden
                BeginContext(1739, 54, true);
                WriteLiteral("                    <tr>\n                        <td>\n");
                EndContext();
                BeginContext(1857, 34, true);
                WriteLiteral("                            <span>");
                EndContext();
                BeginContext(1892, 13, false);
#line 65 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                             Write(j.U.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(1905, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1907, 12, false);
#line 65 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                                            Write(j.U.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(1919, 101, true);
                WriteLiteral("</span>\n                        </td>\n                        <td>\n                            <span>");
                EndContext();
                BeginContext(2021, 9, false);
#line 68 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                             Write(j.U.Email);

#line default
#line hidden
                EndContext();
                BeginContext(2030, 101, true);
                WriteLiteral("</span>\n                        </td>\n                        <td>\n                            <span>");
                EndContext();
                BeginContext(2132, 16, false);
#line 71 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                             Write(j.ShippingMethod);

#line default
#line hidden
                EndContext();
                BeginContext(2148, 67, true);
                WriteLiteral("</span>\n                        </td>\n                        <td>\n");
                EndContext();
                BeginContext(2275, 34, true);
                WriteLiteral("                            <span>");
                EndContext();
                BeginContext(2310, 56, false);
#line 75 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                             Write(Convert.ToDateTime(j.CreatedAt).ToString("MMM dd, yyyy"));

#line default
#line hidden
                EndContext();
                BeginContext(2366, 8, true);
                WriteLiteral("</span>\n");
                EndContext();
                BeginContext(2574, 93, true);
                WriteLiteral("                        </td>\n                        <td>\n                            <span>");
                EndContext();
                BeginContext(2668, 13, false);
#line 80 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                             Write(j.OrderNumber);

#line default
#line hidden
                EndContext();
                BeginContext(2681, 95, true);
                WriteLiteral("</span>\n                        </td>\n                        <td>\n                            ");
                EndContext();
                BeginContext(2776, 272, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d55bbd0783f80dc6542c6656d2fa3cd702a9f1011372", async() => {
                    BeginContext(2841, 131, true);
                    WriteLiteral("\n                                <button class=\"btn btn-success\">Fill</button>\n                                <input type=\"hidden\"");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 2972, "\"", 2994, 1);
#line 85 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
WriteAttributeValue("", 2980, j.OrderNumber, 2980, 14, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(2995, 46, true);
                    WriteLiteral(" name=\"OrderNum\">\n                            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3048, 31, true);
                WriteLiteral("\n                            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3079, "\"", 3107, 2);
                WriteAttributeValue("", 3086, "/order/", 3086, 7, true);
#line 87 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
WriteAttributeValue("", 3093, j.OrderNumber, 3093, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3108, 171, true);
                WriteLiteral(">\n                                <button class=\"btn btn-secondary\">View</button>\n                            </a>\n                        </td>\n                    </tr>\n");
                EndContext();
#line 92 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
                }

#line default
#line hidden
                BeginContext(3297, 21, true);
                WriteLiteral("            </table>\n");
                EndContext();
#line 94 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
        } else{

#line default
#line hidden
                BeginContext(3334, 131, true);
                WriteLiteral("            <div id=\"greenBG\">\n                <h1>\n                    All Orders filled\n                </h1>\n            </div>\n");
                EndContext();
#line 100 "/Users/Alexander/Documents/DropShip/Views/Home/unfilledOrderDisplay.cshtml"
        }

#line default
#line hidden
                BeginContext(3475, 11, true);
                WriteLiteral("    </div>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3493, 8, true);
            WriteLiteral("\n</html>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
