#pragma checksum "C:\Users\md sohail alam\Downloads\Telegram Desktop\FirstProject\FirstProject\FirstProject\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25081967c62965a32af92735c4538cfc59630770"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Index), @"mvc.1.0.view", @"/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25081967c62965a32af92735c4538cfc59630770", @"/Index.cshtml")]
    public class Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Scripts", async() => {
                WriteLiteral(@"


    <script>
        $(document).ready(function () {
            PageList();
            $('#edit').summernote();
           
            $('#insPage').show();
            $('#updPage').hide();
        });

        //$(document).ready(function () {
            
        //});

        var postForm = function () {
            var content = $('textarea[name=""Description""]').html($('#edit').code());
        }
        function InsertPage() {
            //here we are checking it's validation.//
            if ($(""#Title"").val() == """") {
                alertify.error(""Title is required"")
            }
            else if ($(""#Slug"").val() == """") {
                alertify.error(""Slug is required"")
            }
            else if ($(""#Description"").val() == """") {
                alertify.error(""Description is required"")
            }
            else if ($(""#Image"").val() == """") {
                alertify.error(""Image is required"")
            }
            else if ($(""#Status""");
                WriteLiteral(@").val() == """") {
                alertify.error(""Status is required"")
            }

            else {
                var Pageobj = {
                    Title: $(""#Title"").val(),
                    Slug: $(""#Slug"").val(),
                    Description: $(""#Description"").val(),
                    Image: $(""#Image"").val(),
                    Status: $(""#Status"").val()
                }
                $.ajax({
                    url: ""/Page/InsertPage"",
                    type: ""POST"",
                    data: Pageobj,
                    success: function (result) {
                        alertify.success(""The data is inserted successfully"");
                        PageList();

                    },
                    error: function (result) {
                        alertify.error(""Error is occurs"");
                    }

                });
            }
        }

        function PageList() {
            // alert('hello');
            $.ajax({
              ");
                WriteLiteral(@"  url: ""/Page/GetAllMyPage"",
                type: ""GET"",
                dataType: ""Json"",
                success: function (result) {
                    // console.log('Alam bhai ko result', result);

                    var html = '';
                    $.each(result, function (key, item) {
                        // console.log('alam ka jalwa', item);
                        html += '<tr>';
                        html += '<td>' + item.id + '</td>';
                        html += '<td>' + item.title + '</td>';
                        html += '  <td>' + item.slug + '</td>';
                        html += ' <td>' + item.description + '</td>';
                        html += ' <td><img src=""../Images/' + item.image + '"" height=""50"" width=""50""/></td>';
                        html += '<td>' + item.strStatus + '</td>';

                        html += ' <td style= ""Display:flex; ""><button type=""button"" id=""deletePage"" class=""btn btn-primary"" style=""margin-right:5%;"" data-id=' + item.id + ");
                WriteLiteral(@"' data-img='+item.image+'>Delete</button>';
                        html += '| <button type=""button"" class=""btn btn-primary"" onclick=""Edit(' + item.id + ')""> Edit </button></td>';

                        html += '</tr>';
                    });
                    $("".page"").html(html);
                }
            });
        }

        $('.page').on('click', ""#deletePage"", function () {
            
            var id = $(this).attr(""data-id"");
            var image = $(this).attr(""data-img"");
            DeletePage(id, image);

        });
        function Edit(Id) {
           
            
            // console.log(""function called"");

            $('#updPage').show();
            $('#insPage').hide();
            $.ajax({
                url: ""/Page/SelectPageById?Id="" + Id,
                type: ""GET"",
                dataType: ""Json"",
                success: function (result) {
                    
                        $(""#Id"").val(result.id),
                    ");
                WriteLiteral(@"    $(""#Title"").val(result.title),
                        $(""#Slug"").val(result.slug),
                        $(""#edit"").summernote(""code"", result.description);
                        //$(""#Description"").val(result.description),
                        $(""#Imagedit"").html('<img src=""../Images/' + result.image + '"" height=""50"" width=""50"" />');
                           
                        $(""#Status"").val(result.status)
                       PageList();
                },
                error: function (result) {
                    alertify.error(""Error is occurs"");
                },

            });
        }

        function UpdatePage() {
            
          
                    $('#updPage').hide();
                    $('#insPage').show();
                    alertify.success(""The data is successfully updated"");
               
        }

        function DeletePage(Id, image) {
            alertify.confirm('Confirm Title', 'Confirm Message',
                fun");
                WriteLiteral(@"ction () {
                    $.ajax({
                        url: ""/Page/DeletePage"",
                        data: { id: Id, imgdel: image },
                        type: ""POST"",
                        success: function (result) {
                            alertify.success(""You have click ok"");
                            PageList();
                        },
                    });
                }
                , function () {
                    alertify.error('Cancel')
                })
        }

        function Reset() {
            $(""#Title"").val('');
            $(""#Slug"").val('');
            $(""#edit"").summernote('code',"""");
            $(""#Image"").val('');
            $(""#Status"").val('');
            $(""#Imagedit"").html('');

        }
       
        $(document).ready(function () {             /*SLUG CODE FROM HERE*/
            $(""#Title"").keyup(function () {
                var Text = $(this).val();
                Text = Text.toLowerCase();
        ");
                WriteLiteral(@"        Text = Text.replace(/[^a-zA-Z0-9]+/g, '-');
                $(""#Slug"").val(Text);
            });
        });
        ////Status code of jquery are done here.........

        $(document).ready(function () {
            
            $('.hide input[type=""radio""]').click(function () {
                var value = $(this).val();
                $.ajax({
                    url: ""/Page/InsertPage"",
                    type: 'post',
                    data: { ajax: 1, value: value },
                    success: function (response) {
                        $('#response').text(value);
                    }
                });
            });
        });

        $(document).ready(function () {
            $("".custom-file-input"").on(""change"", function () {
                //console.log($(this));
                //var filename = $(this).val().split(""\\"").pop();
                //$(this).next("".custom-file-label"").html(filename);

                var filelabel1 = $(this).next("".cust");
                WriteLiteral(@"om-file-input"");
                var files = $(this)[0].files;
                if (files.length > 1) {
                    filelabel1.html(files.length + 'files selected');

                }
                else if (files.length == 1) {
                    filelabel1.html(files[0].name);
                }
            })

        });

    </script>
");
            }
            );
            WriteLiteral(@"



<form method=""post"" asp-controller=""Page"" asp-action=""New"" enctype=""multipart/form-data"">

    <input type=""hidden"" class=""form-control"" id=""Id"" name=""Id"" />
    <div class=""form-group"">
        <h4>Enter your Title</h4>
        <input type=""text"" class=""form-control"" id=""Title"" name=""Title"" required/>
");
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <h4>Enter your Slug </h4>\r\n        <input type=\"text\" class=\"form-control\"  id=\"Slug\"  name=\"Slug\"/>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <h4>Enter your Description</h4>\r\n");
            WriteLiteral("\r\n        <textarea id=\"edit\" name=\"Description\" required>  </textarea>\r\n\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n\r\n");
            WriteLiteral("\r\n        <label class=\"col-sm-2 col-form-label\">Photo</label>\r\n        <input class=\"form-control\" multiple type=\"file\" name=\"ProfileImage\" id=\"Image\" required />\r\n\r\n        <div id=\"Imagedit\"></div>\r\n\r\n    </div>\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 8846, "\"", 8877, 1);
#nullable restore
#line 255 "C:\Users\md sohail alam\Downloads\Telegram Desktop\FirstProject\FirstProject\FirstProject\Index.cshtml"
WriteAttributeValue("", 8852, ViewData["FileLocation"], 8852, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

    <div class=""form-group"">
        <h4>Enter your Status</h4>
        <input type=""radio"" class=""status""  name=""Status"" value=""1"" checked /> True
        <input type=""radio"" class=""status"" name=""Status"" value=""0"" /> False

    </div>

    <button type=""submit"" id=""insPage"" class=""btn btn-success"" ");
            WriteLiteral(@">Insert</button>
    <button type=""submit"" id=""updPage"" class=""btn btn-primary"" onclick=""UpdatePage();"">Update</button>
    <button type=""button"" id=""updPage"" class=""btn btn-danger"" onclick=""Reset();"">Reset</button>
   
</form>



<h4>Insert Page</h4>

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Slug</th>
            <th>Description</th>
            <th>Image</th>
            <th>Status</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody class=""page"">
    </tbody>
</table>



<script>

    $(document).ready(function () {

        $(""#Page"").validate({
            ignore: "":hidden"",
            rules: {
                Title: {
                    required: true,
                    minlength: 3
                },
                Slug: {
                    required: true,
                    minlength: 3
                },
                Description: {
          ");
            WriteLiteral(@"          required: true,
                },
                Image: {
                    requuired: true,
                },
                Stauts: {
                    required: true
                },

            },
            submitHandler: function (form) {
                alert('valid form submission'); // for demo
                $.ajax({
                    type: ""POST"",
                    url: ""Page/submit"",
                    data: $(form).serialize(),
                    success: function () {
                        $(form).html(""<div id='message'></div>"");
                        $('#message').html(""<h2>Your request is on the way!</h2>"")
                            .append(""<p>someone</p>"")
                            .hide()
                            .fadeIn(1500, function () {
                                $('#message').append(""<img id='checkmark' src='images/ok.png' />"");
                            });
                    }
                });
             ");
            WriteLiteral("   return false; // required to block normal submit since you used ajax\r\n            }\r\n\r\n        });\r\n\r\n    });\r\n</script>\r\n\r\n");
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