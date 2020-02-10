using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Reporting
{
    public class TxtReportGenerator : IReportGenerator
    {
        public Report GenerateReport(IEnumerable<Attendance> attendances)
        {
            if (attendances == null)
            {
                throw new ArgumentNullException(nameof(attendances));
            }

            var sb = new StringBuilder();

            foreach (var attendance in attendances)
            {
                sb.AppendLine(attendance.ToString()); //TODO Format
            }

            return new Report() { Content = sb.ToString(), ContentType = "text/plain" };
        }
    }
}