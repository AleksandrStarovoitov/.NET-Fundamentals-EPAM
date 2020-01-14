using System.Collections.Generic;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Interfaces
{
    public interface IReportWriter
    {
        void WriteReport(IEnumerable<Attendance> attendances); 
    }
}