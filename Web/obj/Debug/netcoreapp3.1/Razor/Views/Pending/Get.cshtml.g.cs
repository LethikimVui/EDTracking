#pragma checksum "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c528eeb4152a63feab3ab465cb9a92c11cefc951"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pending_Get), @"mvc.1.0.view", @"/Views/Pending/Get.cshtml")]
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
#line 1 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c528eeb4152a63feab3ab465cb9a92c11cefc951", @"/Views/Pending/Get.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Pending_Get : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SharedObjects.ValueObjects.VPending>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frm-save-debugdata-body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ckeditor/ckeditor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pending.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
  
    ViewData["Title"] = "Pending";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-md-12"" style=""min-height: auto !important;height: auto !important;width: auto !important"">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class=""portlet light"" style=""min-height: auto !important;height: auto !important"">
                <div class=""portlet-title"">

                    <div class=""caption col-md-12"">
                        <span class=""caption-subject font-green-sharp bold uppercase"">
                            Pending
                        </span>
                    </div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c528eeb4152a63feab3ab465cb9a92c11cefc9515332", async() => {
                WriteLiteral(@"
                        <table class=""table table-bordered table-hover table-striped"">
                            <thead>
                                <tr class=""text-center bold"">
                                    <td>WorkWeek</td>
                                    <td>Workcell</td>
                                    <td>Part Number</td>
                                    <td>Date code</td>
                                    <td>Failure mode</td>
                                    <td>Root Cause</td>
                                    <td>Containment Action</td>
                                    <td>Corrective and Preventive Action</td>
                                    <td>Qty Impact</td>
                                    <td>Parts Cosigned or Turnkey</td>
                                    <td>FA No.</td>
                                    <td>SQE latest status</td>
                                    <td>MFR FA Result</td>
                                    <td>FIA ");
                WriteLiteral(@"needed</td>
                                    <td>FIA No.</td>
                                    <td>Responsible Person</td>                                   
                                    <td style=""width:100px"">Modification</td>
                                </tr>
                            </thead>
                            <tbody id=""table-data"">

");
#nullable restore
#line 43 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr class=\"text-center\">\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2361, "\"", 2366, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 46 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Wwyy);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2428, "\"", 2433, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 47 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.CustName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2499, "\"", 2504, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 48 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Pn);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2564, "\"", 2569, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 49 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Pn);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2629, "\"", 2634, 0);
                EndWriteAttribute();
                WriteLiteral("><textarea rows=\"6\" cols=\"40\" disabled>");
#nullable restore
#line 50 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                                                                   Write(item.FailureMode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2752, "\"", 2757, 0);
                EndWriteAttribute();
                WriteLiteral("><textarea rows=\"6\" cols=\"40\" disabled>");
#nullable restore
#line 51 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                                                                   Write(item.RootCause);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 2873, "\"", 2878, 0);
                EndWriteAttribute();
                WriteLiteral("><textarea rows=\"6\" cols=\"40\" disabled>");
#nullable restore
#line 52 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                                                                   Write(item.ContainmentAction);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 3002, "\"", 3007, 0);
                EndWriteAttribute();
                WriteLiteral("><textarea rows=\"6\" cols=\"40\" disabled>");
#nullable restore
#line 53 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                                                                   Write(item.CorrectiveandPreventiveAction);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 3143, "\"", 3148, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 54 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Qty);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 55 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                         if (item.PartsCosignedOrTurnkey == "1")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td");
                BeginWriteAttribute("id", " id=\"", 3338, "\"", 3343, 0);
                EndWriteAttribute();
                WriteLiteral(">Parts Cosigned</td>\r\n");
#nullable restore
#line 58 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                        }
                                        else if (item.PartsCosignedOrTurnkey == "2")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td");
                BeginWriteAttribute("id", " id=\"", 3585, "\"", 3590, 0);
                EndWriteAttribute();
                WriteLiteral(">Turnkey </td>\r\n");
#nullable restore
#line 62 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td");
                BeginWriteAttribute("id", " id=\"", 3786, "\"", 3791, 0);
                EndWriteAttribute();
                WriteLiteral("></td>\r\n");
#nullable restore
#line 66 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <td");
                BeginWriteAttribute("id", " id=\"", 3886, "\"", 3891, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 67 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Fano);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 3953, "\"", 3958, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 68 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.SqelatestStatus);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 4031, "\"", 4036, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 69 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Mfrfaresult);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 70 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                         if (item.Fianeeded == "1")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td");
                BeginWriteAttribute("id", " id=\"", 4221, "\"", 4226, 0);
                EndWriteAttribute();
                WriteLiteral(">Yes</td>\r\n");
#nullable restore
#line 73 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                        }
                                        else if (item.Fianeeded == "0")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td");
                BeginWriteAttribute("id", " id=\"", 4444, "\"", 4449, 0);
                EndWriteAttribute();
                WriteLiteral(">No</td>\r\n");
#nullable restore
#line 77 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td");
                BeginWriteAttribute("id", " id=\"", 4639, "\"", 4644, 0);
                EndWriteAttribute();
                WriteLiteral("></td>\r\n");
#nullable restore
#line 81 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <td");
                BeginWriteAttribute("id", " id=\"", 4739, "\"", 4744, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 82 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.Fiano);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td");
                BeginWriteAttribute("id", " id=\"", 4807, "\"", 4812, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 83 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                             Write(item.ResponsiblePerson);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td ><input type=\"text\"");
                BeginWriteAttribute("id", " id=\"", 4907, "\"", 4934, 2);
                WriteAttributeValue("", 4912, "txt-rm-", 4912, 7, true);
#nullable restore
#line 84 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
WriteAttributeValue("", 4919, item.PendingId, 4919, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\"/></td>\r\n\r\n                                        <td class=\"text-center\">\r\n                                            <a id=\"btn-approve\" class=\"btn default btn-xs red\" data-id=\"");
#nullable restore
#line 87 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                                                                                   Write(item.PendingId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" title=\"Approve\"> <span class=\"glyphicon glyphicon-ok\"></span></a>\r\n                                            <a id=\"btn-reject\" class=\"btn default btn-xs red\" data-id=\"");
#nullable restore
#line 88 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                                                                                  Write(item.PendingId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" title=\"Reject\"> <span class=\"glyphicon glyphicon-remove\"></span></a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 91 "C:\Users\1099969\Desktop\Development\GitHub\EDTracking\Web\Views\Pending\Get.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c528eeb4152a63feab3ab465cb9a92c11cefc95121453", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c528eeb4152a63feab3ab465cb9a92c11cefc95122553", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SharedObjects.ValueObjects.VPending>> Html { get; private set; }
    }
}
#pragma warning restore 1591
