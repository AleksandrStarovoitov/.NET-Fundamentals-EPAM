using System.Collections.Generic;
using System.IO;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Reporting
{
    public class TxtReportWriter : IReportWriter
    {
        private readonly string filePath;

        public TxtReportWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteReport(IEnumerable<Attendance> attendances)
        {
            using var fs = new StreamWriter(File.OpenWrite(filePath));

            foreach (var attendance in attendances)
            {
                fs.WriteLine(attendance.ToString()); // TODO Format
            }
        }
    }
}