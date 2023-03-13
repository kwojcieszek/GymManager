using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SelectPdf;

namespace GymManager.Common
{
    public class PdfFromHtml
    {
        public static string DefaultAdobeApplicationPath { get; set; }

        public string CreateFile(string sourceFilePath, List<FormatText> formatTexts = null)
        {
            var destinationFilePath = $"{Path.ApplicationTempData}\\{Guid.NewGuid()}.pdf";

            var html = File.ReadAllText(sourceFilePath, Encoding.UTF8);

            if (formatTexts != null)
            {
                foreach (var formatText in formatTexts)
                {
                    html = html.Replace(formatText.Parameter, formatText.Value);
                }
            }

            var data = Converter(html);

            File.WriteAllBytes(destinationFilePath, data);

            return destinationFilePath;
        }

        public Task Print(string sourceFilePath)
        {
            var task = new Task(() =>
            {
                var psInfo = new ProcessStartInfo
                {
                    FileName = DefaultAdobeApplicationPath,
                    Arguments = $"/n /s /o /h /t \"{sourceFilePath}\" ",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                var process = Process.Start(psInfo);
                process.WaitForExit(10000);
                if (!process.HasExited)
                {
                }

                ;
            });

            task.Start();

            return task;
        }

        private byte[] Converter(string html)
        {
            var ms = new MemoryStream();

            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 15;
            converter.Options.MarginRight = 15;
            converter.Options.MarginTop = 15;
            converter.Options.MarginBottom = 15;

            var doc = converter.ConvertHtmlString(html);
            doc.Save(ms);
            doc.Close();

            return ms.ToArray();
        }
    }
}