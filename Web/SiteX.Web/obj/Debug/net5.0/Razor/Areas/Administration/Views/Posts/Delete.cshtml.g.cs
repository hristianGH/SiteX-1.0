#pragma checksum "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1618321794ee968c07457ae60e83eda350496b30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Posts_Delete), @"mvc.1.0.view", @"/Areas/Administration/Views/Posts/Delete.cshtml")]
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
#line 1 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\_ViewImports.cshtml"
using SiteX.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\_ViewImports.cshtml"
using SiteX.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1618321794ee968c07457ae60e83eda350496b30", @"/Areas/Administration/Views/Posts/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ce076e5d258e8a2b7cb4fb5a5d09c7291b0fe87", @"/Areas/Administration/Views/_ViewImports.cshtml")]
    public class Areas_Administration_Views_Posts_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SiteX.Web.ViewModels.BlogViewModels.PostOutViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ckeditor5/ckeditor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("align-content-md-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchByGenre", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("category tag"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
  
    this.ViewData["Title"] = Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1618321794ee968c07457ae60e83eda350496b306005", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1618321794ee968c07457ae60e83eda350496b307048", async() => {
                WriteLiteral("\r\n\r\n   \r\n    <div class=\"form-group\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1618321794ee968c07457ae60e83eda350496b307359", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 13 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line (13,37)-(13,45) 13 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n     <input type=\"submit\" class=\"btn btn-danger\" value=\"DELETE\" />\r\n ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<article class=\"singlepost post-12078 post type-post status-publish format-standard has-post-thumbnail hentry category-frontpage category-talent\"");
            BeginWriteAttribute("id", " id=\"", 587, "\"", 601, 1);
#nullable restore
#line (17,151)-(17,160) 29 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
WriteAttributeValue("", 592, Model.Id, 592, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n    <header>\r\n        <!-- THUMB -->\r\n        <div class=\"singlePosThumb\">\r\n            <img");
            BeginWriteAttribute("alt", " alt=\"", 699, "\"", 717, 1);
#nullable restore
#line (22,23)-(22,35) 29 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
WriteAttributeValue("", 705, Model.Title, 705, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-src=\"");
#nullable restore
#line (22,48)-(22,66) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(Model.PreviewImage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\" lazyloaded\"");
            BeginWriteAttribute("src", " src=\"", 769, "\"", 794, 1);
#nullable restore
#line (22,93)-(22,112) 29 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
WriteAttributeValue("", 775, Model.PreviewImage, 775, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%;height:700px;\">\r\n            <div class=\"content-title\">\r\n                <h1 class=\"page-title\">");
#nullable restore
#line (24,41)-(24,52) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
            </div>
            <div class=""bub-right""></div>
            <div class=""bub-left""></div>
        </div>

        <div class=""clearfix""></div>
        <!-- META -->
        <div class=""singleMeta"">
            <div class=""grid_2 alpha omega"">
                <img alt=""Poster s image"" src=""https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.YAJlHz4zchNP5zIfsajE9AHaFr%26pid%3DApi&f=1"" width=""88"" height=""88"">
            </div>
            <div class=""grid_10 "">
                <div class=""grid_5 "">
");
#nullable restore
#line 38 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
                     if (Model.Poster != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"icon-user\"></i> ");
            WriteLiteral("by <a href=\"\" title=\"\" rel=\"author\">");
#nullable restore
#line (40,90)-(40,111) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(Model.Poster.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> <br>\r\n");
#nullable restore
#line 41 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"icon-user\"></i> ");
            WriteLiteral("by <a href=\"\" title=\"\" rel=\"author\"> Anonymous </a> <br>\r\n");
#nullable restore
#line 45 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <i class=\"icon-time\"></i> ");
#nullable restore
#line (48,48)-(48,58) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n                </div>\r\n                <div class=\"grid_5 \">\r\n                    <i class=\"icon-bookmark-empty\"></i>\r\n");
#nullable restore
#line 52 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
                     foreach (var genres in Model.Genres)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1618321794ee968c07457ae60e83eda350496b3016092", async() => {
#nullable restore
#line (54,101)-(54,112) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(genres.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ,");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line (54,70)-(54,79) 13 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
WriteLiteral(genres.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 55 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <br>\r\n                    <p>");
#nullable restore
#line (57,25)-(57,47) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(Model.Comments.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" Comments</p>\r\n                </div>\r\n                <p> --- </p>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </header>\r\n\r\n    <div class=\"clearfix\"></div>\r\n\r\n    <div class=\"content-entry\">\r\n\r\n        ");
#nullable restore
#line (70,11)-(70,38) 6 "C:\Users\1\Documents\GitHub\SoftUni C#\SiteX\Web\SiteX.Web\Areas\Administration\Views\Posts\Delete.cshtml"
Write(new HtmlString(@Model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n\r\n    <div class=\"clearfix\"></div>\r\n\r\n\r\n    <div class=\"clearfix\"></div>\r\n</article>\r\n\r\n \r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
        function showAddCommentForm(parentId) {
            $(""#AddCommentForm input[name='ParentId']"").val(parentId);
            $(""#AddCommentForm"").show();
            $([document.documentElement, document.body]).animate({
                scrollTop: $(""#AddCommentForm"").offset().top
            }, 1000);
        }
        function sendVote(postId, isUpVote) {
            var token = $(""#votesForm input[name=__RequestVerificationToken]"").val();
            var json = { postId: postId, isUpVote: isUpVote };
            $.ajax({
                url: ""/api/votes"",
                type: ""POST"",
                data: JSON.stringify(json),
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                headers: { 'X-CSRF-TOKEN': token },
                success: function (data) {
                    $(""#votesCount"").html(data.votesCount);
                }
            })};
    ClassicEditor
        .create( document.querySelector");
                WriteLiteral("( \'#Body\' ) )\r\n        .catch( error => {\r\n            console.error( error );\r\n        } );\r\n</script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SiteX.Web.ViewModels.BlogViewModels.PostOutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
