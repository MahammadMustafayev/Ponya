#pragma checksum "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11849dde0f54fa5f1a76b513e9b9fd6f262a5d74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
#line 1 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.ViewModel.AboutViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.ViewModel.BlogViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.ViewModel.PortfolioViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.ViewModel.PortfolioDetailViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\_ViewImports.cshtml"
using Ponya_Back.ViewModel.ServiceViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11849dde0f54fa5f1a76b513e9b9fd6f262a5d74", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc137538b0dcc96f3faf2118581abe413ab8b4b", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\admin\OneDrive\İş masası\Ponya\Ponya\Ponya-Back\Ponya-Back\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- About-Info -->
<section class=""about-bgcolor w-100 vh-40""
         style=""background-image: url(assets/image/index/white-pattern-long.png);"">
    <div class=""container pt-5"">
        <div class=""text-xxl-center pt-5"">
            <h4 class=""text-white pt-3 "">About</h4>
            <a href=""index.html"" class=""pt-5 text-white fs-5"">
                <i class=""bi bi-house-fill ""></i>Home <i class=""bi bi-caret-right-fill""></i> About
            </a>
        </div>
    </div>
</section>
<!-- Info-About-Us -->
<section id=""about-us"" class=""pt-5 pb-5"">
    <div class=""container pt-3"">
        <div class=""text-xxl-center pt-3"">
            <p class=""text-dark"">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec condimentum orci et leo vehicula
                malesuada. Praesent blandit dictum velit eu dapibus. Class aptent taciti sociosqu ad litora
                torquent per conubia nostra, per inceptos himenaeos. Ut mattis ligula et turpis egestas, et
        ");
            WriteLiteral(@"        fermentum sapien feugiat.
            </p>
        </div>
        <div class=""row pt-5"">
            <div class=""col-lg-6"">
                <h3 class=""fw-bold fs-65 text-black""> Your success is</h3>
                <h3 class=""fw-bold fs-65 main-color"">Our Mission</h3>
                <p class=""text-dark pt-3"">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut elit tellus, luctus nec
                    ullamcorper mattis, pulvinar dapibus leo.
                </p>
                <img class=""pt-3"" src=""assets/image/about/about1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 1701, "\"", 1707, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <img src=\"assets/image/about/about2.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1823, "\"", 1829, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <h3 class=""fw-bold fs-65 text-black pt-3""> High Experience</h3>
                <h3 class=""fw-bold fs-65 main-color"">Professional Team</h3>
                <p class=""text-dark pt-3"">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut elit tellus, luctus nec
                    ullamcorper mattis, pulvinar dapibus leo.
                </p>
            </div>
        </div>
    </div>
</section>
<!-- Proggress-Bar -->
<section class=""pt-5 pb-5"">
    <div class=""container pt-5"">
        <div class=""row"">
            <div class=""col-md-6"">
                <span class=""text-dark fw-bold fs-5 coruier"">Get your ideas on the cloud</span>
                <h3 class="" fw-bold fs-5"">Thrive Your</h3>
                <h3 class="" fw-bold fs-5"">Business</h3>
                <h3 class=""fw-bold fs-5 main-color"">on Social Media</h3>
                <p class=""text-dark"">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut elit tellus,");
            WriteLiteral(@"
                    luctus nec
                    ullamcorper mattis, pulvinar dapibus leo.
                </p>

                <button class=""btn-group main-bgcolor form-control-lg fw-bold text-white contactbtn text-decoration-underline"">
                    Case
                    Studios
                </button>
            </div>
            <div class=""col-md-6"">
                <div class=""col"">
                    <div class=""row"">

                        <label");
            BeginWriteAttribute("for", " for=\"", 3348, "\"", 3354, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""fw-bold text-dark tahoma"">Facebook</label>
                        <div class=""container"">
                            <div class=""progress"" style=""height: 20px;"">
                                <div class=""progress-bar main-color"" role=""progressbar"" style=""width: 25%;"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100"">25%</div>
                            </div>
                        </div>
                    </div>
                    <div class=""row pt-5"">
                        <label");
            BeginWriteAttribute("for", " for=\"", 3876, "\"", 3882, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""fw-bold text-dark tahoma"">Instagram</label>
                        <div class=""container"">
                            <div class=""progress"" style=""height: 20px;"">
                                <div class=""progress-bar main-color"" role=""progressbar"" style=""width: 40%;"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100"">40%</div>
                            </div>
                        </div>
                    </div>
                    <div class=""row pt-5"">
                        <label");
            BeginWriteAttribute("for", " for=\"", 4405, "\"", 4411, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""fw-bold text-dark tahoma"">Pinterest</label>

                        <div class=""container"">
                            <div class=""progress"" style=""height: 20px;"">
                                <div class=""progress-bar main-color"" role=""progressbar"" style=""width: 65%;"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100"">65%</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Our-Team -->
<section id=""team"" class=""pt-5 pb-5"">
    <div class=""container pb-5"">
        <div class=""text-xxl-center"">
            <h3 class=""text-dark tahoma fs-1"">Our Team</h3>
        </div>
        <div class=""row pt-4 gap-3 ms-5"">
            <div class=""col-md-3 bg-light"">
                <div>
                    <img src=""assets/image/about/team1.jpg"" width=""320"" height=""500""");
            BeginWriteAttribute("alt", " alt=\"", 5349, "\"", 5355, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <h4 class=""text-dark pt-3"">Janie Frank</h4>
                <p class=""text-dark"">Senior Developer</p>
                <p class=""text-dark pt-3"">Lorem ipsum dolor sit amet, consectetur adipiscing elit</p>
            </div>
            <div class=""col-md-3 bg-light"">
                <div>
                    <img src=""assets/image/about/team2.jpg"" width=""320"" height=""500""");
            BeginWriteAttribute("alt", " alt=\"", 5778, "\"", 5784, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <h4 class=""text-dark pt-3"">Janie Frank</h4>
                <p class=""text-dark"">Senior Developer</p>
                <p class=""text-dark pt-3"">Lorem ipsum dolor sit amet, consectetur adipiscing elit</p>
            </div>
            <div class=""col-md-3 bg-light"">
                <div>
                    <img src=""assets/image/about/team3.jpg"" width=""320"" height=""500""");
            BeginWriteAttribute("alt", " alt=\"", 6207, "\"", 6213, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <h4 class=""text-dark pt-3"">Janie Frank</h4>
                <p class=""text-dark"">Senior Developer</p>
                <p class=""text-dark pt-3"">Lorem ipsum dolor sit amet, consectetur adipiscing elit</p>
            </div>
            <div class=""col-md-3""></div>
        </div>
    </div>
</section>

");
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
