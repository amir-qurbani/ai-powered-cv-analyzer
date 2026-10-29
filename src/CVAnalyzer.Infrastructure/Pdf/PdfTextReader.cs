using UglyToad.PdfPig;
using System.Text;
using CVAnalyzer.Core.Interfaces;

namespace CVAnalyzer.Infrastructure.Pdf
{
    public class PdfTextReader : IPdfTextReader
    {
        public string ReadText(string filePath)
        {
            using var document = PdfDocument.Open(filePath);
            var text = new StringBuilder();
            foreach (var page in document.GetPages())
            {
                text.AppendLine(page.Text);
            }
            return text.ToString();
        }
        
    }
}