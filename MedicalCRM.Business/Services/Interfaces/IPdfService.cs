using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IPdfService {
        Task<MemoryStream> GetPdfFileFromHtml(string html = null);
    }
}
