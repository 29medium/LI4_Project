#pragma checksum "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1150f70f3d5685c643541c01ba00966f416f644"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Registration), @"mvc.1.0.view", @"/Views/Home/Registration.cshtml")]
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
#line 1 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\_ViewImports.cshtml"
using Projeto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\_ViewImports.cshtml"
using Projeto.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1150f70f3d5685c643541c01ba00966f416f644", @"/Views/Home/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4dfd97469170fe8b85a6370378ea67b5320a14", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Projeto.Models.CreateModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 6 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.Username, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 7 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.Username, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 8 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.Username, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 12 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.Password, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 13 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.Password, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 14 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.Password, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 18 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.Email, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 19 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.Email, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 20 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.Email, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 24 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.PrimeiroNome, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 25 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.PrimeiroNome, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 26 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.PrimeiroNome, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 30 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.UltimoNome, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 31 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.UltimoNome, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 32 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.UltimoNome, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 36 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.Experiencia, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 37 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.Experiencia, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 38 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.Experiencia, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 42 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.CapacidadeMonetaria, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 43 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.CapacidadeMonetaria, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 44 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.CapacidadeMonetaria, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"field\" style=\"max-width:30%\">\r\n        ");
#nullable restore
#line 48 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.LabelFor(model => model.Localizacao, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 49 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.EditorFor(model => model.Localizacao, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 50 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
   Write(Html.ValidationMessageFor(model => model.Localizacao, "", null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <ul class=\"actions\">\r\n        <li><input value=\"Register\" class=\"button alt\" type=\"submit\"></li>\r\n    </ul>\r\n");
#nullable restore
#line 56 "C:\Users\fcpf1\OneDrive\Ambiente de Trabalho\Universidade\LI4_Project\Projeto\Projeto\Views\Home\Registration.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Projeto.Models.CreateModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
