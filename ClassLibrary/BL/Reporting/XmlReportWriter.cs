using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Reporting
{
    public class XmlReportWriter : IReportWriter
    {
        private readonly string filePath;

        public XmlReportWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteReport(IEnumerable<Attendance> attendances)
        {
            using var fs = File.OpenWrite(filePath);

            var serializer = new XmlSerializer(typeof(List<Attendance>));
            serializer.Serialize(fs, attendances.ToList());
        }
    }
}
