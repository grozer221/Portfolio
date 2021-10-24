#pragma checksum "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Projects_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Projects/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\_ViewImports.cshtml"
using Portfolio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\_ViewImports.cshtml"
using Portfolio.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\_ViewImports.cshtml"
using Portfolio.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e59b3ea7c444f32c9088f2e6e94d1eae0c33fba9", @"/Areas/Admin/Views/Projects/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d751bc3100990b00143b5f3797be725f5207d7f7", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Projects_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjectsIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-target", "/admin/projects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Portfolio.TagHelpers.ColorPreviewTagHelper __Portfolio_TagHelpers_ColorPreviewTagHelper;
        private global::Portfolio.TagHelpers.PaginationTagHelper __Portfolio_TagHelpers_PaginationTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
  
    ViewData["Title"] = "Projects (AdminPanel)";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Projects</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba96676", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>");
#nullable restore
#line 14 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
       Write(Html.DisplayNameFor(modelItem => modelItem.Projects[0].Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 15 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
       Write(Html.DisplayNameFor(modelItem => modelItem.Projects[0].ImageURL));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 16 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
       Write(Html.DisplayNameFor(modelItem => modelItem.Projects[0].SiteLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 17 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
       Write(Html.DisplayNameFor(modelItem => modelItem.Projects[0].Technologies));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>Actions</th>\r\n    </tr>\r\n");
#nullable restore
#line 20 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
     foreach (var project in Model.Projects)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 24 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => project.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <div class=\"wrapperImagePreview\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 860, "\"", 906, 1);
#nullable restore
#line 28 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
WriteAttributeValue("", 866, "/media/projects/" + project.ImageURL, 866, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"ProjectImage\" class=\"imagePreview rounded\" />\r\n                </div>\r\n            </td>\r\n            <td>\r\n                <div>\r\n                    <span>");
#nullable restore
#line 33 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     Write(Html.DisplayNameFor(modelItem => project.SiteLink));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </span>\r\n");
#nullable restore
#line 34 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     if (project.SiteLink == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>&mdash;</span>\r\n");
#nullable restore
#line 37 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1351, "\"", 1375, 1);
#nullable restore
#line 40 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
WriteAttributeValue("", 1358, project.SiteLink, 1358, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                               Write(project.SiteLink);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 41 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <span>");
#nullable restore
#line 45 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     Write(Html.DisplayNameFor(modelItem => project.DesktopAppLink));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </span>\r\n");
#nullable restore
#line 46 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     if (project.DesktopAppLink == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>&mdash;</span>\r\n");
#nullable restore
#line 49 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1791, "\"", 1821, 1);
#nullable restore
#line 52 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
WriteAttributeValue("", 1798, project.DesktopAppLink, 1798, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                                     Write(project.DesktopAppLink);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 53 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div>\r\n                    <span>");
#nullable restore
#line 56 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     Write(Html.DisplayNameFor(modelItem => project.AndroidAppLink));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </span>\r\n");
#nullable restore
#line 57 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     if (project.AndroidAppLink == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>&mdash;</span>\r\n");
#nullable restore
#line 60 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 2241, "\"", 2271, 1);
#nullable restore
#line 63 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
WriteAttributeValue("", 2248, project.AndroidAppLink, 2248, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 63 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                                     Write(project.AndroidAppLink);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 64 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div>\r\n                    <span>");
#nullable restore
#line 67 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     Write(Html.DisplayNameFor(modelItem => project.IOSAppLink));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </span>\r\n");
#nullable restore
#line 68 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                     if (project.IOSAppLink == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>&mdash;</span>\r\n");
#nullable restore
#line 71 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 2683, "\"", 2709, 1);
#nullable restore
#line 74 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
WriteAttributeValue("", 2690, project.IOSAppLink, 2690, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 74 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                                 Write(project.IOSAppLink);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 75 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 79 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                 if (project.Technologies != null && project.Technologies.Count > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul>\r\n\r\n");
#nullable restore
#line 83 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                         foreach (var technology in project.Technologies)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"d-flex align-items-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("color-preview", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba918237", async() => {
            }
            );
            __Portfolio_TagHelpers_ColorPreviewTagHelper = CreateTagHelper<global::Portfolio.TagHelpers.ColorPreviewTagHelper>();
            __tagHelperExecutionContext.Add(__Portfolio_TagHelpers_ColorPreviewTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                      WriteLiteral(technology.Color);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Portfolio_TagHelpers_ColorPreviewTagHelper.Color = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("color", __Portfolio_TagHelpers_ColorPreviewTagHelper.Color, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"ml-1\">");
#nullable restore
#line 87 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                         Write(technology.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </li>\r\n");
#nullable restore
#line 89 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n");
#nullable restore
#line 91 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba920628", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                       WriteLiteral(project.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba922870", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                          WriteLiteral(project.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba925118", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
                                         WriteLiteral(project.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 100 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<div class=\"d-flex w-100 justify-content-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pagination", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59b3ea7c444f32c9088f2e6e94d1eae0c33fba927653", async() => {
            }
            );
            __Portfolio_TagHelpers_PaginationTagHelper = CreateTagHelper<global::Portfolio.TagHelpers.PaginationTagHelper>();
            __tagHelperExecutionContext.Add(__Portfolio_TagHelpers_PaginationTagHelper);
#nullable restore
#line 104 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
__Portfolio_TagHelpers_PaginationTagHelper.PageCount = Model.Page.TotalPages;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __Portfolio_TagHelpers_PaginationTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Portfolio_TagHelpers_PaginationTagHelper.PageTarget = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 104 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
__Portfolio_TagHelpers_PaginationTagHelper.PageNumber = Model.Page.PageNumber;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-number", __Portfolio_TagHelpers_PaginationTagHelper.PageNumber, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 104 "D:\Projects\Portfolio\Portfolio\Areas\Admin\Views\Projects\Index.cshtml"
__Portfolio_TagHelpers_PaginationTagHelper.PageRange = 10;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-range", __Portfolio_TagHelpers_PaginationTagHelper.PageRange, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectsIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
