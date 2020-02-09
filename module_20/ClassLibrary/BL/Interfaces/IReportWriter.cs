using System.Collections.Generic;
using ClassLibrary.BL.Model;
using ClassLibrary.BL.Reporting;

namespace ClassLibrary.BL.Interfaces
{
    public interface IReportWriter
    {
        Report GenerateReport(IEnumerable<Attendance> attendances); 
    }
}