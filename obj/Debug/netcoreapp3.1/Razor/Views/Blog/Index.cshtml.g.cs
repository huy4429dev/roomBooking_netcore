#pragma checksum "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f3cf2211168f10904d21f1f568dd3e9e4332e9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
#line 1 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\_ViewImports.cshtml"
using RoomBooking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\_ViewImports.cshtml"
using RoomBooking.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\_ViewImports.cshtml"
using RoomBooking.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\_ViewImports.cshtml"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f3cf2211168f10904d21f1f568dd3e9e4332e9f", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b28eb06dc843daf1d03516a98ae8a930f045de5", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BlogPost>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
  
    Layout = "_Layout";
           ViewBag.Title = "Tin tức";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"colorlib-blog\">\r\n\t\t\t<div class=\"container\">\r\n\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t<div class=\"col-md-7 col-md-push-5\">\r\n");
#nullable restore
#line 10 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                         foreach (var item in Model)
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<article class=\"animate-box\">\r\n\t\t\t\t\t\t\t\t<div class=\"blog-img\"");
            BeginWriteAttribute("style", " style=\"", 326, "\"", 393, 4);
            WriteAttributeValue("", 334, "background-image:", 334, 17, true);
            WriteAttributeValue(" ", 351, "url(", 352, 5, true);
#nullable restore
#line 13 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
WriteAttributeValue("", 356, item.Thumbnail.Replace("\\","/"), 356, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 391, ");", 391, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n\t\t\t\t\t\t\t\t<div class=\"desc\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"meta\">\r\n\t\t\t\t\t\t\t\t\t\t<p>\r\n\t\t\t\t\t\t\t\t\t\t\t<span>");
#nullable restore
#line 17 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                             Write(item.CreatedAt.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t\t\t\t\t\t<span>");
#nullable restore
#line 18 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                             Write(item.User.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n\t\t\t\t\t\t\t\t\t\t</p>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<h2><a href=\"#\">");
#nullable restore
#line 21 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h2>\r\n\t\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 22 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                  Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</article>\r\n");
#nullable restore
#line 25 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
							
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t<div class=\"col-md-4 col-md-pull-7\">\r\n\t\t\t\t\t\t<div class=\"aside animate-box\">\r\n\t\t\t\t\t\t\t<h3>Bài viết gần đây</h3>\r\n");
#nullable restore
#line 32 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                             foreach (var recent in ViewBag.RecentPost )
							{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<div class=\"blog-entry-side\">\r\n\t\t\t\t\t\t\t\t\t<a href=\"blog.html\" class=\"blog-post\">\r\n\t\t\t\t\t\t\t\t\t\t<span class=\"img\"");
            BeginWriteAttribute("style", " style=\"", 1062, "\"", 1131, 4);
            WriteAttributeValue("", 1070, "background-image:", 1070, 17, true);
            WriteAttributeValue(" ", 1087, "url(", 1088, 5, true);
#nullable restore
#line 36 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1092, recent.Thumbnail.Replace("\\","/"), 1092, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1129, ");", 1129, 2, true);
            EndWriteAttribute();
            WriteLiteral("></span>\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"desc\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"date\">");
#nullable restore
#line 38 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                                          Write(recent.CreatedAt.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t\t\t\t\t\t<h3>");
#nullable restore
#line 39 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                           Write(recent.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"cat\">");
#nullable restore
#line 40 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                                         Write(recent.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 44 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
								
							}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div class=\"aside animate-box\">\r\n\t\t\t\t\t\t\t<h3>Danh mục</h3>\r\n\t\t\t\t\t\t\t<ul class=\"category\">\r\n");
#nullable restore
#line 50 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                 foreach ( var category in  ViewBag.Categories)
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<li><a href=\"#\"><i class=\"icon-check\"> ");
#nullable restore
#line 52 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                                                      Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i><span> (");
#nullable restore
#line 52 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
                                                                                                Write(category.PostCategories.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span></a></li>\r\n");
#nullable restore
#line 53 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Blog\Index.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BlogPost>> Html { get; private set; }
    }
}
#pragma warning restore 1591
