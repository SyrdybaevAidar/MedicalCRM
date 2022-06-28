using GemBox.Document;
using MedicalCRM.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class PdfService : IPdfService {
        public async Task<MemoryStream> GetPdfFileFromHtml(string html = null) {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var htmlLoadOptions = new HtmlLoadOptions();
            var stream = new MemoryStream();
            using (var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes("<h1>Рецепт</h1>"))) {

                var document = DocumentModel.Load(htmlStream, htmlLoadOptions);
                document.Save(stream, SaveOptions.PdfDefault);
            }
            return stream;
        }
    }
}
