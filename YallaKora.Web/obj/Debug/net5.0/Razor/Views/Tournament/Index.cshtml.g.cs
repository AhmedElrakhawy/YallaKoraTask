#pragma checksum "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "642e2bf53341b02e0967f1467f570f464301e671"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournament_Index), @"mvc.1.0.view", @"/Views/Tournament/Index.cshtml")]
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
#line 1 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
using YallaKora.Web.VM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"642e2bf53341b02e0967f1467f570f464301e671", @"/Views/Tournament/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27da9eab3c749560c4094824de7028c9eccca4ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournament_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TournamentsTableVM>
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
  
    var tournamentId = Model.Search.Id.HasValue ? Model.Search.Id : 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row container\">\r\n\r\n    <div class=\"col-lg-12 m-2\">\r\n        <div>\r\n            <div class=\"float-left\">\r\n                <h2>Tournaments</h2>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "642e2bf53341b02e0967f1467f570f464301e6714171", async() => {
                WriteLiteral("\r\n            <div class=\"input-group\">\r\n                <hr />\r\n                <input id=\"SearchBox\" type=\"search\" name=\"Search\"");
                BeginWriteAttribute("value", " value=\"", 498, "\"", 530, 1);
#nullable restore
#line 19 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
WriteAttributeValue("", 506, Model.Search.SearchName, 506, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" />
                <button type=""button"" class=""SearchTeam btn btn-primary"">
                    <i class=""fas fa-search""></i> Search
                </button>
                <button type=""button"" class=""btn btn-primary"" id=""ResetBtn"">Reset</button>
                <div class=""float-right"">
                    <button type=""button"" class=""CreateTournament btn btn-success"">Create New Tournament</button>
                </div>
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
            WriteLiteral("\r\n        <div id=\"tableContainer\">\r\n");
#nullable restore
#line 30 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
              Html.RenderPartial("TournamentsTable", Model); 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <div class=""modal fade"" id=""FormModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"" id=""actionContainer"">

                </div>
            </div>
        </div>

        <div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""exampleModalLabel"">Are you sure you want to delete this Auction ?</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" d");
            WriteLiteral(@"ata-dismiss=""modal"">Close</button>
                        <button type=""button"" id=""mDeletebtn"" class=""btn btn-danger"">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div id=""ImageTemplate"" style=""display:none"" class=""mt-2"">
    <img class=""image img-thumbnail""");
            BeginWriteAttribute("src", " src=\"", 2493, "\"", 2499, 0);
            EndWriteAttribute();
            WriteLiteral(" data-id=\"\" style=\"width:200px;height:200px;\" />\r\n</div>\r\n\r\n<script>\r\n    $(\".CreateTournament\").click(function () {\r\n        $.ajax({\r\n            type: \"Get\",\r\n            url: \"");
#nullable restore
#line 66 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
             Write(Url.Action("CreateTournament", "Tournament"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
        }).done(function (Response) {
            $(""#actionContainer"").html(Response);
            $(""#FormModal"").modal('toggle');
        }).fail(function (XMLHttpRequest, testStatus, erorrThrown) {
            alert(""FAIL"");
        });
    });
    $(""#mDeletebtn"").click(function () {
      $.ajax({
           url: """);
#nullable restore
#line 76 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
            Write(Url.Action("DeleteTournament", "Tournament"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
           type: ""Post"",
            data: {
                ID: $(this).attr('data-recordID')
            }
         }).done(function (response) {
             $(""#tableContainer"").html(response);
             $(""#deleteModal"").modal('toggle');
        }).fail(function (XMLHttpRequest, testStatus, erorrThrown) {
            alert(""FAIL"");
        })
    });
    function RemoveImagesOnClick() {
        $(""#PicturesArea .image"").click(function () {
            $(this).remove();
        });
    }
    function ReloadTable() {
        $.ajax({
            type: ""Get"",
            url: """);
#nullable restore
#line 96 "D:\My work\Projects\Solution1\YallaKora.Web\Views\Tournament\Index.cshtml"
             Write(Url.Action("Index", "Tournament"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
        }).done(function (Response) {
            $(""#tableContainer"").html(Response);
        }).fail(function (XMLHttpRequest, testStatus, erorrThrown) {
            alert(""FAIL"");
        });
    }
    function AttachNewImage(PicURL, PicID) {
        debugger;
        var $NewImgHTML = $(""#ImageTemplate"").clone();
        $NewImgHTML.find("".image"").attr(""src"", ""/Content/Images/"" + PicURL);
        $NewImgHTML.find("".image"").attr(""data-id"", PicID);
        $(""#PicturesArea"").append($NewImgHTML.html());
        RemoveImagesOnClick();
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TournamentsTableVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
