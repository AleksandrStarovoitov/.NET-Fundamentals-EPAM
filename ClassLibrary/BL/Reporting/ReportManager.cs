using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.BL
{
    public class ReportManager
    {
        private IReportGenerator reportGenerator;
        private DbContext dbContext;

        public ReportManager(IReportGenerator reportGenerator, DbContext dbContext)
        {
            this.reportGenerator = reportGenerator;
            this.dbContext = dbContext;
        }

        public void GenerateReport<T>(Predicate<T> predicate)
        {
            reportGenerator.GenerateReport(predicate);
        }
    }
}