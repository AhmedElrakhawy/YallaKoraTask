#pragma checksum "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "554ab19586a60fe91d54fc589bc83b08b973efc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Index), @"mvc.1.0.view", @"/Views/Main/Index.cshtml")]
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
#line 1 "D:\My work\Projects\Solution1\YallaKora.Web\Views\_ViewImports.cshtml"
using YallaKora.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\My work\Projects\Solution1\YallaKora.Web\Views\_ViewImports.cshtml"
using YallaKora.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
using YallaKora.Web.VM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"554ab19586a60fe91d54fc589bc83b08b973efc6", @"/Views/Main/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27da9eab3c749560c4094824de7028c9eccca4ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MainIndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
  
    ViewBag.Title = "Main Page";
    var Slider = new List<string>()
{
        "First slide",
        "Second slide",
        "Third slide"
    };

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"" id=""MainPage"">

    <div class=""col-lg-12"">
        <div class=""card"">
            <div id=""carouselExampleIndicators"" class=""card-header carousel slide"" data-ride=""carousel"">
                <ol class=""carousel-indicators"">
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
                </ol>
                <div class=""carousel-inner"">
");
#nullable restore
#line 27 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                     for (int i = 0; i < Model.GallaryPhotos.Count(); i++)
                    {
                        if (i == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"carousel-item active\">\r\n                                <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1101, "\"", 1130, 1);
#nullable restore
#line 32 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
WriteAttributeValue("", 1107, Model.GallaryPhotos[0], 1107, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"First slide\">\r\n                            </div>\r\n");
#nullable restore
#line 34 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"carousel-item\">\r\n                                <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1387, "\"", 1416, 1);
#nullable restore
#line 38 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
WriteAttributeValue("", 1393, Model.GallaryPhotos[i], 1393, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1417, "\"", 1433, 1);
#nullable restore
#line 38 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
WriteAttributeValue("", 1423, Slider[i], 1423, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n");
#nullable restore
#line 40 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
            <div class=""card-header"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "554ab19586a60fe91d54fc589bc83b08b973efc67701", async() => {
                WriteLiteral("\r\n                    <div class=\"input-group\">\r\n                        <select class=\"custom-select mr-sm-2\" id=\"TournamentSearch\" name=\"tourId\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "554ab19586a60fe91d54fc589bc83b08b973efc68146", async() => {
                    WriteLiteral("Select a Tournament");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 58 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                             foreach (var Tournament in Model.TournamentsDtos)
                            {
                                var selected = Model.TournamentId == Tournament.TournamentId ? "selected" : string.Empty;
                                if (string.IsNullOrEmpty(selected))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "554ab19586a60fe91d54fc589bc83b08b973efc69731", async() => {
                    WriteLiteral("\r\n                                        ");
#nullable restore
#line 64 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                                   Write(Tournament.TournamentName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                                                Write(Tournament.TournamentId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-ID", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 66 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "554ab19586a60fe91d54fc589bc83b08b973efc611964", async() => {
                    WriteLiteral("\r\n                                        ");
#nullable restore
#line 70 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                                   Write(Tournament.TournamentName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                                                         Write(Tournament.TournamentId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-ID", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 72 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                                }

                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </select>
                        <button type=""button"" id=""SearchBtn"" class=""btn btn-outline-primary""><i class=""fas fa-search""></i>Search</button>
                        <button type=""button"" id=""ResetBtn"" class=""btn btn-outline-primary""><i class=""fa-solid fa-rotate-right""></i>Reset</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <div id=\"ListingContainer\">\r\n");
#nullable restore
#line 83 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
                       Html.RenderPartial("ListingTeams", Model.teamsDtos);

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- /.col-lg-9 -->\r\n\r\n</div>\r\n<script>\r\n    $(\"#SearchBtn\").click(function () {\r\n        debugger;\r\n        $.ajax({\r\n            type: \"Get\",\r\n            url: \"");
#nullable restore
#line 96 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
             Write(Url.Action("Index", "Main"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: {
                tourId: $(""#TournamentSearch option:selected"").attr(""data-ID"")
            }
        }).done(function (response) {
            $(""#MainPage"").html(response);
        }).fail(function (XMLHttpRequest, testStatus, erorrThrown) {
            alert(""FAIL"");
        });
    });
      $(""#ResetBtn"").click(function () {
        debugger;
        $.ajax({
            type: ""Get"",
            url: """);
#nullable restore
#line 110 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Main\Index.cshtml"
             Write(Url.Action("Index", "Main"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n        }).done(function (response) {\r\n            $(\"#MainPage\").html(response);\r\n        }).fail(function (XMLHttpRequest, testStatus, erorrThrown) {\r\n            alert(\"FAIL\");\r\n        });\r\n      });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MainIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
