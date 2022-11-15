using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IntegrationLibrary.Core.Model;
using System.IO;
using IronPdf;

namespace IntegrationLibrary.Core.Service.Generators
{
    public class BloodReportPDFGenerator
    {
        public async Task CreatePDF(List<BloodRequest> acceptedRequests, BloodBank bank)
        {
            var Renderer = new ChromePdfRenderer();

            var html = @"<h1>Blood usage report</h1><div>" +
                "<p>Blood bank: " + bank.Name + "</p>" +
                "<p>Bank email: " + bank.Email + "</p></div>";

            html += @"<div>does this really work</div>";
            PdfDocument doc = Renderer.RenderHtmlAsPdf(html);

            String today = DateTime.Now.ToString("ddMMyyyy_hhmm");
            doc.SaveAs("BloodReportFor"  + bank.Name.Replace(" ", "") + "_"+ today + ".pdf");
        }

    }
}
