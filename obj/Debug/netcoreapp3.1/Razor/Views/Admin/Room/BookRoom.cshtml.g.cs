#pragma checksum "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5934899a98083b87127d43081f1370cf1edc8af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Room_BookRoom), @"mvc.1.0.view", @"/Views/Admin/Room/BookRoom.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5934899a98083b87127d43081f1370cf1edc8af", @"/Views/Admin/Room/BookRoom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b28eb06dc843daf1d03516a98ae8a930f045de5", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Room_BookRoom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookRoomAdminViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/common/css/jquery.dataTables.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/common/js/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
  
    Layout = "_LayoutAdmin";
    ViewBag.Title = "Book Room";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table id=""dtBasicExample"" class=""table table-striped table-bordered"" cellspacing=""0"" width=""100%"">
  <thead>
    <tr>
      <th class=""th-sm"" >#ID
      </th>
      <th class=""th-sm"">Họ tên
      </th>
      <th class=""th-sm"">Email
      </th>
      <th class=""th-sm"">Phone
      </th>
      <th class=""th-sm"">Loại phòng
      </th>
      <th class=""th-sm "">Ngày đặt
      </th>
      <th class=""th-sm text-center"">Thời gian đặt
      </th>
      <th class=""th-sm text-center"">Thời gian 
      </th>
      <th class=""th-sm text-center"">Trạng thái</th>
    </tr>
  </thead>
  <tbody>
");
#nullable restore
#line 29 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     foreach (var item in Model)
    {
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 769, "\"", 807, 3);
            WriteAttributeValue("", 779, "showBookRoomDetail(", 779, 19, true);
#nullable restore
#line 32 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
WriteAttributeValue("", 798, item.Id, 798, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 806, ")", 806, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor:pointer\">\r\n      <td>");
#nullable restore
#line 33 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 34 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 35 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 36 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 37 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     Write(item.TypeRoom.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 38 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
     Write(item.TimeCreated.ToString("dd/MM/yyyy H:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td class=\"text-center\">");
#nullable restore
#line 39 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
                         Write(item.TimeBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td class=\"text-center\">");
#nullable restore
#line 40 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
                         Write(item.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td class=\"text-center\">\r\n        ");
#nullable restore
#line 42 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
    Write(@item.Status == false ? Html.Raw("<span style='width:65px' class='badge badge-warning status-Content'>Chưa xử lý</span>") : @Html.Raw("<span style='width:65px' class='badge badge-success status-Content'>Đã xử lý</span>"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </td>\r\n    </tr>\r\n");
#nullable restore
#line 45 "C:\Users\Administrator\Desktop\C#\RoomBooking\Views\Admin\Room\BookRoom.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>\r\n  \r\n");
            DefineSection("Css", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f5934899a98083b87127d43081f1370cf1edc8af9266", async() => {
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
                WriteLiteral("\r\n    <style>\r\n      .show-Content{\r\n        cursor: pointer;\r\n      }\r\n      .show-Content:hover{\r\n         color:blue;\r\n      }\r\n    </style>\r\n");
            }
            );
            DefineSection("Script", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5934899a98083b87127d43081f1370cf1edc8af10724", async() => {
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
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#dtBasicExample').DataTable( 
               {  
                 ""order"": [[ 0, ""desc"" ]]
               },
            );
            $('.dataTables_length').addClass('bs-select');
        });
    </script>
    <script>
     // change status contact while click show content 
      
     
      let showContents  = document.querySelectorAll('.show-Content');
      let statusContent = document.querySelectorAll('.status-Content');
      
        showContents.forEach(function(item, index){
          item.addEventListener('click', function() {
          let idContact = this.dataset.target.slice(19);
        
          let url = ""/admin/contact/update-status/"" +  idContact;
          
          fetch(url)
                  .then(response => response.json())
                  .then(data => {
                    statusContent[index].className = 'badge badge-success status-Content'; 
                    statusContent[inde");
                WriteLiteral(@"x].innerText = 'Đã xem';
                  })
                  .catch(err => {
                      console.log(err);
                  })
          })
        })

        // show bookRoomDetail

        function showBookRoomDetail(id){
          window.location.href = ""/admin/room/book-room/"" + id;

        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookRoomAdminViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
