#pragma checksum "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66054a1d0e2dbc14ed9a27411015418b20b11551"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie__IndexTable), @"mvc.1.0.view", @"/Views/Movie/_IndexTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movie/_IndexTable.cshtml", typeof(AspNetCore.Views_Movie__IndexTable))]
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
#line 1 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\_ViewImports.cshtml"
using ReviewApp;

#line default
#line hidden
#line 2 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\_ViewImports.cshtml"
using ReviewApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66054a1d0e2dbc14ed9a27411015418b20b11551", @"/Views/Movie/_IndexTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02edc38dd5e47691a22646317594a97a33896b1a", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie__IndexTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ReviewApp.Model.Movie>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
  
    var count = 0;
    float averageScore = 0;

#line default
#line hidden
            BeginContext(99, 139, true);
            WriteLiteral("<table class=\"table\" id=\"table-movies\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(239, 41, false);
#line 12 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(280, 379, true);
            WriteLiteral(@"
            </th>
            <th>
                Average Score
            </th>
            <th>
                Duration
            </th>
            <th>
                Director
            </th>
            <th>
                Genre
            </th>
            <th>

            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 33 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(708, 64, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 772, "\"", 821, 1);
#line 37 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
WriteAttributeValue("", 778, Url.Content("~/movies/" + item.PictureURL), 778, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(822, 94, true);
            WriteLiteral(" width=\"65\" height=\"100\" />\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(916, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebfe85ab72344046b998b0823d9f86b8", async() => {
                BeginContext(965, 40, false);
#line 40 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
                EndContext();
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
#line 40 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                                              WriteLiteral(item.ID);

#line default
#line hidden
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
            EndContext();
            BeginContext(1009, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 43 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                     foreach (var score in @item.UserRatings)
                    {
                        averageScore = averageScore + score.Score;
                        if (score.Equals(item.UserRatings.Last()))
                        {
                            item.AverageScore = (averageScore / item.UserRatings.Count());
                            averageScore = 0;
                        }
                    }

#line default
#line hidden
            BeginContext(1494, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1515, 31, false);
#line 52 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
               Write(item.AverageScore.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(1546, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1614, 50, false);
#line 55 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
               Write(Html.DisplayFor(modelItem => item.DurationMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(1664, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1732, 24, false);
#line 58 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
               Write(item?.Director?.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(1756, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 61 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                     foreach (var genre in @item.MovieGenres)
                    {
                        if (item.MovieGenres.Count() >= (count + 2))
                        {
                            

#line default
#line hidden
            BeginContext(2015, 16, false);
#line 65 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                       Write(genre.Genre.name);

#line default
#line hidden
            EndContext();
            BeginContext(2037, 7, true);
            WriteLiteral(",&nbsp;");
            EndContext();
#line 65 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                                                                 ;
                            count++;
                        }
                        else
                        {
                            

#line default
#line hidden
            BeginContext(2205, 16, false);
#line 70 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                       Write(genre.Genre.name);

#line default
#line hidden
            EndContext();
            BeginContext(2227, 6, true);
            WriteLiteral("&nbsp;");
            EndContext();
#line 70 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                                                                ;
                            count = 0;
                        }

                    }

#line default
#line hidden
            BeginContext(2335, 25, true);
            WriteLiteral("                </td>\r\n\r\n");
            EndContext();
#line 77 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                 if (this.User.IsInRole("Admin"))
                {

#line default
#line hidden
            BeginContext(2430, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(2480, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37abc7ff307147dd853aaa6e20d346c5", async() => {
                BeginContext(2525, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 80 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                                               WriteLiteral(item.ID);

#line default
#line hidden
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
            EndContext();
            BeginContext(2533, 96, true);
            WriteLiteral("\r\n                        <button type=\"button\" id=\"deleteBtn\" class=\"deleteBtn\" data-model-id=\"");
            EndContext();
            BeginContext(2630, 7, false);
#line 81 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                                                                                         Write(item.ID);

#line default
#line hidden
            EndContext();
            BeginContext(2637, 102, true);
            WriteLiteral("\">\r\n                            Delete\r\n                        </button>\r\n                    </td>\r\n");
            EndContext();
#line 85 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
                }

#line default
#line hidden
            BeginContext(2758, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 87 "E:\mvc19-20\projekt\ReviewApp\ReviewApp\Views\Movie\_IndexTable.cshtml"
        }

#line default
#line hidden
            BeginContext(2788, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ReviewApp.Model.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
