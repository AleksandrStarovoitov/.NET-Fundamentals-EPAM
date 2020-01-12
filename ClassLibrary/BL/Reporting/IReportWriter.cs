using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Reporting
{
    public interface IReportWriter
    {
        void WriteReport(IEnumerable<Attendance> attendances); 
    }
}
