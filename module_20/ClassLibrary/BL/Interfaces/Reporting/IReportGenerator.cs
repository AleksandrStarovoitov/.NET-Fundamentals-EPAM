using System.Collections.Generic;
using ClassLibrary.BL.Model;
using ClassLibrary.BL.Reporting;

namespace ClassLibrary.BL.Interfaces.Reporting
{
    public interface IReportGenerator
    {
        Report GenerateReport(IEnumerable<Attendance> attendances); 
    }
}