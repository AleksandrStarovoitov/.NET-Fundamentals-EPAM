using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ClassLibrary.BL.Interfaces.Reporting;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Reporting
{
    public class XmlReportGenerator : IXmlReportGenerator
    {
        public Report GenerateReport(IEnumerable<Attendance> attendances)
        {
            if (attendances == null)
            {
                throw new ArgumentNullException(nameof(attendances));
            }

            using var sw = new StringWriter();

            var serializer = new XmlSerializer(typeof(List<Attendance>));
            serializer.Serialize(sw, attendances.ToList());

            var xmlString = sw.ToString();
            return new Report() { Content = xmlString, ContentType = "application/xml" };
        }
    }
}