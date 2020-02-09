using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Reporting
{
    public class XmlReportWriter : IReportWriter
    {
        public Report GenerateReport(IEnumerable<Attendance> attendances)
        {
            using var sw = new StringWriter();

            var serializer = new XmlSerializer(typeof(List<Attendance>));
            serializer.Serialize(sw, attendances.ToList());

            var xmlString = sw.ToString();
            return new Report() { Content = xmlString, ContentType = "application/xml" };
        }
    }
}