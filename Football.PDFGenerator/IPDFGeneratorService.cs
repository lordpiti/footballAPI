using Football.Crosscutting.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Football.PDFGenerator
{
    public interface IPDFGeneratorService
    {
        Task<MemoryStream> GenerateMatchReportPDF<T>(T reportData);
    }
}
