#pragma checksum "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad2978ba15bc4dd56f65aaa29fb6c5441b548c06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tickets4You.Pages.Pages_PocetnaZaKorisnika), @"mvc.1.0.razor-page", @"/Pages/PocetnaZaKorisnika.cshtml")]
namespace Tickets4You.Pages
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
#line 1 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\_ViewImports.cshtml"
using Tickets4You;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad2978ba15bc4dd56f65aaa29fb6c5441b548c06", @"/Pages/PocetnaZaKorisnika.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7125f6bcc694c40dea72dd6fef15dc42d4393c02", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PocetnaZaKorisnika : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rezervisi btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/DodajRezervaciju", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
  
    ViewData["Title"] = "PocetnaZaKorisnika";
    await Model.Korisnik();
    await Model.Utakmice();
    ViewData["korisnik"] = Model.LogovaniKorisnik.username;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad2978ba15bc4dd56f65aaa29fb6c5441b548c065177", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ad2978ba15bc4dd56f65aaa29fb6c5441b548c065439", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad2978ba15bc4dd56f65aaa29fb6c5441b548c067333", async() => {
                WriteLiteral("\r\n    <div id=\"lige\">\r\n");
#nullable restore
#line 18 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
             foreach (string sp in Model.sportovi)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"container liga\">\r\n                    <div class=\"container2\">\r\n                        <div class=\"naziv-div\"><label class=\"naziv-liga\">");
#nullable restore
#line 22 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                    Write(sp);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></div>\r\n                    </div>\r\n                    <div class=\"utakmice\">\r\n");
#nullable restore
#line 25 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                         foreach (Models.Utakmica u in Model.utakmice)
                        {
                            if (u.sport == sp)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"utakmica row\">\r\n                                    <div class=\"datum-vreme-div col-3\"><label class=\"datum-vreme\">");
#nullable restore
#line 30 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                             Write(u.datum.Day);

#line default
#line hidden
#nullable disable
                WriteLiteral("/");
#nullable restore
#line 30 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                          Write(u.datum.Month);

#line default
#line hidden
#nullable disable
                WriteLiteral("/");
#nullable restore
#line 30 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                         Write(u.datum.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(" &nbsp;&nbsp;&nbsp;&nbsp; ");
#nullable restore
#line 30 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                                                Write(u.vreme);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></div>\r\n                                    <div class=\"timovi col-7\"><label class=\"home\">");
#nullable restore
#line 31 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                             Write(u.domacin);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label><label class=\"score\"> - : - </label> <label class=\"away\">");
#nullable restore
#line 31 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                                        Write(u.gost);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></div>\r\n                                    <div class=\"omiljena col-1\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad2978ba15bc4dd56f65aaa29fb6c5441b548c0611607", async() => {
                    WriteLiteral("Rezerviši");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sport", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                       WriteLiteral(u.sport);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sport"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sport", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sport"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                                                 WriteLiteral(u.domacin);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["home"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-home", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["home"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                                                                             WriteLiteral(u.gost);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["away"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-away", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["away"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                                                                                                      WriteLiteral(u.datum);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["date"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-date", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["date"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                                                                                                                                                                                                                                                    WriteLiteral(Model.LogovaniKorisnik.username);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</div>\r\n                                </div>\r\n");
                WriteLiteral("                                <hr class=\"sidebar-divider d-none d-md-block col-11\">\r\n");
#nullable restore
#line 36 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                </div>\r\n");
#nullable restore
#line 40 "N:\Projekti\Baze\New folder\tickets4you\Aplikacija\Tickets4You\Tickets4You\Tickets4You\Pages\PocetnaZaKorisnika.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tickets4You.Pages.PocetnaZaKorisnikaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tickets4You.Pages.PocetnaZaKorisnikaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tickets4You.Pages.PocetnaZaKorisnikaModel>)PageContext?.ViewData;
        public Tickets4You.Pages.PocetnaZaKorisnikaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591