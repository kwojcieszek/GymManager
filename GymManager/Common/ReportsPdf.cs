using System;
using System.Collections.Generic;
using System.IO;
using GymManager.DbModels;

namespace GymManager.Common;

public class ReportsPdf
{
    private readonly PdfFromHtml _pdfHtml = new();

    public IEnumerable<string> MemberDocuemnts(Member member)
    {
        var pdf = new PdfFromHtml();

        var formatTexts = new List<FormatText>
        {
            new("{DATE}", DateTime.Now.ToLongDateString()),
            new("{LASTNAME}", member.LastName),
            new("{FIRSTNAME}", member.FirstName),
            new("{STREET1}", member.Street1),
            new("{STREET2}", member.Street2),
            new("{CITY}", member.City),
            new("{POSTCODE}", member.PostCode),
            new("{PHONE}", member.Phone),
            new("{EMAIL}", member.Email)
        };

        foreach (var file in Directory.GetFiles($"{Path.ApplicationDirectory}\\Reports", "member*.htm"))
            yield return _pdfHtml.CreateFile(file, formatTexts);
    }

    public void Print(string filePath)
    {
        _pdfHtml.Print(filePath).Wait(1000 * 5);
    }
}